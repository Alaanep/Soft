using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party;

public class AddressRepo : Repo<Address, AddressData>, IAddressRepo {
    public AddressRepo(ABCDb? db) : base(db, db?.Addresses) { }
    protected override Address toDomain(AddressData d) => new(d);
    internal override IQueryable<AddressData> addFilter(IQueryable<AddressData> q)
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
    }
}