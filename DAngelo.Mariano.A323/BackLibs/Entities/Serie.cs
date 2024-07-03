using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackLibs.Entities
{
    public class Serie
    {
        private string genero;
        private string nombre;
        private string alumno;

        public Serie() { 

        }
        public Serie(string genero, string nombre, string alumno) { 
            this.genero = genero;
            this.nombre = nombre;
            this.alumno = alumno;
        }

        public string Genero { get => genero; set => genero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Alumno { get => alumno; set => alumno = value; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"genero={genero} |");
            sb.Append($"nombre={nombre} |");
            sb.Append($"alumno={alumno}");
            return sb.ToString();
        }
    }
}
