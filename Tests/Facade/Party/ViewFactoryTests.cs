using ABC.Aids;
using ABC.Data;
using ABC.Domain;
using ABC.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABC.Tests.Facade.Party
{
    public abstract class ViewFactoryTests<TFactory, TView, TObj, TData>
         : SealedClassTests<TFactory, BaseViewFactory<TView, TObj, TData>>
         where TFactory : BaseViewFactory<TView, TObj, TData>, new()
         where TView : class, new()
         where TData : UniqueData, new()
         where TObj : UniqueEntity<TData>{
        [TestMethod] public void CreateTest() { }
        [TestMethod]public void CreateViewTest(){
            var v = GetRandom.Value<TView>();
            var o = obj.Create(v);
            areEqualProperties(v, o.Data);
        }
        [TestMethod]
        public void CreateObjectTest()
        {
            var d = GetRandom.Value<TData>();
            var v = obj.Create(toObject(d));
            areEqualProperties(d, v);
        }
        protected abstract TObj toObject(TData d);
    }
}
