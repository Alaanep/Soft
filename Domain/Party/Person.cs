using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABC.Data.Party;

namespace ABC.Domain.Party
{
    public class Person
    {
        private const string defaultStr = "Undefined";
        private bool defaultGender = true;

        private DateTime defaulDate=DateTime.MinValue;
        private PersonData data;

        public Person(): this(new PersonData()){}
        public Person(PersonData d) => data = d;
        public string Id=> data?.Id?? defaultStr;
        public string FirstName => data?.FirstName ?? defaultStr;
        public string LastName=>data?.LastName??defaultStr;
        public bool Gender=>data?.Gender?? defaultGender;
        public DateTime Dob => data?.DoB ?? defaulDate;
        public PersonData Data => data;
        public override string ToString() => $"{FirstName} {LastName} {Gender} {Dob}";
    }
}
