namespace TNCWWB_Form.Models.BindModel
{
    public class AddressDtlsBindModel
    {
        public long MemberId { get; set; }
        public string? DoorNo { get; set; }
        public string? StreetName { get; set; }
        public string? VillageOrCity { get; set; }
        public long Taluk { get; set; }
        public long District { get; set; }
        public long PinCode { get; set; }
        public string? AddressType { get; set; }
    }
    public class AddressSubmissionDTO
    {
        public AddressDtlsBindModel? PermanentAddress { get; set; }
        public AddressDtlsBindModel? TemporaryAddress { get; set; }
        public bool IsSameAddress { get; set; }
    }
}
