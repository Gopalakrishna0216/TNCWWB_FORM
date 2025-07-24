using Dapper;
using Microsoft.Extensions.Options;
using System.Data;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.Services
{
    public class DocumentDtlsService : IDocumentDtls
    {
        private readonly IDbConnection _connection;
        private readonly string _documentsUpload;
        public DocumentDtlsService(IDbConnection dbConnection, IOptions<DocumentsUpload> options)
        {
            _connection = dbConnection;
            _documentsUpload = options.Value.DocsUpload;
        }

        public async Task<object> UploadDocumentDtls(DocumentDtlsBindModel model, long memberId)
        {
            try
            {
                _connection.Open();
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory());

                string adhaarDoc = model.AdhaarDoc != null ? await AddDocumentsAsync(model.AdhaarDoc, uploadFolder) : null;
                string orgDocs = model.OrgDoc != null ? await AddDocumentsAsync(model.OrgDoc, uploadFolder) : null;
                string bankdocs = model.BankDocs != null ? await AddDocumentsAsync(model.BankDocs, uploadFolder) : null;
                var parameters = new DynamicParameters();
                Guid documentId = Guid.NewGuid();
                parameters.Add("@DocumentId", documentId);
                parameters.Add("@AdhaarDocs", adhaarDoc);
                parameters.Add("@OrgDocs", orgDocs);
                parameters.Add("@BankDocs", bankdocs);
                parameters.Add("@MemberId", memberId);

                var result = await _connection.ExecuteAsync("spTNCWWB_POST_AddDocumentDtls", parameters,
                    commandType: CommandType.StoredProcedure
                    );

                return new UploadResponse
                {
                    Success = true,
                    Message = "Documents Uploaded Successfully"
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        private async Task<string> AddDocumentsAsync(IFormFile file, string UploadFilePath)
        {
            if (file == null || file.Length == 0)
                return null;

            if (!Directory.Exists(UploadFilePath)) Directory.CreateDirectory(UploadFilePath);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(UploadFilePath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return uniqueFileName;
        }
    }
}
