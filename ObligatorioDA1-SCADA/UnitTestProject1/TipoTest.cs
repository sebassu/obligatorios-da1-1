using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;

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

        [TestMethod]
        public void setDescripcionTest1()
        {
            Tipo unTipo = new Tipo();
            unTipo.Descripcion = "Es muy bueno";
            Assert.AreEqual("Es muy bueno", unTipo.Descripcion);
        }

        [TestMethod]
        public void setDescripcionTest2()
        {
            Tipo unTipo = new Tipo();
            unTipo.Descripcion = "  Es muy bueno, 123.  ";
            Assert.AreEqual("Es muy bueno, 123.", unTipo.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setDescripcionTest3()
        {
            Tipo unTipo = new Tipo();
            unTipo.Descripcion = "555555";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setDescripcionTest4()
        {
            Tipo unTipo = new Tipo();
            unTipo.Descripcion = "!@.$#%   *-/";
        }
    }
}
