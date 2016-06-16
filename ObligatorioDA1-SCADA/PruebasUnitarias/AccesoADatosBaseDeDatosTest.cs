using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using Excepciones;
using Persistencia;
using System.Diagnostics.CodeAnalysis;
using System;

namespace PruebasUnitarias
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AccesoADatosBaseDeDatosTest
    {

        private IAccesoADatos unSistema;

        [TestInitialize]
        public void CrearObjetoAccesoADatos()
        {
            unSistema = new AccesoADatosBaseDeDatos("name=ContextoSCADAPrueba");
        }

        [TestCleanup]
        public void BorrarBaseDeDatos()
        {
            unSistema.EliminarDatos();
        }

        [TestMethod]
        public void RegistrarTipoTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            unSistema.RegistrarTipo(unTipo);
            CollectionAssert.Contains(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        public void RegistrarTipoTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Otro tipo", "Abc, def.");
            unSistema.RegistrarTipo(unTipo);
            CollectionAssert.Contains(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosExcepcion))]
        public void RegistrarTipoTest3()
        {
            unSistema.RegistrarTipo(null);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosExcepcion))]
        public void RegistrarTipoTest4()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Otro tipo", "Abc, def.");
            unSistema.RegistrarTipo(unTipo);
            unSistema.RegistrarTipo(unTipo);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosExcepcion))]
        public void RegistrarTipoTest5()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Nombre igual.", "Descripción");
            Tipo otroTipo = Tipo.NombreDescripcion("Nombre igual.", "distinta.");
            unSistema.RegistrarTipo(unTipo);
            unSistema.RegistrarTipo(otroTipo);
        }

        [TestMethod]
        public void RegistrarComponenteTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            ElementoSCADA unComponente = Dispositivo.NombreTipo("Nombre dispositivo", unTipo);
            unSistema.RegistrarTipo(unTipo);
            unSistema.RegistrarElemento(unComponente);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest2()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            ElementoSCADA unComponente = Dispositivo.NombreTipo("Nombre dispositivo", unTipo);
            unSistema.RegistrarTipo(unTipo);
            unSistema.RegistrarElemento(unComponente);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unComponente);
            int posicionComponente = unSistema.ElementosPrimarios.IndexOf(unComponente);
            Dispositivo dispositivoRecuperado = (Dispositivo)unSistema.ElementosPrimarios[posicionComponente];
            Assert.AreEqual(unTipo, dispositivoRecuperado.Tipo);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosExcepcion))]
        public void RegistrarComponenteTest3()
        {
            ElementoSCADA unComponente = Instalacion.ConstructorNombre("Generadores");
            unSistema.RegistrarElemento(unComponente);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosExcepcion))]
        public void RegistrarComponenteTest4()
        {
            unSistema.RegistrarElemento(null);
        }

        [TestMethod]
        public void EliminarTipoTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Abc", "Descripción");
            unSistema.RegistrarTipo(unTipo);
            unSistema.EliminarTipo(unTipo);
            CollectionAssert.DoesNotContain(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        public void EliminarComponenteTest1()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            ElementoSCADA unComponente = Dispositivo.NombreTipo("Nombre dispositivo", unTipo);
            unSistema.RegistrarTipo(unTipo);
            unSistema.RegistrarElemento(unComponente);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unComponente);
            unSistema.EliminarElemento(unComponente);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unComponente);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosExcepcion))]
        public void EliminarComponenteTest2()
        {
            ElementoSCADA unComponente = Instalacion.ConstructorNombre("Una instalación");
            unSistema.EliminarElemento(unComponente);
        }

        [TestMethod]
        public void ExistenTiposTest1()
        {
            Assert.IsFalse(unSistema.ExistenTipos());
        }

        [TestMethod]
        public void ExistenTiposTest2()
        {
            unSistema.RegistrarTipo(Tipo.TipoInvalido());
            Assert.IsTrue(unSistema.ExistenTipos());
        }

        [TestMethod]
        public void RegistrarPlantaIndustrialTest1()
        {
            ElementoSCADA unaPlanta = PlantaIndustrial.PlantaIndustrialInvalida();
            unSistema.RegistrarElemento(unaPlanta);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void RegistrarPlantaIndustrialTest2()
        {
            ElementoSCADA unaPlanta = PlantaIndustrial.NombreDireccionCiudad("Planta Industrial 1", "Cuareim 1451", "Montevideo");
            unSistema.RegistrarElemento(unaPlanta);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void RegistrarPlantaIndustrialTest3()
        {
            ElementoSCADA unaPlanta = PlantaIndustrial.NombreDireccionCiudad("  Planta Industrial 1  ", "  Cuareim 1451  ", "  Montevideo  ");
            unSistema.RegistrarElemento(unaPlanta);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void RegistrarPlantaIndustrialTest4()
        {
            ElementoSCADA plantaPrimerNivel = PlantaIndustrial.PlantaIndustrialInvalida();
            ElementoSCADA plantaHija = PlantaIndustrial.PlantaIndustrialInvalida();
            ElementoSCADA instalacionHija = Instalacion.InstalacionInvalida();
            ElementoSCADA unDispositivo = Dispositivo.DispositivoInvalido();
            instalacionHija.AgregarDependencia(unDispositivo);
            plantaPrimerNivel.AgregarDependencia(instalacionHija);
            plantaPrimerNivel.AgregarDependencia(plantaHija);
            unSistema.RegistrarElemento(plantaPrimerNivel);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, plantaPrimerNivel);
            int posicionPlanta = unSistema.ElementosPrimarios.IndexOf(plantaPrimerNivel);
            ElementoSCADA plantaRecuperada = (PlantaIndustrial)unSistema.ElementosPrimarios[posicionPlanta];
            CollectionAssert.AreEqual(plantaPrimerNivel.Dependencias, plantaRecuperada.Dependencias);
        }

        [TestMethod]
        public void RegistrarPlantaIndustrialTest5()
        {
            ElementoSCADA plantaPrimerNivel = PlantaIndustrial.PlantaIndustrialInvalida();
            ElementoSCADA instalacionHija = Instalacion.InstalacionInvalida();
            ElementoSCADA unDispositivo = Dispositivo.DispositivoInvalido();
            instalacionHija.AgregarDependencia(unDispositivo);
            plantaPrimerNivel.AgregarDependencia(instalacionHija);
            unSistema.RegistrarElemento(plantaPrimerNivel);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, plantaPrimerNivel);
            int posicionPlanta = unSistema.ElementosPrimarios.IndexOf(plantaPrimerNivel);
            ElementoSCADA plantaRecuperada = (PlantaIndustrial)unSistema.ElementosPrimarios[posicionPlanta];
            CollectionAssert.AreEqual(plantaPrimerNivel.Dependencias, plantaRecuperada.Dependencias);
            int posicionInstalacion = plantaRecuperada.Dependencias.IndexOf(instalacionHija);
            ElementoSCADA instalacionRecuperada = (Instalacion)plantaRecuperada.Dependencias[posicionInstalacion];
            CollectionAssert.AreEqual(instalacionRecuperada.Dependencias, instalacionHija.Dependencias);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosExcepcion))]
        public void RegistrarPlantaIndustrialTest6()
        {
            unSistema.RegistrarElemento(null);
        }

        [TestMethod]
        public void EliminarPlantaIndustrialTest1()
        {
            ElementoSCADA unaPlanta = PlantaIndustrial.PlantaIndustrialInvalida();
            unSistema.RegistrarElemento(unaPlanta);
            unSistema.EliminarElemento(unaPlanta);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void EliminarPlantaIndustrialTest2()
        {
            ElementoSCADA unaPlanta = PlantaIndustrial.NombreDireccionCiudad("Planta Industrial 1", "Cuareim 1451", "Montevideo");
            unSistema.RegistrarElemento(unaPlanta);
            unSistema.EliminarElemento(unaPlanta);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void EliminarPlantaIndustrialTest3()
        {
            ElementoSCADA unaPlanta = PlantaIndustrial.NombreDireccionCiudad("  Planta Industrial 1  ", "  Cuareim 1451  ", "  Montevideo  ");
            unSistema.RegistrarElemento(unaPlanta);
            unSistema.EliminarElemento(unaPlanta);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void RegistrarIncidenteTest1()
        {
            PlantaIndustrial unaPlanta = PlantaIndustrial.PlantaIndustrialInvalida();
            Incidente unIncidente = Incidente.IDElementoDescripcionFechaGravedad(unaPlanta.ID, "Descripción", DateTime.Now, 5);
            unSistema.RegistrarIncidente(unIncidente);
            CollectionAssert.Contains(unSistema.Incidentes, unIncidente);
            Assert.AreEqual(unaPlanta.ID, unIncidente.IdElementoAsociado);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosExcepcion))]
        public void RegistrarIncidenteTest2()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unSistema.RegistrarIncidente(unIncidente);
        }
    }
}
