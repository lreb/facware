using Dapper;
using Microsoft.EntityFrameworkCore;
using NetCore.Contracts.Entity.Dashboards;
using NetCore.Data.Access.DataAccessModels.Dashboards;
using NetCore.Data.Access.DataTransferObjects.Dashboards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;


namespace NetCore.Business.Logic.Repositories.Dashboards
{
    public class StoreProceduresRepository : IStoreProceduresRepository
    {
        DashboardsContext _repositoryContext;
        private string _connectionString;
        public StoreProceduresRepository(DashboardsContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _connectionString = _repositoryContext.Database.GetDbConnection().ConnectionString;
        }


        public IEnumerable<AreasParametersDTO> TestSp()
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var dyanmicParameters = new DynamicParameters();
                IEnumerable<AreasParametersDTO> result = sqlConnection.Query<AreasParametersDTO>(
                    "productionplan.TestSp",
                    null,
                    commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        //public IEnumerable<AreasParametersDTO> TestSp()
        //{
        //    List<AreasParametersDTO> groups = new List<AreasParametersDTO>();
        //    var conn = _repositoryContext.Database.GetDbConnection();
        //    try
        //    {
        //        conn.Open();
        //        using (var command = conn.CreateCommand())
        //        {
        //            command.CommandText = "EXEC productionplan.TestSp";
        //            command.CommandType = System.Data.CommandType.Text;
        //            command.Connection = conn;

        //            DbDataReader reader = command.ExecuteReader();

        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    Console.WriteLine(reader);
        //                    //var row = new AreasParametersDTO {
        //                    //    CustomerId = reader.GetInt64(0),
        //                    //    Name = reader.GetString(1),
        //                    //    Enabled = reader.GetBoolean(3),
        //                    //    Group = reader.GetString(4),
        //                    //    Parameter = reader.GetString(5),
        //                    //    Value = reader.GetString(6)
        //                    //};
        //                    //groups.Add(row);
        //                }
        //            }
        //            reader.Dispose();
        //        }
                
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return groups;
        //    // throw new NotImplementedException();
        //}

        //public IEnumerable<AreasParametersDTO> TestSp()
        //{
        //    //var name = new SqlParameter("@CategoryName", "Test");
        //    //_repositoryContext.Database.ExecuteSqlCommand("EXEC TestSp @CategoryName", name);
        //    _repositoryContext.Database.ExecuteSqlCommand("EXEC TestSp");

        //    // var resultSQL =_repositoryContext.Set<AreasParametersDTO>().FromSql("EXEC TestSp");

        //    using (var conn = new SqlConnection("Data Source=MXCHIM0MIDSQL01;User ID=jabil\\chisqladmin;Password=N3w5q1Adm1n2012;Initial Catalog=JabilMaster2;Integrated Security=True;Timeout=1200;MultipleActiveResultSets=True;"))
        //    {
        //        conn.Open();
        //        IEnumerable<AreasParametersDTO> result = conn.Database.
        //    }
        //}
    }
}
