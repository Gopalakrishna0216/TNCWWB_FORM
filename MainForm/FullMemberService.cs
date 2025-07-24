using TNCWWB_Form.IService;

namespace TNCWWB_Form.MainForm
{
    public class FullMemberService : IFullMemberService
    {
        private readonly IMemberService _memberService;
        private readonly IFamilyMDtls _familyMDtls;
        private readonly IDocumentDtls _documentDtls;
        private readonly IBankAccDtls _bankAccDtls;
        private readonly IAddressService _addressService;
        private readonly IOrgService _organizationService;
        public FullMemberService(IMemberService member,
                                 IFamilyMDtls familyM,
                                 IDocumentDtls documentDtls,
                                 IBankAccDtls bankAccDtls,
                                 IAddressService address,
                                 IOrgService orgService)
        {
            _memberService = member;
            _familyMDtls = familyM;
            _documentDtls = documentDtls;
            _bankAccDtls = bankAccDtls;
            _addressService = address;
            _organizationService = orgService;
        }
        public async Task<object> SubmitFullMemberForm(FullMemberSubmissionBindModel model)
        {
            try
            {
                var orgResponse = await _organizationService.AddOrganizationDtls(model.OrganizationDetails);
                long orgDetailId = orgResponse.OrgDetailId;

                var response = await _memberService.AddPersonMemberDetails(model.MemberDetails, orgDetailId);
                long memberId = response.MemberID;

                await _addressService.AddAddressDetails(model.AddressDetails, memberId);

                await _familyMDtls.AddFamilyMembers(model.FamilyDetails, memberId);

                await _bankAccDtls.AddBankAccountDtls(model.BankDetails, memberId);

                await _documentDtls.UploadDocumentDtls(model.DocumentDetails, memberId);

                return new
                {
                    Success = true,
                    Message = "All Details Submitted Successfully",
                    memberId = memberId
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
