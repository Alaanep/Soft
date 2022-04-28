using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party;

public sealed class AddressesRepo : Repo<Address, AddressData>, IAddressRepo {
    public AddressesRepo(ABCDb? db) : base(db, db?.Addresses) { }
    protected override Address toDomain(AddressData d) => new(d);
    /*internal override IQueryable<AddressData> addFilter(IQueryable<AddressData> q)
    {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q
            : q.Where(
                x => contains(x.Street, y)
                     || contains(x.CountryId, y)
                     || contains(x.Id, y)
                     || contains(x.City, y)
                     || contains(x.Region, y)
                     || contains(x.ZipCode, y)
            );
    }*/

    internal override IQueryable<AddressData> addFilter(IQueryable<AddressData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q
            : q.Where(
                x => x.Street.Contains(y)
                     || x.CountryId.Contains(y)
                     || x.Id.Contains(y)
                     || x.City.Contains(y)
                     || x.Region.Contains(y)
                     || x.ZipCode.Contains(y)
            );
    }
}