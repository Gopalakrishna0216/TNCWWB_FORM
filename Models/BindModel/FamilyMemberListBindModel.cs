namespace TNCWWB_Form.Models.BindModel
{
    public class FamilyMemberListBindModel
    {
        public Guid FMemberId { get; set; }
        //public long MemberId { get; set; }
        public List<FamilyMemberBindModel>? FamilyMembers { get; set; }
    }

    public class FamilyMemberBindModel
    {
        public string? Name { get; set; }
        public string? Relationship { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? Education { get; set; }
        public string? EducationDtls { get; set; }
        public string? Occupation { get; set; }
        public string? DifferentlyAbbled { get; set; }
    }
}
