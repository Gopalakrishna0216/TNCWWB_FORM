using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;


namespace TNCWWB_Form.Controllers.OrgController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisationInfoController : ControllerBase
    {
        private readonly IOrgService _orgService;
        public OrganisationInfoController(IOrgService orgService)
        {
            _orgService = orgService;
        }

        [HttpGet("Get-Masters")]
        public async Task<IActionResult> GetGlobalMaster()
        {
            var result = await _orgService.GetAllMaster();
            return Ok(result);
        }
        [HttpPost("Add-OrganizationDtls")]
        public async Task<IActionResult> AddOrganizationDtls(OrganizationBindModel model)
        {
            var result = await _orgService.AddOrganizationDtls(model);
            return Ok(result);
        }

        [HttpGet("Get-GetTalukByDis")]
        public async Task<IActionResult> GetTalukByDis([FromQuery] int Id)
        {
            var result = await _orgService.GetTalukByDis(Id);
            return Ok(result);
        }
        [HttpGet("Get-GetMunisPaltyByDis")]
        public async Task<IActionResult> GetMunisPaltyByDis([FromQuery] int Id)
        {
            var result = await _orgService.GetMunipaltyByDis(Id);
            return Ok(result);
        }
        [HttpGet("Get-GetTownPanchayatByDis")]
        public async Task<IActionResult> GetTownPanchayatByDis([FromQuery] int Id)
        {
            var result = await _orgService.GetTownPanchayatByDis(Id);
            return Ok(result);
        }
        [HttpGet("Get-GetCorporationByDis")]
        public async Task<IActionResult> GetCorporationByDis([FromQuery] int Id)
        {
            var result = await _orgService.GetCorporationByDis(Id);
            return Ok(result);
        }
        [HttpGet("Get-GetBlockVPByDis")]
        public async Task<IActionResult> GetBlockVPByDis([FromQuery] int Id)
        {
            var result = await _orgService.GetBlockVPByDis(Id);
            return Ok(result);
        }
    }
}
