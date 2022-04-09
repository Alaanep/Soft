using System.ComponentModel;

namespace ABC.Data.Party {
    public enum IsoGender {
        [Description("Not known")] NotKnown=0,
        [Description("Male")] Male =1,
        [Description("Female")] Female =2,
        [Description("Not Applicable")] NotApplicable =9

    }
}
