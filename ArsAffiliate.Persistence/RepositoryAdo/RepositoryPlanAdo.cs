using ArsAffiliate.Domain.Dtos.Plan;
using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Persistence.Intefaces;
using ArsAffiliate.Service.EntensionMethods;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryAdo
{
    public class RepositoryPlanAdo : IRepository<Plan>
    {

        #region Singletom

        private static RepositoryPlanAdo Instance;

        public static RepositoryPlanAdo GetInstance()
        {
            if (Instance == null)
                Instance = new RepositoryPlanAdo();

            return Instance;
        }

        #endregion

        private RepositoryPlanAdo()
        {

        }

        public async Task<List<ShowPlanDto>> Show()
        {
            List<ShowPlanDto> planes = new();

            try
            {
                await DataAccess
                .GetInstance()
                .OpenConnection()
                .UserStoreProcedure("ShowPlans")
                .ExecuteReaderAsync(async (reader) =>
               {
                   while (await reader.ReadAsync())
                   {
                       planes.Add(new ShowPlanDto
                       {
                           Id = reader["Id"].ToInt(),
                           PlanName = reader["PlanName"].ToString(),
                           CoverageAmount = reader["CoverageAmount"].ToDecimal(),
                           RegistrationDate = reader["RegistrationDate"].ToDateTime(),
                           Status = reader["Status"].ToBool(),
                       });
                   }
               });
            }
            catch
            {
                planes.Add(new ShowPlanDto { IsError = true });
            }

            return planes;
        }


        public async Task<List<ShowPlanDto>> ShowAllWhereStatusTrue()
        {
            List<ShowPlanDto> planes = new();

            try
            {
                await DataAccess
                .GetInstance()
                .OpenConnection()
                .UserStoreProcedure("ShowPlans")
                .ExecuteReaderAsync(async (reader) =>
                {
                    while (await reader.ReadAsync())
                    {
                        if (reader["Status"].ToBool() == true)
                            planes.Add(new ShowPlanDto
                            {
                                Id = reader["Id"].ToInt(),
                                PlanName = reader["PlanName"].ToString(),
                                CoverageAmount = reader["CoverageAmount"].ToDecimal(),
                                RegistrationDate = reader["RegistrationDate"].ToDateTime(),
                                Status = reader["Status"].ToBool(),
                            });
                    }
                });
            }
            catch
            {
                planes.Add(new ShowPlanDto { IsError = true });
            }

            return planes;
        }


        public async Task<bool> Create(CreatePlanDto entityDto)
        {
            bool resul = false;

            try
            {
                resul = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("CreatePlan", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@PlanName",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.PlanName
                    },
                    new SqlParameter
                    {
                        ParameterName = "@CoverageAmount",
                        DbType = System.Data.DbType.Decimal,
                        Value = entityDto.CoverageAmount
                    },
                    new SqlParameter
                    {
                        ParameterName = "@RegistrationDate",
                        DbType = System.Data.DbType.DateTime,
                        Value = entityDto.RegistrationDate
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Status",
                        DbType = System.Data.DbType.Boolean,
                        Value = entityDto.Status
                    }

                }).ExecuteNonQueryAsync() != -1;
            }
            catch
            {

            }

            return resul;
        }

        public async Task<bool> Update(UpdatePlanDto entityDto)
        {
            bool result = false;

            try
            {
                result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("UpdatePlan", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        DbType = System.Data.DbType.Int32,
                        Value = entityDto.Id
                    },
                    new SqlParameter
                    {
                        ParameterName = "@PlanName",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.PlanName
                    },
                    new SqlParameter
                    {
                        ParameterName = "@CoverageAmount",
                        DbType = System.Data.DbType.Decimal,
                        Value = entityDto.CoverageAmount
                    },
                    new SqlParameter
                    {
                        ParameterName = "@RegistrationDate",
                        DbType = System.Data.DbType.DateTime,
                        Value = entityDto.RegistrationDate
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Status",
                        DbType = System.Data.DbType.Boolean,
                        Value = entityDto.Status
                    }

                }).ExecuteNonQueryAsync() != -1;

            }
            catch { }


            return result;
        }

        public async Task<ShowPlanDto> Search(string identity)
        {
            ShowPlanDto planesDto = new();

            try
            {
                await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("SearchPlan", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@PlanName",
                        DbType = System.Data.DbType.String,
                        Value = identity
                    }

                }).ExecuteReaderAsync(async (reader) =>
                {
                    while (await reader.ReadAsync())
                    {
                        planesDto = new ShowPlanDto
                        {
                            Id = reader["Id"].ToInt(),
                            PlanName = reader["PlanName"].ToString(),
                            CoverageAmount = reader["CoverageAmount"].ToDecimal(),
                            RegistrationDate = reader["RegistrationDate"].ToDateTime(),
                            Status = reader["Status"].ToBool(),
                        };
                    }
                });
            }
            catch
            {
                planesDto = new ShowPlanDto() { IsError = true };
            }

            return planesDto;
        }

        public async Task<bool> ChangeStatus(string identity, bool status)
        {
            bool result = false;

            try
            {
                result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("ChangeStatusPlan", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        DbType = System.Data.DbType.Int32,
                        Value = identity.ToInt()
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Status",
                        DbType = System.Data.DbType.Boolean,
                        Value = status
}

                }).ExecuteNonQueryAsync() != -1;
            }
            catch { }


            return result;
        }

        IQueryable<Plan> IRepository<Plan>.Show()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Create(Plan entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Plan entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
