﻿using ABC.Data.Party;
using ABC.Domain.Party;

namespace ABC.Infra.Party;

public class PersonAddressesRepo : Repo<PersonAddress, PersonAddressData>, IPersonAddressRepo {
    public PersonAddressesRepo(ABCDb? db) : base(db, db?.PersonAddresses) { }
    protected override PersonAddress toDomain(PersonAddressData d) => new(d);
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
                x => contains(x.Id, y)
                     || x.Code.Contains(y)
                     || x.Name.Contains(y)
                     || x.PersonId.Contains(y)
                     || x.AddressId.Contains(y)
            );
    }
}