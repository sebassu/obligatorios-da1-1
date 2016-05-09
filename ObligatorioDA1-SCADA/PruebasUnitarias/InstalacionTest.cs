using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Diagnostics.CodeAnalysis;

namespace PruebasUnitarias
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class InstalacionTest
    {
        [TestMethod]
        public void InstalacionInvalidaTest()
        {
            Instalacion unaInstalacion = Instalacion.InstalacionInvalida();
            Assert.AreEqual("Nombre inválido.", unaInstalacion.Nombre);
            Assert.AreEqual(0, unaInstalacion.Variables.Count);
            Assert.AreEqual(0, unaInstalacion.Dependencias.Count);
        }

        [TestMethod]
        public void ConstructorNombreTest1()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Transmisión");
            Assert.AreEqual("Transmisión", unaInstalacion.Nombre);
            Assert.AreEqual(0, unaInstalacion.Variables.Count);
            Assert.AreEqual(0, unaInstalacion.Dependencias.Count);
        }

        [TestMethod]
        public void ConstructorNombreTest2()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre(" Transmisión- :123 ");
            Assert.AreEqual("Transmisión- :123", unaInstalacion.Nombre);
            Assert.AreEqual(0, unaInstalacion.Variables.Count);
            Assert.AreEqual(0, unaInstalacion.Dependencias.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorNombreTest3()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("4567");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorNombreTest4()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("/$(%,. &#%");
        }

        [TestMethod]
        public void AgregarComponenteTest1()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Una instalación");
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unaInstalacion.AgregarComponente(unDispositivo);
            CollectionAssert.Contains(unaInstalacion.Dependencias, unDispositivo);
        }

        [TestMethod]
        public void AgregarComponenteTest2()
        {
            Instalacion instalacion1 = Instalacion.ConstructorNombre("Una instalación");
            Instalacion instalacion2 = Instalacion.ConstructorNombre("Otra instalación");
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            instalacion1.AgregarComponente(instalacion2);
            instalacion2.AgregarComponente(unDispositivo);
            CollectionAssert.Contains(instalacion1.Dependencias, instalacion2);
            CollectionAssert.Contains(instalacion2.Dependencias, unDispositivo);
            CollectionAssert.DoesNotContain(instalacion1.Dependencias, unDispositivo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AgregarComponenteTest3()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Vientos");
            unaInstalacion.AgregarComponente(null);
        }
    }
}

