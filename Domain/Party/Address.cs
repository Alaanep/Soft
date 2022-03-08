using ABC.Data.Party;

namespace ABC.Domain.Party {
    public sealed class Address: Entity<AddressData> {
        public Address() : this(new AddressData()) { }
        public Address(AddressData d) : base(d) { }
        public string Street => Data?.Street ?? defaultStr;
        public string City => Data?.City ?? defaultStr;
        public string Region => Data?.Region ?? defaultStr;
        public string ZipCode => Data?.ZipCode ?? defaultStr;
        public string Country => Data?.Country ?? defaultStr;
        public override string ToString() => $"{Street} {City} {ZipCode} {Country}";
    }
}
