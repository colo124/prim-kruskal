using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    public static class Prim
    {
        public static List<Nodo> Ejecutar(Grafo g){
            List<Nodo> resultado = new List<Nodo>();
            Nodo n1 = g.GetNodo();
            if (n1 != null)
            {
                resultado.Add(n1);
                List<Enlace> enlaces = g.GetEnlaces(n1);
                while (!g.TodosVisitados())
                {
                    var enlaceMenor = EnlaceMenorPeso(enlaces);
                    var n2 = enlaceMenor.GetNodoNoVisitado();
                    n2.visitado = true;
                    enlaces.AddRange(g.GetEnlaces(n2));
                    enlaces = RemoverEnlaces(enlaces);
                    resultado.Add(n2);
                    n1 = n2;
                }
            }
           
            return resultado;
        }



        public static Enlace EnlaceMenorPeso(List<Enlace> enlaces)
        {
            var eMenor = new Enlace(int.MaxValue, new Nodo(), new Nodo());
            foreach (var e in enlaces)
            {
                if (e.Peso < eMenor.Peso)
                {
                    eMenor = e;
                }
            }
            
            return eMenor;
        }

        public static List<Enlace> RemoverEnlaces(List<Enlace> enlaces)
        {
            List<Enlace> enlacesAux = new List<Enlace>() ;
            foreach (var e in enlaces)
            {
                if (!e.NodoA.visitado || !e.NodoB.visitado)
                    enlacesAux.Add(e);
            }
            return enlacesAux;
        }
    }
}
