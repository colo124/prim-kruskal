using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    public static class Prim
    {
        public static List<Enlace> Ejecutar(Grafo g){
            List<Enlace> resultado = new List<Enlace>();
            Nodo n = g.GetNodo();
            if (n != null)
            {
                n.visitado = true;
                List<Enlace> enlaces = g.GetEnlaces(n);
                while (!g.TodosVisitados())
                {
                    var enlaceMenor = EnlaceMenorPeso(enlaces);
                    n = enlaceMenor.GetNodoNoVisitado();
                    n.visitado = true;
                    enlaces.AddRange(g.GetEnlaces(n));
                    enlaces = RemoverEnlaces(enlaces);
                    resultado.Add(enlaceMenor);
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
