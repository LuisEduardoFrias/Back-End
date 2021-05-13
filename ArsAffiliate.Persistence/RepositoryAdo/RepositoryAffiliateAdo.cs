using ArsAffiliate.Domain.Dtos.Affiliate;
using ArsAffiliate.Domain.Dtos.Plan;
using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Persistence.Intefaces;
using ArsAffiliate.Service.EntensionMethods;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryAdo
{
    public class RepositoryAffiliateAdo : IRepository<CreateAffiliateDto, UpdateAffiliateDto, ShowAffiliateDto>
    {

        #region Singletom

        public static RepositoryAffiliateAdo Instantice { get; set; }

        public static RepositoryAffiliateAdo GetInstance()
        {
            if (Instantice == null)
                Instantice = new RepositoryAffiliateAdo();

            return Instantice;
        }

        #endregion

        private RepositoryAffiliateAdo()
        {

        }

        public async Task<List<ShowAffiliateDto>> Show()
        {
            List<ShowAffiliateDto> afiliados = new List<ShowAffiliateDto>();

            try
            {
                await DataAccess
                .GetInstance()
                .OpenConnection()
                .UserStoreProcedure("ShowAffiliate")
                .ExecuteReaderAsync(async (reader) =>
                {
                    while (await reader.ReadAsync())
                    {
                        afiliados.Add(new ShowAffiliateDto
                        {
                            Id = reader["Id"].ToInt(),
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Date = reader["Date"].ToDateTime(),
                            Nacionality = reader["Nacionality"].ToString(),
                            Sex = reader["Sex"].Tochar(),
                            IdentificationCard = reader["IdentificationCard"].ToString(),
                            SocialSecurityNumber = reader["SocialSecurityNumber"].ToString(),
                            RegistrationDate = reader["RegistrationDate"].ToDateTime(),
                            AmountConsumed = reader["AmountConsumed"].ToDecimal(),
                            Status = reader["Status"].ToBool(),
                            PlanId = reader["PlanId"].ToInt(),
                            Plan = new ShowPlanDto
                            {
                                PlanName = reader["PlanName"].ToString(),
                                CoverageAmount = reader["CoverageAmount"].ToInt(),
                                RegistrationDate = reader["RegistrationDate"].ToDateTime(),
                                Status = reader["Status"].ToBool()
                            }
                        });
                    }
                });
            }
            catch
            {
                afiliados.Add(new ShowAffiliateDto { IsError = true });
            }

            return afiliados;
        }

        public async Task<bool> Create(CreateAffiliateDto entityDto)
        {
            bool result = false;

            try
            {
                result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("Createaffiliate", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Name",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.Name
                    },
                    new SqlParameter
                    {
                        ParameterName = "@LastName",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.LastName
                    },
                    new SqlParameter
                    {
                        ParameterName = "@IdentificationCard",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.IdentificationCard
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Date",
                        DbType = System.Data.DbType.DateTime,
                        Value = entityDto.Date
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Nacionality",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.Nacionality
                    },new SqlParameter
                    {
                        ParameterName = "@Sex",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.Sex
                    },new SqlParameter
                    {
                        ParameterName = "@SocialSecurityNumber",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.SocialSecurityNumber
                    },new SqlParameter
                    {
                        ParameterName = "@RegistrationDate",
                        DbType = System.Data.DbType.DateTime,
                        Value = entityDto.RegistrationDate
                    },new SqlParameter
                    {
                        ParameterName = "@AmountConsumed",
                        DbType = System.Data.DbType.Decimal,
                        Value = entityDto.AmountConsumed
                    },new SqlParameter
                    {
                        ParameterName = "@Status",
                        DbType = System.Data.DbType.Boolean,
                        Value = entityDto.Status
                    },new SqlParameter
                    {
                        ParameterName = "@PlanId",
                        DbType = System.Data.DbType.Int32,
                        Value = entityDto.PlanId
                    }

                }).ExecuteNonQueryAsync() != -1;
            }
            catch (System.Exception) { }

            return result;

        }

        public async Task<bool> Update(UpdateAffiliateDto entityDto)
        {
            bool result = false;

            try
            {
                result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("UpdateAffiliate", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        DbType = System.Data.DbType.Int32,
                        Value = entityDto.Id
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Name",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.Name
                    },
                    new SqlParameter
                    {
                        ParameterName = "@LastName",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.LastName
                    },
                    new SqlParameter
                    {
                        ParameterName = "@IdentificationCard",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.IdentificationCard
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Date",
                        DbType = System.Data.DbType.DateTime,
                        Value = entityDto.Date
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Nacionality",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.Nacionality
                    },new SqlParameter
                    {
                        ParameterName = "@Sex",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.Sex
                    },new SqlParameter
                    {
                        ParameterName = "@SocialSecurityNumber",
                        DbType = System.Data.DbType.String,
                        Value = entityDto.SocialSecurityNumber
                    },new SqlParameter
                    {
                        ParameterName = "@RegistrationDate",
                        DbType = System.Data.DbType.DateTime,
                        Value = entityDto.RegistrationDate
                    },new SqlParameter
                    {
                        ParameterName = "@AmountConsumed",
                        DbType = System.Data.DbType.Decimal,
                        Value = entityDto.AmountConsumed
                    },new SqlParameter
                    {
                        ParameterName = "@Status",
                        DbType = System.Data.DbType.Boolean,
                        Value = entityDto.Status
                    },new SqlParameter
                    {
                        ParameterName = "@PlanId",
                        DbType = System.Data.DbType.Int32,
                        Value = entityDto.PlanId
                    }

                }).ExecuteNonQueryAsync() != -1;
            }
            catch { }

            return result;

        }

        public async Task<bool> UpdateAmountAffiliate(string IdentificationCard, decimal NewAmountConsumed)
        {
            bool result = false;

            try
            {
                result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("UpdateAmountAffiliate", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Id",
                        DbType = System.Data.DbType.Int32,
                        Value = IdentificationCard
                    },
                    new SqlParameter
                    {
                        ParameterName = "@AmountConsumed",
                        DbType = System.Data.DbType.Decimal,
                        Value = NewAmountConsumed
                    }

                }).ExecuteNonQueryAsync() != -1;
            }
            catch { }

            return result;

        }

        public async Task<ShowAffiliateDto> Search(string identity)
        {
            ShowAffiliateDto afiliado = new ShowAffiliateDto();

            try
            {
                await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("SearchAffiliate", new SqlParameter[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@IdentificationCard",
                        DbType = System.Data.DbType.String,
                        Value = identity
                    }

                }).ExecuteReaderAsync(async (reader) =>
                {
                    while (await reader.ReadAsync())
                    {
                        afiliado = new ShowAffiliateDto
                        {
                            Id = reader["Id"].ToInt(),
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Date = reader["Date"].ToDateTime(),
                            Nacionality = reader["Nacionality"].ToString(),
                            Sex = reader["Sex"].Tochar(),
                            IdentificationCard = reader["IdentificationCard"].ToString(),
                            SocialSecurityNumber = reader["SocialSecurityNumber"].ToString(),
                            RegistrationDate = reader["RegistrationDate"].ToDateTime(),
                            AmountConsumed = reader["AmountConsumed"].ToDecimal(),
                            Status = reader["Status"].ToBool(),
                            PlanId = reader["PlanId"].ToInt(),
                            Plan = new ShowPlanDto
                            {
                                PlanName = reader["PlanName"].ToString(),
                                CoverageAmount = reader["CoverageAmount"].ToInt(),
                                RegistrationDate = reader["RegistrationDate"].ToDateTime(),
                                Status = reader["Status"].ToBool()
                            }
                        };
                    }
                });


            }
            catch
            {
                afiliado.IsError = true;
            }

            return afiliado;
        }

        public async Task<bool> ChangeStatus(string identity, bool status)
        {
            bool result = false;

            try
            {
                result = await DataAccess.GetInstance().OpenConnection().UserStoreProcedure("ChangeStatusAffiliate", new SqlParameter[]
                {
                   new SqlParameter
                   {
                       ParameterName = "@IdentificationCard",
                       DbType = System.Data.DbType.String,
                       Value = identity
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

    }
}
