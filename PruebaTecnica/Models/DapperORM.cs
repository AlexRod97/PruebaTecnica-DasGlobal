using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace PruebaTecnica.Models
{
    public static class DapperORM
    {
        private static string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=DasGlobalDB;Trusted_Connection=True;persist security info=True;";

        public static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                conn.Execute(procedureName, param, commandType: CommandType.StoredProcedure);

                conn.Close();
            }
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                return (T)Convert.ChangeType(conn.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                return conn.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

    }
}