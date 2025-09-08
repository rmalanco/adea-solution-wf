using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adea_solution_wf.Models
{
    public class Caja
    {
        public int Caja_Id { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Ubicacion_Id { get; set; } = string.Empty;
        public int ExpedientesCount { get; set; } = 0;
    }

    public class CreateCajaRequest
    {
        public string Estado { get; set; } = string.Empty;
        public string Ubicacion_Id { get; set; } = string.Empty;
    }

    public class UpdateCajaRequest
    {
        public int Caja_Id { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Ubicacion_Id { get; set; } = string.Empty;
    }
}
