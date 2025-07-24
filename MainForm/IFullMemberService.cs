namespace TNCWWB_Form.MainForm
{
    public interface IFullMemberService
    {
        Task<object> SubmitFullMemberForm(FullMemberSubmissionBindModel model);
    }
}
