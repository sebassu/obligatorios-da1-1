using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Diagnostics.CodeAnalysis;
using Excepciones;

namespace PruebasUnitarias
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class TipoTest
    {
        [TestMethod]
        public void TipoInvalidoTest()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            Assert.AreEqual(unTipo.Nombre, "Tipo inválido.");
            Assert.AreEqual(unTipo.Descripcion, "Descripción inválida.");
        }

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
        [ExpectedException(typeof(TipoExcepcion))]
        public void SetNombreTipoTest3()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(TipoExcepcion))]
        public void SetNombreTipoTest4()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "!@.$#%   *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(TipoExcepcion))]
        public void SetNombreTipoTest5()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Nombre = "";
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
        [ExpectedException(typeof(TipoExcepcion))]
        public void SetDescripcionTipoTest3()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "555555";
        }

        [TestMethod]
        [ExpectedException(typeof(TipoExcepcion))]
        public void SetDescripcionTipoTest4()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "!@.$#%   *-/";
        }

        [TestMethod]
        [ExpectedException(typeof(TipoExcepcion))]
        public void SetDescripcionTipoTest5()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unTipo.Descripcion = "";
        }

        [TestMethod]
        public void NombreDescripcionTipoTest1Valido()
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
        [ExpectedException(typeof(TipoExcepcion))]
        public void NombreDescripcionTipoTest2NombreInvalido()
        {
            Tipo unTipo = Tipo.NombreDescripcion("12.$%", "Descripción válida.");
        }

        [TestMethod]
        [ExpectedException(typeof(TipoExcepcion))]
        public void NombreDescripcionTipoTest3DescripcionInvalida()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Nombre válido.", "34.$%");
        }

        [TestMethod]
        [ExpectedException(typeof(TipoExcepcion))]
        public void NombreDescripcionTipoTest4Invalidos()
        {
            Tipo unTipo = Tipo.NombreDescripcion("12.$%", "34.$%");
        }

        [TestMethod]
        public void EqualsTipoTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Assert.AreEqual(unTipo, unTipo);
        }

        [TestMethod]
        public void EqualsTipoTest2()
        {
            Tipo tipo1 = Tipo.NombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Tipo tipo2 = Tipo.NombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Assert.AreNotEqual(tipo1, tipo2);
        }

        [TestMethod]
        public void EqualsTipoTest3()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Variable objetoDeOtroTipo = Variable.VariableInvalida();
            Assert.AreNotEqual(unTipo, objetoDeOtroTipo);
        }

        [TestMethod]
        public void ToStringTipoTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Nombre del tipo", "Desc. del tipo");
            Assert.AreEqual("Nombre del tipo", unTipo.ToString());
        }
    }
}