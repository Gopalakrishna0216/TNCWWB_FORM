using System.Data;
using TNCWWB_Form.IService;
using Microsoft.Extensions.Options;

using TNCWWB_Form.Models.NewFolder2;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using TNCWWB_Form.Models.ResponseModel;
namespace TNCWWB_Form.Services
{
    public class MemberPerDtlsService : IMemberService
    {
        private readonly IDbConnection _connection;
        private readonly string _profileImgUpload;
        public MemberPerDtlsService(IDbConnection connection, IOptions<ProfileImgUpload> options)
        {
            _connection = connection;
            _profileImgUpload = options.Value.ProfileUpload;
        }

        public async Task<InsertResponse> AddPersonMemberDetails(MemberPersonalDtlsBindModels model, long orgDetailId)
        {
            try
            {
                _connection.Open();
                string uniqueFileName = await SaveImageAsync(model.PicturePath, _profileImgUpload);

                var parameters = new DynamicParameters();
                parameters.Add("@PicturePath", uniqueFileName ?? (object)DBNull.Value);
                parameters.Add("@FirstName", model.FirstName);
                parameters.Add("@LastName", model.LastName);
                parameters.Add("@HusbandorFatherName", model.HusbandorFatherName);
                parameters.Add("@DateOfBirth", model.DateOfBirth);
                parameters.Add("@HealthId", model.HealthId);
                parameters.Add("@Community", model.Community);
                parameters.Add("@MaritalStatus", model.MaritalStatus);
                parameters.Add("@Education", model.Education);
                parameters.Add("@PhoneNumber", model.PhoneNumber);
                parameters.Add("@RationCardNo", model.RationCardNo);
                parameters.Add("@AdhaarNumber", model.AdhaarNumber);
                parameters.Add("@OrgDetailId", orgDetailId);

                parameters.Add("@MemberId", dbType: DbType.Int64, direction: ParameterDirection.Output);
                var result = await _connection.ExecuteAsync("spTNCWWB_POST_AddMemberPDtls", parameters, commandType: CommandType.StoredProcedure);

                long newMemberId = parameters.Get<long>("@MemberId");

                return new InsertResponse
                {
                    Success = true,
                    MemberID = newMemberId,
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        private async Task<string> SaveImageAsync(IFormFile file, string uploadFolderPath)
        {
            if (file == null || file.Length == 0)
                return null;

            if (!Directory.Exists(uploadFolderPath))
                Directory.CreateDirectory(uploadFolderPath);

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadFolderPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }

    }
}
