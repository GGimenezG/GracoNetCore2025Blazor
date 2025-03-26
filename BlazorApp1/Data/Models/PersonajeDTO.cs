using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class PersonajeDTO 
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public int salud { get; set; }
        public int energia { get; set; }
        public int fuerza { get; set; }
        public int inteligencia { get; set; }
        public int agilidad { get; set; }
        public int nivel { get; set; }
        public int defensa { get; set; }
        public int? tipoId { get; set; }
    }
}