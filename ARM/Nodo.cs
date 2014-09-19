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
        public int x { get; set; }
        public int y { get; set; }
        public bool visitado { get; set; }

        public Nodo(string nombre, int x, int y)
        {
            this.nombre = nombre;
            this.x = x;
            this.y = y;
            this.visitado = false;
        }

        public Nodo()
        {
            this.nombre = null;
            this.x = 0;
            this.y = 0;
        }

    }
}
