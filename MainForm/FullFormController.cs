using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TNCWWB_Form.MainForm
{
    [Route("api/[controller]")]
    [ApiController]
    public class FullFormController : ControllerBase
    {
        private readonly IFullMemberService _fullMemberService;
        public FullFormController(IFullMemberService fullMember)
        {
            _fullMemberService = fullMember;
        }

        [HttpPost("submit-full-form")]
        public async Task<IActionResult> SubmitFullForm([FromForm] FullMemberSubmissionBindModel model)
        {
            var result = await _fullMemberService.SubmitFullMemberForm(model);
            return Ok(result);
        }

    }
}
