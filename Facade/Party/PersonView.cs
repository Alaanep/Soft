using System.ComponentModel;


namespace ABC.Facade.Party
{
    public class PersonView: BaseView
    {
        [DisplayName("First Name")]public string? FirstName { get; set; }
        [DisplayName("Last Name")]public string? LastName { get; set; }
        [DisplayName("Gender")]public bool? Gender { get; set; }
        [DisplayName("Date of birth")]public DateTime? Dob { get; set; }
        [DisplayName("Full Name")] public string? FullName { get; set; }
    }
}
