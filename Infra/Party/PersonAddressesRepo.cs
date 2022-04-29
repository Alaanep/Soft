using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party;

public sealed class PersonAddressesRepo : Repo<PersonAddress, PersonAddressData>, IPersonAddressesRepo {
    public PersonAddressesRepo(ABCDb? db) : base(db, db?.PersonAddresses) { }
    protected internal override PersonAddress toDomain(PersonAddressData d) => new(d);
    /*internal override IQueryable<PersonAddressData> addFilter(IQueryable<PersonAddressData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q
            : q.Where(
                x => contains(x.Id, y)
                     || contains(x.Code, y)
                     || contains(x.Name, y)
                     || contains(x.PersonId, y)
                     || contains(x.AddressId, y)
            );
    }*/

    internal override IQueryable<PersonAddressData> addFilter(IQueryable<PersonAddressData> q) {
        var y = CurrentFilter;
        return string.IsNullOrWhiteSpace(y)
            ? q
            : q.Where(
                x => x.Id.Contains(y)
                     || x.Code.Contains(y)
                     || x.Name.Contains(y)
                     || x.Description.Contains(y)
                     || x.PersonId.Contains(y)
                     || x.AddressId.Contains(y)
            );
    }
}