using ABC.Data.Party;
using ABC.Domain.Party;


namespace ABC.Facade.Party
{
    public class PersonViewFactory
    {
        public Person Create(PersonView v) => new Person(new PersonData
        {
            Id = v.Id,
            FirstName = v.FirstName,
            LastName = v.LastName,
            Gender = v.Gender,
            Dob = v.Dob
        });
            
        

        public PersonView Create(Person o) => new PersonView()
        {
            Id = o.Id,
            FirstName = o.FirstName,
            LastName = o.LastName,
            Gender = o.Gender,
            Dob = o.Dob,
            FullName = o.ToString()
            
        };
    }
}
