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
        public void SetNombreTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "Eléctrico";
            Assert.AreEqual("Eléctrico", unTipo.Nombre);
        }

        [TestMethod]
        public void SetNombreTest2()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "  Modelo AX-453  ";
            Assert.AreEqual("Modelo AX-453", unTipo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTest3()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTest4()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "!@.$#%   *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTest5()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "";
        }

        [TestMethod]
        public void SetDescripcionTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "Es muy bueno";
            Assert.AreEqual("Es muy bueno", unTipo.Descripcion);
        }

        [TestMethod]
        public void SetDescripcionTest2()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "  Es muy bueno, 123.  ";
            Assert.AreEqual("Es muy bueno, 123.", unTipo.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDescripcionTest3()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "555555";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDescripcionTest4()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "!@.$#%   *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDescripcionTest5()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "";
        }

        [TestMethod]
        public void TipoNombreDescripcionTest1Valido()
        {
            string unNombre = "Sónico";
            string unaDescripcion = "Cilindrico e inalámbrico";
            Tipo tipo1 = Tipo.TipoInvalido();
            tipo1.Nombre = unNombre;
            tipo1.Descripcion = unaDescripcion;
            Tipo tipo2 = Tipo.NombreDescripcion(unNombre, unaDescripcion);
            Assert.AreEqual(tipo1.Nombre, tipo2.Nombre);
            Assert.AreEqual(tipo1.Descripcion, tipo2.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TipoNombreDescripcionTest2NombreInvalido()
        {
            Tipo unTipo = Tipo.NombreDescripcion("12.$%", "Descripción válida.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TipoNombreDescripcionTest3DescripcionInvalida()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Nombre válido.", "34.$%");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TipoNombreDescripcionTest4Invalidos()
        {
            Tipo unTipo = Tipo.NombreDescripcion("12.$%", "34.$%");
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
            Tipo unTipo = Tipo.NombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Assert.AreEqual(unTipo, unTipo);
        }

        [TestMethod]
        public void EqualsTipoTest3()
        {
            Tipo tipo1 = Tipo.NombreDescripcion("ABC", "DEF");
            Tipo tipo2 = Tipo.NombreDescripcion("ABC", "DEF");
            Assert.AreEqual(tipo1, tipo2);
            Assert.AreEqual(tipo2, tipo1);
        }

        [TestMethod]
        public void EqualsTipoTest4()
        {
            Tipo tipo1 = Tipo.NombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Tipo tipo2 = Tipo.NombreDescripcion("Otro nombre", "Otra desc.");
            Assert.AreNotEqual(tipo1, tipo2);
        }

        [TestMethod]
        public void EqualsTipoTest5()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Variable objetoDeOtroTipo = Variable.VariableInvalida();
            Assert.AreNotEqual(unTipo, objetoDeOtroTipo);
        }
    }
}