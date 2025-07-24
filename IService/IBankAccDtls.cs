using TNCWWB_Form.Models.BindModel;
using TNCWWB_Form.Models.ResponseModel;


namespace TNCWWB_Form.IService
{
    public interface IBankAccDtls
    {
        Task<object> AddBankAccountDtls(BankAccountBindModel model, long memberId);
        Task<object> GetBankAccountDtls(string IfscCode);
    }
}
