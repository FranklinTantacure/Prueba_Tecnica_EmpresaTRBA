using BusinesLayer_CapaNegocio_;
using DataBaseLayer_CapaDatos_;
using EntityLayer_CapaEntidad_;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PresentacionLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly PEU_BL _peu_BL;
        private readonly Database_DL _database;

        public WeatherForecastController(PEU_BL peu_BL)
        {
            _peu_BL = peu_BL;
        }

        [HttpGet]
        [Route("ListarTRBA")]
        public async Task<ActionResult<List<TRBA>>> GET()
        {
            try
            {
                var estados = await _peu_BL.ListarAsyncNegocio();
                return Ok(estados);
            }
            catch (Exception ex)
            {
       
                return StatusCode(500, "Se produjo un error al procesar la solicitud GET: " + ex.Message);
            }
        }




    }



}