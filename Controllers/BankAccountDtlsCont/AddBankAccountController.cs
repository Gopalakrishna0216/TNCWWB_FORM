using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.Controllers.BankAccountDtlsCont
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddBankAccountController : ControllerBase
    {
        private readonly IBankAccDtls _accDtls;
        public AddBankAccountController(IBankAccDtls accDtls)
        {
            _accDtls = accDtls;
        }
        [HttpPost("send-ifsccode")]
        public async Task<IActionResult> AddBankAccount(BankAccountBindModel model, long memberId)
        {
            var result = await _accDtls.AddBankAccountDtls(model, memberId);
            return Ok(result);
        }
        [HttpGet("get-bankDtls-by-ifsc")]
        public async Task<IActionResult> GetBankAccountDtlsByMId(string IfscCode)
        {
            var result = await _accDtls.GetBankAccountDtls(IfscCode);
            return Ok(result);
        }
    }
}
