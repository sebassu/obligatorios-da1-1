using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Diagnostics.CodeAnalysis;
using Excepciones;

namespace PruebasUnitarias
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class InstalacionTest
    {
        [TestMethod]
        public void InstalacionInvalidaTest()
        {
            Instalacion unaInstalacion = Instalacion.InstalacionInvalida();
            Assert.AreEqual("Instalación inválida.", unaInstalacion.Nombre);
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
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void ConstructorNombreTest3()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("4567");
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void ConstructorNombreTest4()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("/$(%,. &#%");
        }

        [TestMethod]
        public void AgregarDependenciaTest1()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Una instalación");
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unaInstalacion.AgregarDependencia(unDispositivo);
            CollectionAssert.Contains(unaInstalacion.Dependencias, unDispositivo);
        }

        [TestMethod]
        public void AgregarDependenciaTest2()
        {
            Instalacion instalacion1 = Instalacion.ConstructorNombre("Una instalación");
            Instalacion instalacion2 = Instalacion.ConstructorNombre("Otra instalación");
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            instalacion1.AgregarDependencia(instalacion2);
            instalacion2.AgregarDependencia(unDispositivo);
            CollectionAssert.Contains(instalacion1.Dependencias, instalacion2);
            CollectionAssert.Contains(instalacion2.Dependencias, unDispositivo);
            CollectionAssert.DoesNotContain(instalacion1.Dependencias, unDispositivo);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void AgregarDependenciaTest3()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Vientos");
            unaInstalacion.AgregarDependencia(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void AgregarDependenciaTest4()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Vientos");
            unaInstalacion.AgregarDependencia(unaInstalacion);
        }

        [TestMethod]
        public void EliminarDependenciaTest1()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Una instalación");
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaInstalacion.EliminarDependencia(unDispositivo);
            CollectionAssert.DoesNotContain(unaInstalacion.Dependencias, unDispositivo);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void EliminarDependenciaTest2()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Una instalación");
            unaInstalacion.EliminarDependencia(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetEnUsoTest()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Transmisión");
            unaInstalacion.EnUso = false;
        }

        [TestMethod]
        public void ToStringInstalacionTest()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Paneles");
            Assert.AreEqual("Paneles (I)", unaInstalacion.ToString());
        }

        [TestMethod]
        public void ReasignacionDeDependenciasTest()
        {
            Instalacion unaInstalacion = Instalacion.InstalacionInvalida();
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unaInstalacion.AgregarDependencia(unDispositivo);
            CollectionAssert.Contains(unaInstalacion.Dependencias, unDispositivo);
            Instalacion otraInstalacion = Instalacion.InstalacionInvalida();
            otraInstalacion.AgregarDependencia(unDispositivo);
            CollectionAssert.Contains(otraInstalacion.Dependencias, unDispositivo);
            CollectionAssert.DoesNotContain(unaInstalacion.Dependencias, unDispositivo);
        }
    }
}

