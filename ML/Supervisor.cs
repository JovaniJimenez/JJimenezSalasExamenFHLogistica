using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Supervisor
    {
        public int IdSupervisor { get; set; }

        public string NombreSupervisor { get; set; }

        public Usuario Usuario { get; set; }
        public List<object> Supervisores { get; set; }
    }
}
