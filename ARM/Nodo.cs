using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    public class Nodo
    {
        public string nombre { get; set; }
        public bool visitado { get; set; }

        public Nodo(string nombre)
        {
            this.nombre = nombre;
            this.visitado = false;
        }

        public Nodo()
        {
            this.nombre = null;
        }
    }
}
