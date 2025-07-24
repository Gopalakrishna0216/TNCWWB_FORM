using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.NewFolder2;

namespace TNCWWB_Form.Controllers.MemberPersDtlsCont
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberPersDtlsControlr : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberPersDtlsControlr(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMemberPerDtls([FromForm] MemberPersonalDtlsBindModels member, long orgDetailId)
        {
            var result = await _memberService.AddPersonMemberDetails(member, orgDetailId);
            return Ok(result);
        }
    }
}
