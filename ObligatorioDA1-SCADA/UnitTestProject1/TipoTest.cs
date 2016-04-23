using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TipoTest
    {
        [TestMethod]
        public void setNombreTest1()
        {
            Tipo unTipo = new Tipo();
            unTipo.Nombre = "Eléctrico";
            Assert.AreEqual("Eléctrico", unTipo.Nombre);
        }

        [TestMethod]
        public void setNombreTest2()
        {
            Tipo unTipo = new Tipo();
            unTipo.Nombre = "  Modelo AX-453  ";
            Assert.AreEqual("Modelo AX-453", unTipo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNombreTest3()
        {
            Tipo unTipo = new Tipo();
            unTipo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNombreTest4()
        {
            Tipo unTipo = new Tipo();
            unTipo.Nombre = "!@.$#%   *-/";
        }
    }
}
