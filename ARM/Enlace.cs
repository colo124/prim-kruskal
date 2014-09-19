using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    public class Enlace
    {

        public Enlace(int peso, Nodo NodoA, Nodo NodoB)
        {
            this.Peso = peso;
            this.NodoA = NodoA;
            this.NodoB = NodoB;
        }

        public Enlace()
        {
            this.Peso = 0;
            this.NodoA = null;
            this.NodoB = null;
        }
   

        public Nodo NodoB { get; set; }

        public Nodo NodoA { get; set; }

        public int Peso { get; set; }



       
        public Nodo GetNodoNoVisitado()
        {
            if (this.NodoA.visitado)
                return this.NodoB;
            return this.NodoA;
        }
    }

}
