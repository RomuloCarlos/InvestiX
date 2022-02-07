using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Investx.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestidoresController : ControllerBase
    {
        private readonly ILogger<InvestidoresController> _logger;
        private readonly IConfiguration _configuration;

        public InvestidoresController(ILogger<InvestidoresController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

     

        private string GetConnection()
        {
            var connection = _configuration.GetSection("DefaultConnection").
                            GetSection("ConnectionString").Value;
            return connection;
        }

        [HttpDelete]
        public void Delete([FromForm] int id)
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection(enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("DELETE FROM [dbinvestimento].[dbo].[investidores]" + " where idInvestidor = " + @id);
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
        [HttpPost]
        public void Inserir([FromForm] Investidores investidores)
        {
            var enderecoConexao = GetConnection();
            using (var nossaconexao = new SqlConnection(enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("INSERT INTO [dbinvestimento].[dbo].[investidores] VALUES ('" + investidores.nome + "','" + investidores.cpf + "');");

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
        [HttpPut]
        public void Atualizar(Investidores investidor, int id)

        {
            var enderecoConexao = GetConnection();

            using (var nossaconexao = new SqlConnection(enderecoConexao))
            {
                try
                {
                    nossaconexao.Open();
                    nossaconexao.Execute("UPDATE [dbinvestimento].[dbo].[investidores] " + "set nome = '" + investidor.nome + "' where idInvestidor = " + id);
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
        I
    }
}
