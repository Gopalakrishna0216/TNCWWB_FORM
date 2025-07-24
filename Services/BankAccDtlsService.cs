using Dapper;
using System.Data;
using System.Data.Common;
using System.Reflection;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;
using TNCWWB_Form.Models.ResponseModel;

namespace TNCWWB_Form.Services
{
    public class BankAccDtlsService : IBankAccDtls
    {
        private readonly IDbConnection _connecction;
        public BankAccDtlsService(IDbConnection connection)
        {
            _connecction = connection;
        }

        public async Task<object> AddBankAccountDtls(BankAccountBindModel model, long memberId)
        {
            try
            {
                var httpClient = new HttpClient();
                var ifscResponse = await httpClient.GetAsync($"https://ifsc.razorpay.com/{model.IFSCCode}");
                if (!ifscResponse.IsSuccessStatusCode)
                {
                    return new
                    {
                        Success = false,
                        Message = "Invalid Ifsc Code"
                    };
                }
                var IfscInfo = await ifscResponse.Content.ReadFromJsonAsync<BankBranchInfo>();
                model.NameofTheBank = IfscInfo.BANK;
                model.BranchName = IfscInfo.BRANCH;
                _connecction.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@BankAccountId", Guid.NewGuid());
                parameters.Add("@AccountHolderName", model.AccountHolderName);
                parameters.Add("@AccountNumber", model.AccountNumber);
                parameters.Add("@BranchName", model.BranchName);
                parameters.Add("@NameOfTheBank", model.NameofTheBank);
                parameters.Add("@IFSCCode", model.IFSCCode);
                parameters.Add("@MemberId", memberId);
                await _connecction.ExecuteAsync("spTNCWWB_POST_AddBankAccountDetails", parameters, commandType: CommandType.StoredProcedure);
                return new
                {
                    Success = true,
                    Message = "Bank details saved successfully",
                    //BankName = model.NameofTheBank,
                    //BranchName = model.BranchName
                };

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (_connecction.State == ConnectionState.Open)
                    _connecction.Close();
            }
        }

        public async Task<object> GetBankAccountDtls(string IfscCode)
        {
            try
            {
                var httpClient = new HttpClient();
                var ifscResponse = await httpClient.GetAsync($"https://ifsc.razorpay.com/{IfscCode}");
                if (!ifscResponse.IsSuccessStatusCode)
                {
                    return new
                    {
                        success = false,
                        Message = "Invalid Ifsc"
                    };
                }
                var ifscInfo = await ifscResponse.Content.ReadFromJsonAsync<BankBranchInfo>();
                var NameofTheBank = ifscInfo?.BANK;
                var BranchName = ifscInfo?.BRANCH;

                return new
                {
                    IsSuccess = true,
                    TheBankIs = NameofTheBank,
                    TheBranchName = BranchName
                };

            }
            catch (Exception ex)
            {

                return new
                {
                    IsSuccess = false,
                    Message = "Error:" + ex.Message,
                };
            }
        }
    }
}
