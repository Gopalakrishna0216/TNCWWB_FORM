using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.IService
{
    public interface IOrgService
    {
        Task<object> GetTalukByDis(int Id);
        Task<object> GetMunipaltyByDis(int Id);
        Task<object> GetTownPanchayatByDis(int Id);
        Task<object> GetCorporationByDis(int Id);
        Task<object> GetBlockVPByDis(int Id);
        Task<object> GetAllMaster();
        Task<OrgInsertResponse> AddOrganizationDtls(OrganizationBindModel model);
    }
}
