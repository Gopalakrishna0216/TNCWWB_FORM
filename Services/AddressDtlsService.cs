using Dapper;
using System.Data;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;

namespace TNCWWB_Form.Services
{
    public class AddressDtlsService : IAddressService
    {
        private readonly IDbConnection _connection;

        public AddressDtlsService(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<object> AddAddressDetails(AddressSubmissionDTO dto, long memberId)
        {
            try
            {
                _connection.Open();
                int rowsAffected = 0;
                if (dto.PermanentAddress != null)
                {
                    dto.PermanentAddress.AddressType = "Permanent";
                    var perParams = new DynamicParameters(dto.PermanentAddress);
                    perParams.Add("@MemberId", memberId);
                    rowsAffected += await _connection.ExecuteAsync("[spTNCWWB_POST_AddAddressesDtls]",
                    param: perParams, commandType: CommandType.StoredProcedure);
                }
                if (!dto.IsSameAddress && dto.TemporaryAddress != null)
                {
                    dto.TemporaryAddress.AddressType = "Temporary";
                    var tempParams = new DynamicParameters(dto.TemporaryAddress);
                    tempParams.Add("@MemberId", memberId);
                    rowsAffected += await _connection.ExecuteAsync("[spTNCWWB_POST_AddAddressesDtls]",
                        tempParams,
                        commandType: CommandType.StoredProcedure
                    );
                }

                return new
                {
                    IsSuccess = rowsAffected > 0,
                    Message = dto.IsSameAddress
                        ? "Permanent and Temporary (same) addresses saved successfully."
                        : "Permanent and Temporary (different) addresses saved successfully."
                };
            }
            catch (Exception ex)
            {

                throw new Exception("Error while adding organization details", ex); ;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
    }
}
