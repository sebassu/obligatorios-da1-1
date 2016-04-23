using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;

namespace PruebasUnitarias
{
    [TestClass]
    public class DispositivoTest
    {
        [TestMethod]
        public void SetNombreTest1()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = "Molino";
            Assert.AreEqual("Molino", unDispositivo.Nombre);
        }

        [TestMethod]
        public void SetNombreTest2()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = "  centrifugadora-12  ";
            Assert.AreEqual("centrifugadora-12", unDispositivo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTest3()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTest4()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreTest5()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.Nombre = " !%$@<> . @#$";
        }

        [TestMethod]
        public void SetEnUsoTest1()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.EnUso = true;
            Assert.AreEqual(true, unDispositivo.EnUso);
        }

        [TestMethod]
        public void SetEnUsoTest2()
        {
            Dispositivo unDispositivo = new Dispositivo();
            unDispositivo.EnUso = false;
            Assert.AreEqual(false, unDispositivo.EnUso);
        }
    }
}
