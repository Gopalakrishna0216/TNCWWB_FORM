namespace TNCWWB_Form.Models.ViewModel
{
    public class DropdownMaster
    {
        public IEnumerable<MasterViewModel> TypeOfWork { get; set; }
        public IEnumerable<MasterViewModel> OrganizatioType { get; set; }
        public IEnumerable<MasterViewModel> TypeOfCoreSanitaryWorkers { get; set; }
        public IEnumerable<MasterViewModel> NatureOfJob { get; set; }
        public IEnumerable<MasterViewModel> Community { get; set; }
        public IEnumerable<MasterViewModel> MaritalStatus { get; set; }
        public IEnumerable<MasterViewModel> FamilyRelationship { get; set; }
        public IEnumerable<MasterViewModel> Gender { get; set; }
        public IEnumerable<MasterViewModel> Education { get; set; }
        public IEnumerable<MasterViewModel> DifferentlyAbbled { get; set; }
        public IEnumerable<MasterViewModel>? UrbanLocalTypes { get; set; }
        public IEnumerable<MasterViewModel> LocalTypes { get; set; }
        public IEnumerable<TaluksViewModel> Taluks { get; set; }
        public IEnumerable<DistrictsModel> Districts { get; set; }
        public IEnumerable<VillagesViewModel> Villages { get; set; }
        public IEnumerable<TownPanchayatModel>? TownPanchayat { get; set; }
        public IEnumerable<CorporationViewModel> Corporations { get; set; }
        public IEnumerable<MunicipalityViewModel> Munispolity { get; set; }
    }

    public class MasterViewModel
    {
        public int MasterId { get; set; }
        public string MasterName { get; set; }
        public string MasterType { get; set; }
    }
    public class TaluksViewModel
    {
        public long ID { get; set; }
        public long DID { get; set; }
        public string DName { get; set; }
        public string CName { get; set; }
        public string LocalBodyType { get; set; }
    }
    public class DistrictsModel
    {
        public long DID { get; set; }
        public string DName { get; set; }
    }
    public class VillagesViewModel
    {
        public long ID { get; set; }
        public long DID { get; set; }
        public string BName { get; set; }
        public string VName { get; set; }
    }
    public class TownPanchayatModel
    {
        public long ID { get; set; }
        public long DID { get; set; }
        public string? CName { get; set; }
        public long MasterId { get; set; }
    }
    public class CorporationViewModel
    {
        public long ID { get; set; }
        public long DID { get; set; }
        public string DName { get; set; }
        public string CName { get; set; }
    }
    public class MunicipalityViewModel
    {
        public long ID { get; set; }
        public long DID { get; set; }
        public string CName { get; set; }
    }

}
