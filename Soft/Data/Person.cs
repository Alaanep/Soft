using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soft.Data
{
    public class Person
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public bool? Gender { get; set; }

        public DateTime? Dob { get; set; }
    }
}
