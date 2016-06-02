using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Diagnostics.CodeAnalysis;
using Excepciones;

namespace PruebasUnitarias
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AccesoADatosBaseDeDatosTest
    {
        [TestMethod]
        public void RegistrarTipoTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            Tipo unTipo = Tipo.TipoInvalido();
            unSistema.RegistrarTipo(unTipo);
            CollectionAssert.Contains(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        public void RegistrarTipoTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            Tipo unTipo = Tipo.NombreDescripcion("Otro tipo", "Abc, def.");
            unSistema.RegistrarTipo(unTipo);
            CollectionAssert.Contains(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosException))]
        public void RegistrarTipoTest3()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            unSistema.RegistrarTipo(null);
        }

        [TestMethod]
        public void RegistrarComponenteTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unComponente = Dispositivo.DispositivoInvalido();
            unSistema.RegistrarElemento(unComponente);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            Tipo unTipo = Tipo.TipoInvalido();
            IElementoSCADA unComponente = Dispositivo.NombreTipoEnUso("Nombre dispositivo", unTipo, true);
            unSistema.RegistrarElemento(unComponente);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest3()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unComponente = Instalacion.InstalacionInvalida();
            unSistema.RegistrarElemento(unComponente);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unComponente);
        }

        [TestMethod]
        public void RegistrarComponenteTest4()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unComponente = Instalacion.ConstructorNombre("Generadores");
            unSistema.RegistrarElemento(unComponente);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unComponente);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosException))]
        public void RegistrarComponenteTest5()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            unSistema.RegistrarElemento(null);
        }

        [TestMethod]
        public void EliminarTipoTest()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            Tipo unTipo = Tipo.NombreDescripcion("Abc", "Descripción");
            unSistema.RegistrarTipo(unTipo);
            unSistema.EliminarTipo(unTipo);
            CollectionAssert.DoesNotContain(unSistema.Tipos, unTipo);
        }

        [TestMethod]
        public void EliminarComponenteTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unComponente = Dispositivo.DispositivoInvalido();
            unSistema.RegistrarElemento(unComponente);
            unSistema.EliminarElemento(unComponente);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unComponente);
        }

        [TestMethod]
        public void EliminarComponenteTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unComponente = Instalacion.ConstructorNombre("Una instalación");
            unSistema.RegistrarElemento(unComponente);
            unSistema.EliminarElemento(unComponente);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unComponente);
        }

        [TestMethod]
        public void ExistenTiposTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            Assert.IsFalse(unSistema.ExistenTipos());
        }

        [TestMethod]
        public void ExistenTiposTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            unSistema.RegistrarTipo(Tipo.TipoInvalido());
            Assert.IsTrue(unSistema.ExistenTipos());
        }

        [TestMethod]
        public void RegistrarPlantaIndustrialTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unaPlanta = PlantaIndustrial.PlantaIndustrialInvalida();
            unSistema.RegistrarElemento(unaPlanta);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void RegistrarPlantaIndustrialTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unaPlanta = PlantaIndustrial.NombreDireccionCiudad("Planta Industrial 1", "Cuareim 1451", "Montevideo");
            unSistema.RegistrarElemento(unaPlanta);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void RegistrarPlantaIndustrialTest3()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unaPlanta = PlantaIndustrial.NombreDireccionCiudad("  Planta Industrial 1  ", "  Cuareim 1451  ", "  Montevideo  ");
            unSistema.RegistrarElemento(unaPlanta);
            CollectionAssert.Contains(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosException))]
        public void RegistrarPlantaIndustrialTest4()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            unSistema.RegistrarElemento(null);
        }

        [TestMethod]
        public void EliminarPlantaIndustrialTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unaPlanta = PlantaIndustrial.PlantaIndustrialInvalida();
            unSistema.RegistrarElemento(unaPlanta);
            unSistema.EliminarElemento(unaPlanta);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void EliminarPlantaIndustrialTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unaPlanta = PlantaIndustrial.NombreDireccionCiudad("Planta Industrial 1", "Cuareim 1451", "Montevideo");
            unSistema.RegistrarElemento(unaPlanta);
            unSistema.EliminarElemento(unaPlanta);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void EliminarPlantaIndustrialTest3()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unaPlanta = PlantaIndustrial.NombreDireccionCiudad("  Planta Industrial 1  ", "  Cuareim 1451  ", "  Montevideo  ");
            unSistema.RegistrarElemento(unaPlanta);
            unSistema.EliminarElemento(unaPlanta);
            CollectionAssert.DoesNotContain(unSistema.ElementosPrimarios, unaPlanta);
        }

        [TestMethod]
        public void RegistrarIncidenteTest1()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unaPlanta = PlantaIndustrial.PlantaIndustrialInvalida();
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unSistema.RegistrarIncidente(unaPlanta, unIncidente);
            CollectionAssert.Contains(unSistema.Incidentes, unIncidente);
            Assert.AreEqual(unaPlanta.Id, unIncidente.IdElementoAsociado);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosException))]
        public void RegistrarIncidenteTest2()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unSistema.RegistrarIncidente(null, unIncidente);
        }

        [TestMethod]
        [ExpectedException(typeof(AccesoADatosException))]
        public void EliminarIncidenteTest()
        {
            IAccesoADatos unSistema = new AccesoADatosBaseDeDatos();
            IElementoSCADA unaPlanta = PlantaIndustrial.PlantaIndustrialInvalida();
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unSistema.RegistrarIncidente(unaPlanta, unIncidente);
            CollectionAssert.Contains(unSistema.Incidentes, unIncidente);
            unSistema.EliminarIncidente(unIncidente);
            CollectionAssert.DoesNotContain(unIncidente);
        }
    }
}
