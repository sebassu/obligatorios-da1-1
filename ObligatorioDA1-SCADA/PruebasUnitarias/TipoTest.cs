using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;

namespace PruebasUnitarias
{
    [TestClass]
    public class TipoTest
    {
        [TestMethod]
        public void SetNombreTipoTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "Eléctrico";
            Assert.AreEqual("Eléctrico", unTipo.Nombre);
        }

        [TestMethod]
        public void SetNombreTipoTest2()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "  Modelo AX-453  ";
            Assert.AreEqual("Modelo AX-453", unTipo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTipoTest3()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTipoTest4()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "!@.$#%   *-/";
        }

        [TestMethod]
        public void SetDescripcionTipoTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "Es muy bueno";
            Assert.AreEqual("Es muy bueno", unTipo.Descripcion);
        }

        [TestMethod]
        public void SetDescripcionTipoTest2()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "  Es muy bueno, 123.  ";
            Assert.AreEqual("Es muy bueno, 123.", unTipo.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDescripcionTipoTest3()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "555555";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDescripcionTipoTest4()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "!@.$#%   *-/";
        }

        [TestMethod]
        public void ConstructorInvalidoTipoTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            Assert.AreEqual(unTipo.Nombre, "Nombre inválido");
            Assert.AreEqual(unTipo.Descripcion, "Descripción inválida");
        }

        [TestMethod]
        public void ConstructorParametrosTipoTest1()
        {
            string unNombre = "Sónico";
            string unaDescripcion = "Cilindrico e inalámbrico";
            Tipo tipo1 = Tipo.TipoInvalido();
            tipo1.Nombre = unNombre;
            tipo1.Descripcion = unaDescripcion;
            Tipo tipo2 = Tipo.ConNombreDescripcion(unNombre, unaDescripcion);
            Assert.AreEqual(tipo1.Nombre, tipo2.Nombre);
            Assert.AreEqual(tipo1.Descripcion, tipo2.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorParametrosTipoTest2()
        {
            Tipo tipo2 = Tipo.ConNombreDescripcion("12.$%", "Descripción válida.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorParametrosTipoTest3()
        {
            Tipo tipo2 = Tipo.ConNombreDescripcion("Nombre válido.", "34.$%");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorParametrosTipoTest4()
        {
            Tipo tipo2 = Tipo.ConNombreDescripcion("12.$%", "34.$%");
        }

        [TestMethod]
        public void EqualsTipoTest1()
        {
            Tipo tipo1 = Tipo.TipoInvalido();
            Tipo tipo2 = Tipo.TipoInvalido();
            Assert.AreEqual(tipo1, tipo2);
        }

        [TestMethod]
        public void EqualsTipoTest2()
        {
            Tipo unTipo = Tipo.ConNombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Assert.AreEqual(unTipo, unTipo);
        }

        [TestMethod]
        public void EqualsTipoTest3()
        {
            Tipo tipo1 = Tipo.ConNombreDescripcion("ABC", "DEF");
            Tipo tipo2 = Tipo.ConNombreDescripcion("ABC", "DEF");
            Assert.AreEqual(tipo1, tipo2);
            Assert.AreEqual(tipo2, tipo1);
        }

        [TestMethod]
        public void EqualsTipoTest4()
        {
            Tipo tipo1 = Tipo.ConNombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Tipo tipo2 = Tipo.ConNombreDescripcion("Otro nombre", "Otra desc.");
            Assert.AreNotEqual(tipo1, tipo2);
            Assert.AreNotEqual(tipo2, tipo1);
        }
    }
}