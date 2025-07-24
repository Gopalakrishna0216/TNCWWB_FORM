namespace TNCWWB_Form.Models.BindModel
{
    public class DocumentDtlsBindModel
    {
        public IFormFile? AdhaarDoc { get; set; }
        public IFormFile? OrgDoc { get; set; }
        public IFormFile? BankDocs { get; set; }
    }
    public class DocumentsUpload
    {
        public string? DocsUpload { get; set; }
    }

    public class UploadResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
