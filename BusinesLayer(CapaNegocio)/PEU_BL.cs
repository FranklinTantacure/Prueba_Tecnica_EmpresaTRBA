using DataBaseLayer_CapaDatos_;
using EntityLayer_CapaEntidad_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLayer_CapaNegocio_
{
    public class PEU_BL
    {
        private readonly Database_DL _database;

        public PEU_BL(Database_DL database_DL)
        {
            _database = database_DL;
         }

        public async Task<List<TRBA>> ListarAsyncNegocio()
        {
            try
            {
                return await _database.ListarDL();
            }
            catch (Exception ex)
            {
                // Manejar la excepción aquí
                await _database.RegistrarErrorAsync(ex.GetType().Name, ex.Message, ex.StackTrace);
                throw new Exception("Error en la capa de negocio al listar: " + ex.Message);
            }
        }

    }
}
