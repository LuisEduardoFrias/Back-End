using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
//
using ArsAfiliados.Service.SettingsStrings;
//

namespace ArsAfiliados.Persistence.Data
{
    internal class DataAccess
    {


        #region Propiedades

        public readonly SqlConnection _sqlConnnection;

        public readonly SqlCommand _sqlCommnd;

        #endregion


        #region Singletom

        public static DataAccess Instance { get; set; }

        public static DataAccess GetInstance()
        {
            if (Instance == null)
                Instance = new DataAccess();

            return Instance;
        }

        #endregion


        public DataAccess()
        {
            _sqlConnnection = new SqlConnection
            {
                ConnectionString = SettingsStrings.Getinstance().ConnectionString
            };

            _sqlCommnd = new SqlCommand
            {
                Connection = _sqlConnnection
            };
        }


        public DataAccess OpenConnection()
        {
            _sqlConnnection.Open();

            return this;
        }


        public DataAccess UserStoreProcedure(string NameStoreProcedure, SqlParameter[] sqlParameters)
        {
            _sqlCommnd.CommandText = NameStoreProcedure;
            _sqlCommnd.CommandType = System.Data.CommandType.StoredProcedure;

            _sqlCommnd.Parameters.AddRange(sqlParameters);

            return this;
        }


        public DataAccess UserStoreProcedure(string NameStoreProcedure)
        {
            _sqlCommnd.CommandText = NameStoreProcedure;
            _sqlCommnd.CommandType = System.Data.CommandType.StoredProcedure;

            return this;
        }


        public async Task<int> ExecuteNonQueryAsync()   
        {
            var result = await _sqlCommnd.ExecuteNonQueryAsync();

            CloseConnection();

            return result;
        }


        public async Task ExecuteReaderAsync<T>(Func<SqlDataReader, T> Mapper)
        {
            Mapper(await _sqlCommnd.ExecuteReaderAsync());

            CloseConnection();

        }


        private void CloseConnection()
        {
            _sqlConnnection.Close();
            _sqlCommnd.Parameters.Clear();
        }


    }
}
