using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.Controllers.AddressController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddAddressDtlsContr : ControllerBase
    {
        private readonly IAddressService _Service;
        public AddAddressDtlsContr(IAddressService orgService)
        {
            _Service = orgService;
        }

        [HttpPost("add-address")]
        public async Task<IActionResult> AddAddress([FromBody] AddressSubmissionDTO dto, long memberId)
        {
            var result = await _Service.AddAddressDetails(dto, memberId);
            return Ok(result);
        }
    }
}
