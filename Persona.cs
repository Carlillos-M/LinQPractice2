using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursoLinQ2
{
    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public bool Soltero { get; set; }
        public DateTime FechaIngreso { get; set; }
        public List<string> Telefonos = new List<string>();
        public int EmpresaId { get; set; }
    }
}