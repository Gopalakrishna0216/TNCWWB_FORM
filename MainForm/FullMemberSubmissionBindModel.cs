using TNCWWB_Form.Models.BindModel;
using TNCWWB_Form.Models.NewFolder2;

namespace TNCWWB_Form.MainForm
{
    public class FullMemberSubmissionBindModel
    {
        public OrganizationBindModel OrganizationDetails { get; set; }
        public MemberPersonalDtlsBindModels MemberDetails { get; set; }
        public AddressSubmissionDTO AddressDetails { get; set; }
        public FamilyMemberListBindModel FamilyDetails { get; set; }
        public BankAccountBindModel BankDetails { get; set; }
        public DocumentDtlsBindModel DocumentDetails { get; set; }
    }
}
