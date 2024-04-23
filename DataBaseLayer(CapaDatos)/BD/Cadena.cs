using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer_CapaDatos_.BD
{
    public class Cadena
    {
        private readonly IConfiguration _configuration;

        public Cadena(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Configbaco()
        {
            string connectionString = "";

            if (_configuration["MODO_BACO"] == "0")
            {
                connectionString = _configuration.GetConnectionString("DESBACOS");
            }

            return connectionString;
        }
    }
}
