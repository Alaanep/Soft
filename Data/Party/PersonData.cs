﻿
namespace ABC.Data.Party
{
    public sealed class PersonData: EntityData
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Dob { get; set; }

    }
}
