using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.Controllers.DocumentDtlsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentUploadController : ControllerBase
    {
        private readonly IDocumentDtls _document;
        public DocumentUploadController(IDocumentDtls document)
        {
            _document = document;
        }

        [HttpPost]
        public async Task<IActionResult> AddDocumentDtls([FromForm] DocumentDtlsBindModel model, long memberId)
        {
            var result = await _document.UploadDocumentDtls(model, memberId);
            return Ok(result);
        }
    }
}
