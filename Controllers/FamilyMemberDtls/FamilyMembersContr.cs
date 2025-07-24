using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.Controllers.FamilyMemberDtls
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersContr : ControllerBase
    {
        private readonly IFamilyMDtls _family;
        public FamilyMembersContr(IFamilyMDtls family)
        {
            _family = family;
        }

        [HttpPost]
        public async Task<IActionResult> AddFamilyMemberDtls(FamilyMemberListBindModel model, long memberId)
        {
            var result = await _family.AddFamilyMembers(model, memberId);
            return Ok(result);
        }
    }
}
