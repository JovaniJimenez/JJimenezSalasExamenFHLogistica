using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ML
{
    public class Equipo
    {

        public int IdEquipo { get; set; }

        public string Modelo { get; set; }
        public string ClaveInventario { get; set; }

        
                    public int IdMarca { get; set; }

        public Marca Marca { get; set; }
        public TipoEquipo TipoEquipo { get; set; }

        //public Area Area { get; set; }

        public List<object> Equipos { get; set; }

    }
}
