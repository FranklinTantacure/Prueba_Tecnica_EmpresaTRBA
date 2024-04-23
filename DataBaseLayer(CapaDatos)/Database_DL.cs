using DataBaseLayer_CapaDatos_.BD;
using EntityLayer_CapaEntidad_;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer_CapaDatos_
{
    public class Database_DL
    {
        private readonly Cadena _cadena;

        public Database_DL(Cadena cadena)
        {
            _cadena = cadena;
         }
        
        public async Task<List<TRBA>> ListarDL()
        {
            List<TRBA> pagos = new List<TRBA>();

            using (SqlConnection connection = new SqlConnection(_cadena.Configbaco()))
            {
                try
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = new SqlCommand("sp_Listar_TRBA", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                TRBA listar = new TRBA();

                                listar.ID = Convert.ToInt32(reader["ID"]);
                                listar.PromocionCodigo = reader["PromocionCodigo"].ToString();
                                listar.Estado = reader["Estado"].ToString();
                                listar.Edad = Convert.ToInt32(reader["Edad"].ToString());
                               

                                pagos.Add(listar);

                            }

                        }
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("Erorr: " + ex.Message);
                }
                finally
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                    }
                }
            }

            return pagos;
        }


        public async Task RegistrarErrorAsync(string exceptionType, string message, string stackTrace)
        {
            using (SqlConnection connection = new SqlConnection(_cadena.Configbaco()))
            {
                await connection.OpenAsync();

                string query = @"INSERT INTO ErrorLog (Timestamp, ExceptionType, Message, StackTrace) 
                         VALUES (@Timestamp, @ExceptionType, @Message, @StackTrace)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Timestamp", DateTime.Now);
                    command.Parameters.AddWithValue("@ExceptionType", exceptionType);
                    command.Parameters.AddWithValue("@Message", message);
                    command.Parameters.AddWithValue("@StackTrace", stackTrace);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }


    }
}
