using System;
using System.Collections.Generic;
using System.Net.Http;
using ABC.Aids;
using ABC.Data;
using ABC.Domain;
using ABC.Domain.Party;
using ABC.Infra.Party;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soft;

namespace ABC.Tests;

public abstract class HostTests : TestAsserts
{
    internal static readonly TestHost<Program> host;
    internal static readonly HttpClient client;

    static HostTests()
    {
        host = new TestHost<Program>();
        client = host.CreateClient();
    }

    [TestInitialize] public virtual void InitializeRepo() {
        (GetRepo.Instance<ICountriesRepo>() as CountriesRepo)?.clear();
        (GetRepo.Instance<ICurrenciesRepo>() as CurrenciesRepo)?.clear();
        (GetRepo.Instance<IAddressRepo>() as AddressRepo)?.clear();
        (GetRepo.Instance<IPersonRepo>() as PersonsRepo)?.clear();
        (GetRepo.Instance<ICountryCurrenciesRepo>() as CountryCurrenciesRepo)?.clear();
        (GetRepo.Instance<IPersonAddressesRepo>() as PersonAddressesRepo)?.clear();
    }

    protected virtual object? isReadOnly<T>(string? callingMethod = null) => null;
    protected virtual void arePropertiesEqual(object? data1, object? data2) { isInconclusive(); }

    protected void ItemsTest<TRepo, TObj, TData>(Action<TData> setId, Func<TData, TObj> toObj, Func<List<TObj>> getList)
        where TRepo : class, IRepo<TObj>
        where TObj : UniqueEntity<TData>
        where TData : UniqueData, new() {
        var o = isReadOnly<List<TObj>>(nameof(ItemsTest));
        isNotNull(o);
        isInstanceOfType(o, typeof(List<TObj>));
        var r = GetRepo.Instance<TRepo>();
        isNotNull(r);
        var list = new List<TData>();
        var count = GetRandom.Int32(5, 30);
        for (var i = 0; i < count; i++) {
            var x = GetRandom.Value<TData>();
            if (GetRandom.Bool()) {
                setId(x);
                list.Add(x);
            }
            r.Add(toObj(x));
        }
        r.PageSize = 30;
        areEqual(count, r.Get().Count);
        var l = getList();
        areEqual(list.Count, l.Count);
        foreach (var data in list) {
            var y = l.Find(z => z.Id == data.Id);
            isNotNull(y);
            areEqualProperties(data, y);
        }
    }

    public void itemTest<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObject)
        where TRepo : class, IRepo<TObj>
        where TObj : UniqueEntity {
        var c = isReadOnly<TObj>(nameof(itemTest));
        isNotNull(c);
        isInstanceOfType(c, typeof(TObj));
        var r = GetRepo.Instance<TRepo>();
        var d = GetRandom.Value<TData>();
        d.Id = id;
        var count = GetRandom.Int32(5, 30);
        var index = GetRandom.Int32(0, count);
        for (var i = 0; i < count; i++) {
            var x = (i == index) ? d : GetRandom.Value<TData>();
            isNotNull(x);
            r?.Add(toObj(x));
        }
        r.PageSize = 30;
        areEqual(count, r.Get().Count);
        areEqualProperties(d, getObject());
    }

    protected void relatedItemsTest<TRepo, TRelatedItem, TItem, TData>(
        Action relatedTest,
        Func<List<TRelatedItem>> relatedItems,
        Func<List<TItem?>> items,
        Func<TRelatedItem, string> detailId,
        Func<TData, TItem> toObj,
        Func<TItem?, TData?> toData,
        Func<TRelatedItem?, TData?> relatedToData)
        where TRepo : class, IRepo<TItem>
        where TItem : UniqueEntity
        where TRelatedItem : UniqueEntity{
        relatedTest();
        var list = relatedItems();
        var r = GetRepo.Instance<TRepo>();
        foreach (var e in list){
            var x = GetRandom.Value<TData>();
            if (x is not null) x.Id = detailId(e);
            r.Add(toObj(x));
        }
        var currencies = items();
        areEqual(list.Count, currencies.Count);
        foreach (var e in list){
            var a = currencies.Find(x => x.Id == detailId(e));
            arePropertiesEqual(toData(a), relatedToData(e));
        }
    }
}