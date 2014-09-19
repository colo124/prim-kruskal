using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    public class Grafo
    {
        public List<Nodo> Nodos { get; private set; }
        private List<Enlace> Enlaces;

        public Grafo()
        {
            this.Nodos = new List<Nodo>();
            this.Enlaces = new List<Enlace>();
        }

        public bool AgregarNodo(Nodo n)
        {
            if (ExisteNodo(n))
            {
                return false;
            }
            Nodos.Add(n);
            return true;
        }

        public bool AgregarEnlace(Enlace e)
        {

            if (ExisteNodo(e.NodoA) && ExisteNodo(e.NodoB))
            {
                this.Enlaces.Add(e);
                return true;
            }
            return false;

        }

        private bool ExisteNodo(Nodo n)
        {
            foreach (Nodo aux in Nodos)
            {
                if (n.nombre == aux.nombre)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BorrarEnlace(Enlace e)
        {
            return this.Enlaces.Remove(e);
        }


        public Enlace GetEnlace(Nodo n, Nodo f)
        {
            foreach (var e in this.Enlaces)
            {
                if ((e.NodoA.Equals(n) && e.NodoB.Equals(f)) || (e.NodoA.Equals(f) && e.NodoB.Equals(n)) )
                {
                    return e;
                }
                
            }

            return null;
        }

        public List<Enlace> GetEnlaces(Nodo n1)
        {
            var aux = new List<Enlace>();
            foreach (var e in this.Enlaces)
            {
                if (((e.NodoA.Equals(n1)) || (e.NodoB.Equals(n1))) && (!e.NodoA.visitado || !e.NodoB.visitado))
                {
                    aux.Add(e);
                }
            }
            return aux;
        }


        public Nodo GetNodo(string nombre)
        {
            foreach (var nodo in this.Nodos)
            {
                if (nodo.nombre.Equals(nombre))
                {
                    nodo.visitado = true;
                    return nodo;
                }
            }
            return null;
        }

        public Nodo GetNodo()
        {
            var n = this.Nodos.FirstOrDefault(); 
            if(n!=null)
                n.visitado = true;
            return n;
        }

        public bool TodosVisitados()
        {
            foreach (var nodo in this.Nodos)
            {
                if (!nodo.visitado)
                    return false;
            }

            return true;
        }
    }
}