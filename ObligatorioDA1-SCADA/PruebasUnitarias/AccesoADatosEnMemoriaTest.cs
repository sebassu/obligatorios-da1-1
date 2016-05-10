using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Diagnostics.CodeAnalysis;

namespace PruebasUnitarias
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AccesoADatosEnMemoriaTest
    {
        [TestMethod]
        public void RegistrarTipoTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Tipo unTipo = Tipo.TipoInvalido();
            unSistema.RegistrarTipo(unTipo);
            CollectionAssert.Contains(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        public void RegistrarTipoTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Tipo unTipo = Tipo.NombreDescripcion("Otro tipo", "Abc, def.");
            unSistema.RegistrarTipo(unTipo);
            CollectionAssert.Contains(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegistrarTipoTest3()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            unSistema.RegistrarTipo(null);
        }

        [TestMethod]
        public void RegistrarComponenteTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Componente unComponente = Dispositivo.DispositivoInvalido();
            unSistema.RegistrarComponente(unComponente);
            CollectionAssert.Contains(unSistema.ComponentesPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Tipo unTipo = Tipo.TipoInvalido();
            Componente unComponente = Dispositivo.NombreTipoEnUso("Nombre dispositivo", unTipo, true);
            unSistema.RegistrarComponente(unComponente);
            CollectionAssert.Contains(unSistema.ComponentesPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest3()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Instalacion unComponente = Instalacion.InstalacionInvalida();
            unSistema.RegistrarComponente(unComponente);
            CollectionAssert.Contains(unSistema.ComponentesPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest4()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Instalacion unComponente = Instalacion.ConstructorNombre("Generadores");
            unSistema.RegistrarComponente(unComponente);
            CollectionAssert.Contains(unSistema.ComponentesPrimarios, unComponente);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegistrarComponenteTest5()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            unSistema.RegistrarComponente(null);
        }

        [TestMethod]
        public void EliminarTipoTest()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Tipo unTipo = Tipo.NombreDescripcion("Abc", "Descripción");
            unSistema.RegistrarTipo(unTipo);
            unSistema.EliminarTipo(unTipo);
            Assert.AreEqual(0, unSistema.Tipos.Count);
        }

        [TestMethod]
        public void EliminarComponenteTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Componente unComponente = Dispositivo.DispositivoInvalido();
            unSistema.RegistrarComponente(unComponente);
            unSistema.EliminarComponente(unComponente);
            Assert.AreEqual(0, unSistema.Tipos.Count);
        }

        [TestMethod]
        public void EliminarComponenteTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Componente unComponente = Instalacion.ConstructorNombre("Una instalación");
            unSistema.RegistrarComponente(unComponente);
            unSistema.EliminarComponente(unComponente);
            Assert.AreEqual(0, unSistema.Tipos.Count);
        }

        [TestMethod]
        public void ExistenTiposTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Assert.AreEqual(false, unSistema.ExistenTipos());
        }

        [TestMethod]
        public void ExistenTiposTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            unSistema.RegistrarTipo(Tipo.TipoInvalido());
            Assert.AreEqual(true, unSistema.ExistenTipos());
        }

        [TestMethod]
        public void ExistenDispositivosTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Assert.AreEqual(false, unSistema.ExistenDispositivos());
        }

        [TestMethod]
        public void ExistenDispositivosTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            unSistema.RegistrarComponente(Dispositivo.DispositivoInvalido());
            Assert.AreEqual(true, unSistema.ExistenDispositivos());
        }

        [TestMethod]
        public void ExistenInstalacionesTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            Assert.AreEqual(false, unSistema.ExistenInstalaciones());
        }

        [TestMethod]
        public void ExistenInstalacionesTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosEnMemoria();
            unSistema.RegistrarComponente(Instalacion.InstalacionInvalida());
            Assert.AreEqual(true, unSistema.ExistenInstalaciones());
        }
    }
}
