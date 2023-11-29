using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Piloto
    {
        public int IdPiloto { get; set; }
        public string NombrePiloto { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nacionalidad { get; set; }
        public List<object> Pilotos { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
