using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party;

public class AddressRepo : Repo<Address, AddressData>, IAddressRepo {
    public AddressRepo(ABCDb? db) : base(db, db?.Addresses) { }
    protected override Address toDomain(AddressData d) => new(d);
    internal override IQueryable<AddressData> addFilter(IQueryable<AddressData> q) {
        var y = CurrentFilter;
        if (string.IsNullOrWhiteSpace(y)) return q;
        return q.Where(
            x => x.Street.Contains(y)
                 || x.Country.Contains(y)
                 || x.Id.Contains(y)
                 || x.City.Contains(y)
                 || x.Region.Contains(y)
                 || x.ZipCode.Contains(y)
        );
    }
}