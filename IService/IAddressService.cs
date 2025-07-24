using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.IService
{
    public interface IAddressService
    {
        Task<object> AddAddressDetails(AddressSubmissionDTO dto, long memberId);
    }
}
