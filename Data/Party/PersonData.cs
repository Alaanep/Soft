
namespace ABC.Data.Party
{
    public sealed class PersonData: UniqueData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IsoGender Gender { get; set; }
        public DateTime? Dob { get; set; }

    }
}
