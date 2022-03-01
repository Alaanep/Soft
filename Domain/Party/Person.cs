using ABC.Data.Party;

namespace ABC.Domain.Party
{
    public class Person : Entity<PersonData>

    {
    private const string defaultStr = "Undefined";
    private bool defaultGender = true;
    private DateTime defaultDate = DateTime.MinValue;

    public Person() : this(new PersonData()) { }
    public Person(PersonData d): base(d){}
    public string Id => Data?.Id ?? defaultStr;
    public string FirstName => Data?.FirstName ?? defaultStr;
    public string LastName => Data?.LastName ?? defaultStr;
    public bool Gender => Data?.Gender ?? defaultGender;
    public DateTime Dob => Data?.Dob ?? defaultDate;
    public override string ToString() => $"{FirstName} {LastName} {Gender} {Dob}";
    }
}
