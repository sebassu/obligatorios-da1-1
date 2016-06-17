using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using Excepciones;
using System.Diagnostics.CodeAnalysis;

namespace PruebasUnitarias
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class IncidenteTest
    {
        [TestMethod]
        public void IncidenteInvalidoTest()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            Assert.AreEqual(1, unIncidente.NivelGravedad);
            Assert.AreEqual("Descripción inválida.", unIncidente.Descripcion);
        }

        [TestMethod]
        public void SetFechaIncidenteTest1()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            DateTime unaFecha = DateTime.Now;
            unIncidente.Fecha = unaFecha;
            Assert.AreEqual(unaFecha, unIncidente.Fecha);
        }

        [TestMethod]
        public void SetFechaIncidenteTest2()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            DateTime unaFecha = new DateTime(2014, 10, 20);
            unIncidente.Fecha = unaFecha;
            Assert.AreEqual(unaFecha, unIncidente.Fecha);
        }

        [TestMethod]
        public void SetNivelGravedadIncidenteTest1()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.NivelGravedad = 1;
            Assert.AreEqual((byte)1, unIncidente.NivelGravedad);
        }

        [TestMethod]
        public void SetNivelGravedadIncidenteTest2()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.NivelGravedad = 5;
            Assert.AreEqual((byte)5, unIncidente.NivelGravedad);
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void SetNivelGravedadIncidenteTest3()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.NivelGravedad = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void SetNivelGravedadIncidenteTest4()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.NivelGravedad = 255;
        }

        [TestMethod]
        public void SetDescripcionIncidenteTest1()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.Descripcion = "Accidente";
            Assert.AreEqual("Accidente", unIncidente.Descripcion);
        }

        [TestMethod]
        public void SetDescripcionIncidenteTest2()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.Descripcion = "  Accidente  ";
            Assert.AreEqual("Accidente", unIncidente.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void SetDescripcionIncidenteTest3()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.Descripcion = "555555";
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void SetDescripcionIncidenteTest4()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.Descripcion = "!@.$#%   *-/";
        }

        [TestMethod]
        public void DescripcionFechaNivelDeGravedadTest1()
        {
            DateTime unaFecha = DateTime.Now;
            ElementoSCADA unDispositivo = Dispositivo.DispositivoInvalido();
            Incidente unIncidente = Incidente.IDElementoDescripcionFechaGravedad(unDispositivo.ID, "Accidente", unaFecha, 5);
            Assert.AreEqual("Accidente", unIncidente.Descripcion);
            Assert.AreEqual(unaFecha, unIncidente.Fecha);
            Assert.AreEqual((byte)5, unIncidente.NivelGravedad);
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void DescripcionFechaNivelDeGravedadTest2()
        {
            DateTime unaFecha = DateTime.Now;
            ElementoSCADA unaInstalacion = Instalacion.InstalacionInvalida();
            Incidente unIncidente = Incidente.IDElementoDescripcionFechaGravedad(unaInstalacion.ID, "&$/$&;!", unaFecha, 1);
        }
    }
}
