namespace TNCWWB_Form.Models.ViewModel
{
    public class GetTalukViewModel
    {
        public int ID { get; set; }
        public string CName { get; set; }
    }
    public class GetMunicpaltyViewModel
    {
        public int ID { get; set; }
        public string CName { get; set; }
    }
    public class GetTownPanchayatViewModel
    {
        public int ID { get; set; }
        public string CName { get; set; }
    }
    public class GetCorporationViewModel
    {
        public int ID { get; set; }
        public string CName { get; set; }
    }
    public class GetBlockVPViewModel
    {
        public int ID { get; set; }
        public string VName { get; set; }
    }
    public class GetTypeOfWorkViewModel
    {
        public long workTypeID { get; set; }
        public string workTypeName { get; set; }
    }
    public class GetCoreTypeOfWorkSanitaryViewModel
    {
        public long coreWorkTypeID { get; set; }
        public string coWorkerTypeName { get; set; }
    }
}
