using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Diagnostics.CodeAnalysis;

namespace PruebasUnitarias
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class SistemaSCADAMemoriaTest
    {
        [TestMethod]
        public void RegistrarTipoTest1()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Tipo unTipo = Tipo.TipoInvalido();
            unSistema.RegistrarTipo(unTipo);
            CollectionAssert.Contains(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        public void RegistrarTipoTest2()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Tipo unTipo = Tipo.NombreDescripcion("Otro tipo", "Abc, def.");
            unSistema.RegistrarTipo(unTipo);
            CollectionAssert.Contains(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegistrarTipoTest3()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            unSistema.RegistrarTipo(null);
        }

        [TestMethod]
        public void RegistrarComponenteTest1()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Componente unComponente = Dispositivo.DispositivoInvalido();
            unSistema.RegistrarComponente(unComponente);
            CollectionAssert.Contains(unSistema.ComponentesPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest2()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Tipo unTipo = Tipo.TipoInvalido();
            Componente unComponente = Dispositivo.NombreTipoEnUso("Nombre dispositivo", unTipo, true);
            unSistema.RegistrarComponente(unComponente);
            CollectionAssert.Contains(unSistema.ComponentesPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest3()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Instalacion unComponente = Instalacion.InstalacionInvalida();
            unSistema.RegistrarComponente(unComponente);
            CollectionAssert.Contains(unSistema.ComponentesPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest4()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Instalacion unComponente = Instalacion.ConstructorNombre("Generadores");
            unSistema.RegistrarComponente(unComponente);
            CollectionAssert.Contains(unSistema.ComponentesPrimarios, unComponente);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegistrarComponenteTest5()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            unSistema.RegistrarComponente(null);
        }

        [TestMethod]
        public void EliminarTipoTest()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Tipo unTipo = Tipo.NombreDescripcion("Abc", "Descripción");
            unSistema.RegistrarTipo(unTipo);
            unSistema.EliminarTipo(unTipo);
            Assert.AreEqual(0, unSistema.Tipos.Count);
        }

        [TestMethod]
        public void EliminarComponenteTest1()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Componente unComponente = Dispositivo.DispositivoInvalido();
            unSistema.RegistrarComponente(unComponente);
            unSistema.EliminarComponente(unComponente);
            Assert.AreEqual(0, unSistema.Tipos.Count);
        }

        [TestMethod]
        public void EliminarComponenteTest2()
        {
            ISistemaSCADA unSistema = new SistemaSCADAEnMemoria();
            Componente unComponente = Instalacion.ConstructorNombre("Una instalación");
            unSistema.RegistrarComponente(unComponente);
            unSistema.EliminarComponente(unComponente);
            Assert.AreEqual(0, unSistema.Tipos.Count);
        }
    }
}
