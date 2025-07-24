namespace TNCWWB_Form.Models.BindModel
{
    public class OrganizationBindModel
    {
        public long? TypeOfWorkId { get; set; }
        public long? TypeOfCoreSanitoryWorkId { get; set; }
        public long? OrganizationTypeId { get; set; }
        public long? NatureOfJobId { get; set; }
        public long? DistrictId { get; set; }
        public long? LocalBodyId { get; set; }
        public long? BlockId { get; set; }
        public long? VillageId { get; set; }
        public long? NoFLocalBId { get; set; }
        public long? CorporationId { get; set; }
        public long? MunicipalityId { get; set; }
        public long? TownPanchayatId { get; set; }
    }
    public class OrgInsertResponse
    {
        public int Result { get; set; }
        public long OrgDetailId { get; set; }
        public string Message { get; set; }

    }
}
