namespace TNCWWB_Form.Models.NewFolder2
{
    public class MemberPersonalDtlsBindModels
    {
        public IFormFile PicturePath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HusbandorFatherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? HealthId { get; set; }
        public string Community { get; set; }
        public string MaritalStatus { get; set; }
        public string Education { get; set; }
        public long PhoneNumber { get; set; }
        public long RationCardNo { get; set; }
        public long AdhaarNumber { get; set; }
    }
    public class ProfileImgUpload
    {
        public string ProfileUpload { get; set; }
    }
}
