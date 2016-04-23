using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;

namespace UnitTestProject1
{
    [TestClass]
    public class TipoTest
    {
        [TestMethod]
        public void SetNombreTipoTest1()
        {
            Tipo unTipo = new Tipo();
            unTipo.Nombre = "Eléctrico";
            Assert.AreEqual("Eléctrico", unTipo.Nombre);
        }

        [TestMethod]
        public void SetNombreTipoTest2()
        {
            Tipo unTipo = new Tipo();
            unTipo.Nombre = "  Modelo AX-453  ";
            Assert.AreEqual("Modelo AX-453", unTipo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTipoTest3()
        {
            Tipo unTipo = new Tipo();
            unTipo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTipoTest4()
        {
            Tipo unTipo = new Tipo();
            unTipo.Nombre = "!@.$#%   *-/";
        }

        [TestMethod]
        public void SetDescripcionTipoTest1()
        {
            Tipo unTipo = new Tipo();
            unTipo.Descripcion = "Es muy bueno";
            Assert.AreEqual("Es muy bueno", unTipo.Descripcion);
        }

        [TestMethod]
        public void SetDescripcionTipoTest2()
        {
            Tipo unTipo = new Tipo();
            unTipo.Descripcion = "  Es muy bueno, 123.  ";
            Assert.AreEqual("Es muy bueno, 123.", unTipo.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDescripcionTipoTest3()
        {
            Tipo unTipo = new Tipo();
            unTipo.Descripcion = "555555";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDescripcionTipoTest4()
        {
            Tipo unTipo = new Tipo();
            unTipo.Descripcion = "!@.$#%   *-/";
        }
    }
}