using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;

namespace PruebasUnitarias
{
    [TestClass]
    public class TipoTest
    {
        [TestMethod]
        public void TipoInvalidoTest()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            Assert.AreEqual(unTipo.Nombre, "Nombre inválido.");
            Assert.AreEqual(unTipo.Descripcion, "Descripción inválida.");
        }

        [TestMethod]
        public void setNombreTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "Eléctrico";
            Assert.AreEqual("Eléctrico", unTipo.Nombre);
        }

        [TestMethod]
        public void setNombreTest2()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "  Modelo AX-453  ";
            Assert.AreEqual("Modelo AX-453", unTipo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNombreTest3()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNombreTest4()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "!@.$#%   *-/";
        }

        [TestMethod]
        public void setDescripcionTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "Es muy bueno";
            Assert.AreEqual("Es muy bueno", unTipo.Descripcion);
        }

        [TestMethod]
        public void setDescripcionTest2()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "  Es muy bueno, 123.  ";
            Assert.AreEqual("Es muy bueno, 123.", unTipo.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setDescripcionTest3()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "555555";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setDescripcionTest4()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "!@.$#%   *-/";
        }

        [TestMethod]
        public void TipoNombreDescripcionTest1Valido()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Tipo A", "Una cierta descripción.");
            Assert.AreEqual(unTipo.Nombre, "Tipo A");
            Assert.AreEqual(unTipo.Descripcion, "Una cierta descripción.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TipoNombreDescripcionTest2NombreInvalido()
        {
            Tipo unTipo = Tipo.NombreDescripcion("1234", "Una cierta descripción.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TipoNombreDescripcionTest3DescripcionInvalida()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Tipo A", "^#&$ *%,.");
        }
    }
}
