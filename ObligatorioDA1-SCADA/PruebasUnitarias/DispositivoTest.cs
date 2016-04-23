using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;

namespace PruebasUnitarias
{
    [TestClass]
    public class DispositivoTest
    {
        [TestMethod]
        public void SetNombreDispositivoTest1()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = "Molino";
            Assert.AreEqual("Molino", unDispositivo.Nombre);
        }

        [TestMethod]
        public void SetNombreDispositivoTest2()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = "  centrifugadora-12  ";
            Assert.AreEqual("centrifugadora-12", unDispositivo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreDispositivoTest3()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreDispositivoTest4()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreDispositivoTest5()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = " !%$@<> . @#$";
        }

        [TestMethod]
        public void SetEnUsoDispositivoTest1()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.EnUso = true;
            Assert.AreEqual(true, unDispositivo.EnUso);
        }

        [TestMethod]
        public void SetEnUsoDispositivoTest2()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.EnUso = false;
            Assert.AreEqual(false, unDispositivo.EnUso);
        }
    }
}
