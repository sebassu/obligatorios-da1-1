using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class IncidenteTest
    {
        [TestMethod]
        public void IncidenteInvalidoTest()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            Assert.AreEqual(default(DateTime), unIncidente.Fecha);
            Assert.AreEqual(0, unIncidente.NivelGravedad);
            Assert.AreEqual("Descripción inválidad.", unIncidente.Descripcion);
        }

        [TestMethod]
        public void SetFechaDispositivoTest1()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            DateTime unaFecha = DateTime.Now;
            unIncidente.Fecha = unaFecha;
            Assert.AreEqual(unaFecha, unIncidente.Fecha);
        }

        [TestMethod]
        public void SetFechaDispositivoTest2()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            DateTime unaFecha = new DateTime(2014, 10, 20);
            unIncidente.Fecha = unaFecha;
            Assert.AreEqual(unaFecha, unIncidente.Fecha);
        }

        [TestMethod]
        public void SetNivelGravedadTest1()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.NivelGravedad = 1;
            Assert.AreEqual(1, unIncidente.NivelGravedad);
        }

        [TestMethod]
        public void SetNivelGravedadTest2()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.NivelGravedad = 5;
            Assert.AreEqual(5, unIncidente.NivelGravedad);
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void SetNivelGravedadTest3()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.NivelGravedad = -99999;
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void SetNivelGravedadTest4()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.NivelGravedad = 99999;
        }

        [TestMethod]
        public void SetDescripcionTest1()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.Descripcion = "Accidente";
            Assert.AreEqual("Accidente", unIncidente.Descripcion);
        }

        [TestMethod]
        public void SetDescripcionTest2()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.Descripcion = "  Accidente  ";
            Assert.AreEqual("  Accidente  ", unIncidente.Descripcion);
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void SetDescripcionTest3()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.Descripcion = "555555";
        }

        [TestMethod]
        [ExpectedException(typeof(IncidenteExcepcion))]
        public void SetDescripcionTest4()
        {
            Incidente unIncidente = Incidente.IncidenteInvalido();
            unIncidente.Descripcion = "!@.$#%   *-/";
        }
    }
}
