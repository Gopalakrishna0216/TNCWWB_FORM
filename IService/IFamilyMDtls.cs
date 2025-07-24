using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.IService
{
    public interface IFamilyMDtls
    {
        Task<object> AddFamilyMembers(FamilyMemberListBindModel model, long memberId);
    }
}
