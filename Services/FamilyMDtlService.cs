using Dapper;
using System.Data;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.Services
{
    public class FamilyMDtlService : IFamilyMDtls
    {
        private readonly IDbConnection _connection;
        public FamilyMDtlService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<object> AddFamilyMembers(FamilyMemberListBindModel model, long memberId)
        {
            try
            {
                _connection.Open();
                foreach (var member in model.FamilyMembers)
                {
                    var parameter = new DynamicParameters();
                    parameter.Add("@FMemberId", Guid.NewGuid());
                    parameter.Add("@Name", member.Name);
                    parameter.Add("@Relationship", member.Relationship);
                    parameter.Add("@Gender", member.Gender);
                    parameter.Add("@Age", member.Age);
                    parameter.Add("@Education", member.Education);
                    parameter.Add("@EducationDtls", member.EducationDtls);
                    parameter.Add("@Occupation", member.Occupation);
                    parameter.Add("@DifferentlyAbbled", member.DifferentlyAbbled);
                    parameter.Add("@MemberId", memberId);
                    await _connection.ExecuteAsync("spTNCWWB_POST_AddFamilyMembersDtls", parameter, commandType: CommandType.StoredProcedure);
                    _connection.Close();
                }
                return new
                {
                    Success = true,
                    Message = "Members added successfully"
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
    }
}
