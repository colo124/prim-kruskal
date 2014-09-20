using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ARM.Tests
{
    [TestClass]
    public class GrafoTestsFixture
    {
        [TestMethod]
        public void DeberiaCrearUnGrafo()
        {
            Grafo g = new Grafo();

            Assert.IsNotNull(g);

        }
        [TestMethod]
        public void DeberiaAgregarNodo()
        {
            Grafo g = new Grafo();
            Nodo n = new Nodo("colo", 23, 55);
            bool cargo = g.AgregarNodo(n);
            Assert.IsTrue(cargo);
        }
        [TestMethod]
        public void NoDeberiaAgregarNodosConElMismoNombre()
        {
            Grafo g = new Grafo();
            Nodo n = new Nodo("colo", 23, 55);
            Nodo b = new Nodo("colo", 34, 56);
            bool cargo = g.AgregarNodo(n);
            cargo = g.AgregarNodo(b);
            Assert.IsFalse(cargo);
        }
        [TestMethod]
        public void DeberiaAgregarEnlace()
        {
            Grafo g = new Grafo();
            Nodo n = new Nodo("colo", 23, 55);
            Nodo b = new Nodo("pepe", 34, 56);

            Enlace e = new Enlace(55, n, b);
            g.AgregarNodo(n);
            g.AgregarNodo(b);

            bool cargo = g.AgregarEnlace(e);
            Assert.IsTrue(cargo);
        }
        [TestMethod]
        public void NoDeberiaAgregarEnlaceSiNoExisteElNodo()
        {
            Grafo g = new Grafo();
            Nodo n = new Nodo("colo", 23, 55);
            Nodo b = new Nodo("colo", 34, 56);

            Enlace e = new Enlace(55, n, b);

            bool cargo = g.AgregarEnlace(e);
            Assert.IsFalse(cargo);
        }
        [TestMethod]
        public void DeberiaBorrarEnlace()
        {
            Grafo g = new Grafo();
            Nodo n = new Nodo("colo", 23, 55);
            Nodo b = new Nodo("colo1", 34, 56);

            Enlace e = new Enlace(55, n, b);
            g.AgregarNodo(n);
            g.AgregarNodo(b);
             g.AgregarEnlace(e);
             bool borro = g.BorrarEnlace(e);
             Assert.IsTrue(borro);
        }

        [TestMethod]
        public void DeberiaDevolverNodoYMarcarloComoVisitado()
        {
            Grafo g = new Grafo();
            Nodo n1 = new Nodo("n1", 23, 55);
            Nodo n2 = new Nodo("n2", 34, 56);

            Enlace e = new Enlace(55, n1, n2);
            g.AgregarNodo(n1);
            g.AgregarNodo(n2);
            g.AgregarEnlace(e);
            var n3 = g.GetNodo("n1");
            Assert.AreEqual(n3, n1);
            Assert.IsTrue(n3.visitado);
        }

        [TestMethod]
        public void DeberiaDevolverNullSiElNodoNoExiste()
        {
            Grafo g = new Grafo();
            Nodo n1 = new Nodo("n1", 23, 55);
            Nodo n2 = new Nodo("n2", 34, 56);

            Enlace e = new Enlace(55, n1, n2);
            g.AgregarNodo(n1);
            g.AgregarNodo(n2);
            g.AgregarEnlace(e);
            var n3 = g.GetNodo("n8");
            Assert.IsNull(n3);
        }

        [TestMethod]
        public void DeberiaDevolverNodoPorDefectoSiNoPasoParametros()
        {
            Grafo g = new Grafo();
            Nodo n1 = new Nodo("n1", 23, 55);
            Nodo n2 = new Nodo("n2", 34, 56);

            Enlace e = new Enlace(55, n1, n2);
            g.AgregarNodo(n1);
            g.AgregarNodo(n2);
            g.AgregarEnlace(e);
            var n3 = g.GetNodo();
            Assert.AreEqual(n3,n1);
            Assert.IsTrue(n3.visitado);
        }

        [TestMethod]
        public void DeberiaDevolverEnlace()
        {
            Grafo g = new Grafo();
            Nodo n = new Nodo("colo", 23, 55);
            Nodo b = new Nodo("colo1", 34, 56);

            Enlace e = new Enlace(55, n, b);
            g.AgregarNodo(n);
            g.AgregarNodo(b);
            g.AgregarEnlace(e);
            Enlace e1 = g.GetEnlace(n, b);
            Assert.AreEqual(e, e1);
        }
        
        [TestMethod]
        public void DeberiaDevolverLaListaDeEnlacesDe1NodoSiNoSeVisitoElOtroNodo()
        {
            Grafo g = new Grafo();

            var n1 = new Nodo("N1", 23, 45);
            var n2 = new Nodo("N2", 34, 56);
            var n3 = new Nodo("N3", 23, 55);
            var n4 = new Nodo("N4", 23, 67);
            var n5 = new Nodo("N5", 34, 68);
            var n6 = new Nodo("N6", 14, 63);

            g.AgregarNodo(n1);
            g.AgregarNodo(n2);
            g.AgregarNodo(n3);
            g.AgregarNodo(n4);
            g.AgregarNodo(n5);
            g.AgregarNodo(n6);

            var e1 = new Enlace(2, n1, n2);
            var e2 = new Enlace(7, n2, n3);
            var e3 = new Enlace(3, n1, n3);
            var e4 = new Enlace(20, n1, n6);
            var e5 = new Enlace(5, n3, n6);
            var e6 = new Enlace(9, n1, n5);
            var e7 = new Enlace(3, n5, n4);

            g.AgregarEnlace(e1);
            g.AgregarEnlace(e2);
            g.AgregarEnlace(e3);
            g.AgregarEnlace(e4);
            g.AgregarEnlace(e5);
            g.AgregarEnlace(e6);
            g.AgregarEnlace(e7);
            n1.visitado = true;
            n2.visitado = true;
            List<Enlace> enlaces = g.GetEnlaces(n1);
            Assert.IsFalse(enlaces.Contains(e1)); // Esta visitado
            Assert.IsTrue(enlaces.Contains(e3));
            Assert.IsTrue(enlaces.Contains(e4));
            Assert.IsTrue(enlaces.Contains(e6));
            Assert.IsFalse(enlaces.Contains(e7));
            Assert.IsFalse(enlaces.Contains(e2));
            Assert.IsFalse(enlaces.Contains(e5));
        }

        [TestMethod]
        public void DeberiaRetornarTruePorqueTodosLosNodosFueronVisitados()
        {
            Grafo g = new Grafo();
            Nodo n1 = new Nodo("n1", 23, 55);
            Nodo n2 = new Nodo("n2", 34, 56);

            Enlace e = new Enlace(55, n1, n2);
            g.AgregarNodo(n1);
            g.AgregarNodo(n2);
            n1.visitado = true;
            n2.visitado = true;
            bool visitados = g.TodosVisitados();
            Assert.IsTrue(visitados);
        }

        [TestMethod]
        public void DeberiaDevolverLaListaDeEnlacesOrdenada()
        {
            Grafo g = new Grafo();

            var n1 = new Nodo("N1", 23, 45);
            var n2 = new Nodo("N2", 34, 56);
            var n3 = new Nodo("N3", 23, 55);
            var n4 = new Nodo("N4", 23, 67);
            var n5 = new Nodo("N5", 34, 68);
            var n6 = new Nodo("N6", 14, 63);

            g.AgregarNodo(n1);
            g.AgregarNodo(n2);
            g.AgregarNodo(n3);
            g.AgregarNodo(n4);
            g.AgregarNodo(n5);
            g.AgregarNodo(n6);

            var e1 = new Enlace(2, n1, n2);
            var e2 = new Enlace(7, n2, n3);
            var e3 = new Enlace(3, n1, n3);
            var e4 = new Enlace(20, n1, n6);
            var e5 = new Enlace(5, n3, n6);
            var e6 = new Enlace(9, n1, n5);
            var e7 = new Enlace(3, n5, n4);

            g.AgregarEnlace(e1);
            g.AgregarEnlace(e2);
            g.AgregarEnlace(e3);
            g.AgregarEnlace(e4);
            g.AgregarEnlace(e5);
            g.AgregarEnlace(e6);
            g.AgregarEnlace(e7);

            List<Enlace> enlaces = g.GetEnlacesDeMenorAMayor();

            Assert.AreEqual(2, enlaces[0].Peso);
            Assert.AreEqual(3, enlaces[1].Peso);
            Assert.AreEqual(3, enlaces[2].Peso);
            Assert.AreEqual(5, enlaces[3].Peso);
            Assert.AreEqual(7, enlaces[4].Peso);
            Assert.AreEqual(9, enlaces[5].Peso);
            Assert.AreEqual(20, enlaces[6].Peso);
        }
    }
}
