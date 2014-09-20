using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ARM;

namespace prims_kruskal
{

    public class EnlaceVisual : Enlace
    {
        public Point Center1, Center2;

        public EnlaceVisual(int peso, Nodo nodoA, Nodo nodoB)
		{
            this.NodoA = nodoA;
            this.NodoB = nodoB;
            this.Peso = peso;
		}
        
        public void SetCenter(Point p)
        {
            Point s = new Point();
            s.X = p.X + 10;
            s.Y = p.Y + 10;
            Center1 = s;
        }
        public void SetCenter1(Point p)
        {
            Point s = new Point();
            s.X = p.X + 10;
            s.Y = p.Y + 10;
            Center2 = s;
        }
    }
}
