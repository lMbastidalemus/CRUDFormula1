using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Equipo
    {
        public int IdEquipo { get; set; }
        public string Nombre { get; set; }
        public int NumeroPatrocionadores { get; set; }
        public int NumeroPilotos { get; set; }

        public List<object> Equipos { get; set; }
        public decimal Costo { get; set; }
        public ML.Piloto Piloto { get; set; }
    }
}
