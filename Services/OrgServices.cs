using Dapper;
using System.Data;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.AccessControl;
using TNCWWB_Form.IService;
using TNCWWB_Form.Models.BindModel;
using TNCWWB_Form.Models.ViewModel;


namespace TNCWWB_Form.Services
{
    public class OrgServices : IOrgService
    {
        private readonly IDbConnection _connection;

        public OrgServices(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<object> GetAllMaster()

        {
            try
            {
                _connection.Open();
                DynamicParameters parameter = new();
                var result = await _connection.QueryMultipleAsync(sql: "[dbo].[sp_Masters]", param: null, commandType: CommandType.StoredProcedure);
                var models = new DropdownMaster
                {
                    TypeOfWork = await result.ReadAsync<MasterViewModel>(),
                    TypeOfCoreSanitaryWorkers = await result.ReadAsync<MasterViewModel>(),
                    OrganizatioType = await result.ReadAsync<MasterViewModel>(),
                    NatureOfJob = await result.ReadAsync<MasterViewModel>(),
                    Community = await result.ReadAsync<MasterViewModel>(),
                    MaritalStatus = await result.ReadAsync<MasterViewModel>(),
                    FamilyRelationship = await result.ReadAsync<MasterViewModel>(),
                    Gender = await result.ReadAsync<MasterViewModel>(),
                    Education = await result.ReadAsync<MasterViewModel>(),
                    DifferentlyAbbled = await result.ReadAsync<MasterViewModel>(),
                    UrbanLocalTypes = await result.ReadAsync<MasterViewModel>(),
                    LocalTypes = await result.ReadAsync<MasterViewModel>(),
                    Taluks = await result.ReadAsync<TaluksViewModel>(),
                    Districts = await result.ReadAsync<DistrictsModel>(),
                    Villages = await result.ReadAsync<VillagesViewModel>(),
                    TownPanchayat = await result.ReadAsync<TownPanchayatModel>(),
                    Corporations = await result.ReadAsync<CorporationViewModel>(),
                    Munispolity = await result.ReadAsync<MunicipalityViewModel>(),

                };
                _connection.Close();
                if (result != null)
                {
                    return new
                    {
                        IsSuccess = true,
                        Results = models
                    };
                }
                return new
                {
                    IsSuccess = false,
                    Results = result
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<OrgInsertResponse> AddOrganizationDtls(OrganizationBindModel model)
        {
            try
            {
                _connection.Open();
                var parameter = new DynamicParameters(model);
                parameter.Add("@OrgDetailId", dbType: DbType.Int64, direction: ParameterDirection.Output);
                var result = await _connection.ExecuteAsync(sql: "[dbo].[spTNCWWB_POST_AddOrganizationDtls]", param: parameter, commandType: CommandType.StoredProcedure);

                long newOrgDetailId = parameter.Get<long>("@OrgDetailId");
                if (result != null)
                {
                    return new OrgInsertResponse
                    {
                        Result = result,
                        OrgDetailId = newOrgDetailId,
                        Message = "Organization details added successfully"
                    };
                }
                return new OrgInsertResponse
                {
                    Result = result,
                    Message = "There is some issue while adding details"
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding organization details", ex);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
        public async Task<object> GetTalukByDis(int Id)
        {
            try
            {
                _connection.Open();
                DynamicParameters parameter = new();
                parameter.Add("@District", Id);
                var result = await _connection.QueryAsync<GetTalukViewModel>(sql: "[dbo].[spTNCWWB_GET_GetTalukByDistrict]", param: parameter, commandType: CommandType.StoredProcedure);
                _connection.Close();
                if (result != null)
                {
                    return new
                    {
                        IsSuccess = true,
                        Results = result
                    };
                }
                return new
                {
                    IsSuccess = false,
                    Results = result
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<object> GetMunipaltyByDis(int Id)
        {
            try
            {
                _connection.Open();
                DynamicParameters parameter = new();
                parameter.Add("@District", Id);
                var result = await _connection.QueryAsync<GetMunicpaltyViewModel>(sql: "[dbo].[spTNCWWB_GET_GetMunicipalityByDistrict]", param: parameter, commandType: CommandType.StoredProcedure);
                _connection.Close();
                if (result != null)
                {
                    return new
                    {
                        IsSuccess = true,
                        Results = result
                    };
                }
                return new
                {
                    IsSuccess = false,
                    Results = result
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<object> GetTownPanchayatByDis(int Id)
        {
            try
            {
                _connection.Open();
                DynamicParameters parameter = new();
                parameter.Add("@District", Id);
                var result = await _connection.QueryAsync<GetTownPanchayatViewModel>(sql: "[dbo].[spTNCWWB_GET_GetTownPanchayatByDistrict]", param: parameter, commandType: CommandType.StoredProcedure);
                _connection.Close();
                if (result != null)
                {
                    return new
                    {
                        IsSuccess = true,
                        Results = result
                    };
                }
                return new
                {
                    IsSuccess = false,
                    Results = result
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<object> GetCorporationByDis(int Id)
        {
            try
            {
                _connection.Open();
                DynamicParameters parameter = new();
                parameter.Add("@District", Id);
                var result = await _connection.QueryAsync<GetCorporationViewModel>(sql: "[dbo].[spTNCWWB_GET_GetCorporationByDistrict]", param: parameter, commandType: CommandType.StoredProcedure);
                _connection.Close();
                if (result != null)
                {
                    return new
                    {
                        IsSuccess = true,
                        Results = result
                    };
                }
                return new
                {
                    IsSuccess = false,
                    Results = result
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<object> GetBlockVPByDis(int Id)
        {
            try
            {
                _connection.Open();
                DynamicParameters parameter = new();
                parameter.Add("@District", Id);
                var result = await _connection.QueryAsync<GetBlockVPViewModel>(sql: "[dbo].[spTNCWWB_GET_GetBlockVPByDistrict]", param: parameter, commandType: CommandType.StoredProcedure);
                _connection.Close();
                if (result != null)
                {
                    return new
                    {
                        IsSuccess = true,
                        Results = result
                    };
                }
                return new
                {
                    IsSuccess = false,
                    Results = result
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
