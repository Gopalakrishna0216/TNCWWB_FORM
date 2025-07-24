using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.IService
{
    public interface IDocumentDtls
    {
        Task<object> UploadDocumentDtls(DocumentDtlsBindModel model, long memberId);
    }
}
