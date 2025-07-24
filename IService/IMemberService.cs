using TNCWWB_Form.Models.NewFolder2;
using TNCWWB_Form.Models.ResponseModel;

namespace TNCWWB_Form.IService
{
    public interface IMemberService
    {
        Task<InsertResponse> AddPersonMemberDetails(MemberPersonalDtlsBindModels model, long orgDetailId);
    }
}
