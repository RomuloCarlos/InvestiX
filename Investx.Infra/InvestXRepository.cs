using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Investx.Infra
{
    public class InvestXRepository
    {
  
       
        public List<Investidores> RecuperarInvestidores()
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection((string)enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    var investidores = nossaconexao.Query<Investidores>("SELECT * FROM [dbinvestimento].[dbo].[investidores]").AsList();
                    
                    return investidores;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    nossaconexao.Close();
                }
            }
        }

        private object GetConnection()
        {
            var connection = "Data Source = LENOVO - PC\\SQLEXPRESS;Database=dbinvestimento;user id = sa; password=12345;";
            return connection;
        }
    }
}
