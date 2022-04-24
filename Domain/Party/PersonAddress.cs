using ABC.Data.Party;
namespace ABC.Domain.Party;

public sealed class PersonAddress : NamedEntity<PersonAddressData> {
    public PersonAddress() : this(new PersonAddressData()) { }
    public PersonAddress(PersonAddressData d) : base(d) { }
    public string PersonId => getValue(Data?.PersonId);
    public string AddressId => getValue(Data?.AddressId);
    public Person? Person => GetRepo.Instance<IPersonRepo>()?.Get(PersonId);
    public Address? Address => GetRepo.Instance<IAddressRepo>()?.Get(AddressId);

}