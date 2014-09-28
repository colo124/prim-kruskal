using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARM
{
    public class Kruskal
    {
        public static List<Enlace> Ejecutar(Grafo g)
        {
            var recorrido = new List<Enlace>();
            var enlaces = g.GetEnlacesDeMenorAMayor();
            foreach (var enlace in enlaces)
            {
                if (!enlace.NodosVisitados())
                {
                    enlace.NodoA.visitado = true;
                    enlace.NodoB.visitado = true;
                    recorrido.Add(enlace);
                }
                else
                {
                    if(!FormaCiclo(g,g.GetEnlacesVisitados(enlace.NodoA), new List<Enlace>(), recorrido, enlace.NodoA, enlace.NodoB))
                    {
                        recorrido.Add(enlace);
                    }
                }
            }
            return recorrido;
        }

        public static bool FormaCiclo(Grafo g, List<Enlace> enlaces, List<Enlace> visitados, List<Enlace> resultado, Nodo nodoA, Nodo nodoB)
        {
            foreach (var e in enlaces)
	        {
		       var otroNodo = e.GetOtroNodo(nodoA);
                
                if(otroNodo == nodoB && resultado.Contains(e))
                    return true;

                visitados.Add(e);
                var enlacesOtroNodo = g.GetEnlacesVisitados(otroNodo);
                BorrarEnlacesVisitados(enlacesOtroNodo, visitados);
                
                if (FormaCiclo(g, enlacesOtroNodo, visitados, resultado, otroNodo, nodoB))
                    return true;
	        } 
            
            return false;
        }

        private static void BorrarEnlacesVisitados(List<Enlace> enlaces, List<Enlace> visitados)
        {
            foreach (var e in visitados)
            {
                enlaces.Remove(e); 
            }
        }
        
    }
}
