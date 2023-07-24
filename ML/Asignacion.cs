using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Asignacion
    {
        public int IdAsignacion { get; set; }


        public DateTime FechaAsignada { get; set; }


        public Usuario Usuario { get; set; }
        public Equipo Equipo { get; set; }

        public string Comentario { get; set; }
        public List<object> Asignaciones { get; set; }
        public Area Area { get; set; }
        public Marca Marca { get; set; }
    }

}
