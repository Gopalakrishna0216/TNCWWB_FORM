namespace TNCWWB_Form.Models.BindModel
{
    public class BankAccountBindModel
    {
        public Guid BankAccountId { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string BranchName { get; set; }
        public string NameofTheBank { get; set; }
        public string IFSCCode { get; set; }

    }
    public class BankBranchInfo
    {
        public string BANK { get; set; }
        public string BRANCH { get; set; }
    }
}
