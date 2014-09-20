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
                if(!enlace.NodosVisitados()){
                    enlace.NodoA.visitado = true;
                    enlace.NodoB.visitado = true;
                    recorrido.Add(enlace);
                }
            }
            return recorrido;

        }
        
        
    }
}
