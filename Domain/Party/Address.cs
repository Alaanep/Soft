using ABC.Data.Party;

namespace ABC.Domain.Party {
    public sealed class Address: UniqueEntity<AddressData> {
        public Address() : this(new AddressData()) { }
        public Address(AddressData d) : base(d) { }
        public string Street => getValue(Data?.Street);
        public string City => getValue(Data?.City); 
        public string Region => getValue(Data?.Region);
        public string ZipCode => getValue(Data?.ZipCode);
        public string CountryId => getValue(Data?.CountryId);
        public override string ToString() => $"{Street} {City} {ZipCode} {CountryId} {Country?.Name}";
        public Country? Country => GetRepo.Instance<ICountriesRepo>()?.Get(CountryId);
    }
}
