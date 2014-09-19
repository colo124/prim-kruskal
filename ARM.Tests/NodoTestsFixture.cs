using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARM.Tests
{
    [TestClass]
    public class NodoTestsFixture
    {
        [TestMethod]
        public void DeberiaCrearNodo()
        {
            Nodo n = new Nodo();
            Assert.IsNotNull(n);
        }

        [TestMethod]
        public void DeberiaCrearNodoConNombreYPosicion()
        {
            string nombre = "nodo1";
            int x = 55;
            int y = 33; 
            Nodo n = new Nodo(nombre,x,y);
            Assert.AreEqual(nombre, n.nombre);
            Assert.AreEqual(x, n.x);
            Assert.AreEqual(y, n.y);
        }
        [TestMethod]
        public void DeberiaModificarNombre()
        {
            string nombre = "nodo1";
            int x = 55;
            int y = 33;
            Nodo n = new Nodo(nombre, x, y);
            n.nombre = "pepe";
            Assert.AreEqual(n.nombre, "pepe");
        }

        [TestMethod]
        public void DeberiaModificarPosicion()
        {
            string nombre = "nodo1";
            int x = 55;
            int y = 33;
            Nodo n = new Nodo(nombre, x, y);
            n.x = 34;
            n.y = 55;
            Assert.AreEqual(n.x, 34);
            Assert.AreEqual(n.y, 55);
        }
    }
}
