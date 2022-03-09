using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party;

public class AddressRepo : Repo<Address, AddressData>, IAddressRepo {
    public AddressRepo(ABCDb? db) : base(db, db?.Addresses) { }
    protected override Address toDomain(AddressData d) => new(d);
}