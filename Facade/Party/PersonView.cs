using System.ComponentModel;
using ABC.Data.Party;
using ABC.Domain.Party;


namespace ABC.Facade.Party
{
    public sealed class PersonView: UniqueView
    {
        [DisplayName("First Name")]public string? FirstName { get; set; }
        [DisplayName("Last Name")]public string? LastName { get; set; }
        [DisplayName("Gender")]public IsoGender? Gender { get; set; }
        [DisplayName("Date of birth")]public DateTime? Dob { get; set; }
        [DisplayName("Full Name")] public string? FullName { get; set; }
    }

    public sealed class PersonViewFactory : BaseViewFactory<PersonView, Person, PersonData> {
        protected override Person toEntity(PersonData d) => new(d);

        public override Person Create(PersonView? v) {
            v ??= new PersonView();
            v.Gender ??= IsoGender.NotApplicable;
            return base.Create(v);
        }
        public override PersonView Create(Person? e) {
            var v = base.Create(e);
            v.FullName = e?.ToString();
            v.Gender=e?.Gender;
            return v;
        }
    }
}
