using Dominio;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PruebasUnitarias
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ElementoSCADATest
    {
        [TestMethod]
        public void SetNombreElementoSCADATest1()
        {
            ElementoSCADA unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "Molino";
            Assert.AreEqual("Molino", unDispositivo.Nombre);
        }

        [TestMethod]
        public void SetNombreElementoSCADATest2()
        {
            ElementoSCADA unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "  centrifugadora-12  ";
            Assert.AreEqual("centrifugadora-12", unDispositivo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetNombreElementoSCADATest3()
        {
            ElementoSCADA unaInstalacion = Instalacion.InstalacionInvalida();
            unaInstalacion.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetNombreElementoSCADATest4()
        {
            ElementoSCADA unaInstalacion = Instalacion.InstalacionInvalida();
            unaInstalacion.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetNombreElementoSCADATest5()
        {
            ElementoSCADA unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Nombre = " !%$@<> . @#$";
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest1()
        {
            ElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 0, 10);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.SetValorActual(99);
            Assert.AreEqual(1, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest2Anidadas()
        {
            ElementoSCADA unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            ElementoSCADA instalacion1 = Instalacion.ConstructorNombre("Instalación hija");
            ElementoSCADA instalacion2 = Instalacion.ConstructorNombre("Otro hijo independiente");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            ElementoSCADA unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 0, 10);
            unDispositivo.AgregarVariable(unaVariable);
            instalacion1.AgregarDependencia(unDispositivo);
            unaPlantaIndustrial.AgregarDependencia(instalacion1);
            unaPlantaIndustrial.AgregarDependencia(instalacion2);
            unaVariable.SetValorActual(-300);
            Assert.AreEqual(1, instalacion1.CantidadAlarmasActivas);
            Assert.AreEqual(1, unaPlantaIndustrial.CantidadAlarmasActivas);
            Assert.AreEqual(0, instalacion2.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest3DentroDelRango()
        {
            ElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            ElementoSCADA unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -30, 200);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.SetValorActual(3000);
            unaVariable.SetValorActual(50);
            Assert.AreEqual(0, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest1()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", -20M, -10M, 20M, 40M);
            ElementoSCADA unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            ElementoSCADA unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(unaVariable);
            unaPlantaIndustrial.AgregarDependencia(unDispositivo);
            unaVariable.SetValorActual(30);
            Assert.AreEqual(1, unaPlantaIndustrial.CantidadAdvertenciasActivas);
            Assert.AreEqual(0, unaPlantaIndustrial.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest2Anidadas()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", -20M, -10M, 20M, 40M);
            ElementoSCADA unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            ElementoSCADA instalacion1 = Instalacion.ConstructorNombre("Instalación hija");
            ElementoSCADA instalacion2 = Instalacion.ConstructorNombre("Otro hijo independiente");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            ElementoSCADA unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(unaVariable);
            unaPlantaIndustrial.AgregarDependencia(unDispositivo);
            unaPlantaIndustrial.AgregarDependencia(instalacion1);
            unaPlantaIndustrial.AgregarDependencia(instalacion2);
            unaVariable.SetValorActual(-15);
            Assert.AreEqual(1, unaPlantaIndustrial.CantidadAdvertenciasActivas);
            Assert.AreEqual(1, unaPlantaIndustrial.CantidadAdvertenciasActivas);
            Assert.AreEqual(0, instalacion2.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest3RangoNormal()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", -20M, -10M, 20M, 40M);
            ElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            ElementoSCADA unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.SetValorActual(30);
            unaVariable.SetValorActual(0);
            Assert.AreEqual(0, unaInstalacion.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest4Alarma()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", -20M, -10M, 20M, 40M);
            ElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            ElementoSCADA unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.SetValorActual(30);
            unaVariable.SetValorActual(-300);
            Assert.AreEqual(1, unaInstalacion.CantidadAlarmasActivas);
            Assert.AreEqual(0, unaInstalacion.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        public void GetInstalacionPadreTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            ElementoSCADA unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            ElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Molinos");
            unaInstalacion.AgregarDependencia(unDispositivo);
            CollectionAssert.Contains(unDispositivo.ElementoPadre.Dependencias, unDispositivo);
        }

        [TestMethod]
        public void EqualsTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Assert.AreEqual(unDispositivo, unDispositivo);
        }

        [TestMethod]
        public void EqualsTest2()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Evaporadores");
            Instalacion otraInstalacion = Instalacion.ConstructorNombre("Evaporadores");
            Assert.AreNotEqual(unaInstalacion, otraInstalacion);
            Assert.AreNotEqual(otraInstalacion, unaInstalacion);
        }

        [TestMethod]
        public void EqualsTest3()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Evaporadores");
            Assert.AreNotEqual(unaInstalacion, new object());
        }

        [TestMethod]
        public void EqualsTest4()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Evaporadores");
            Assert.AreNotEqual(unaInstalacion, null);
        }

        public void EqualsTest5()
        {
            Tipo unTipo = Tipo.TipoInvalido();
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Evaporadores");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Un nombre", unTipo);
            Assert.AreNotEqual(unaInstalacion, unDispositivo);
        }

        [TestMethod]
        public void CompareToElementoSCADATest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Assert.AreEqual(0, unDispositivo.CompareTo(unDispositivo));
        }

        [TestMethod]
        public void CompareToElementoSCADATest2()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("A");
            Instalacion otraInstalacion = Instalacion.ConstructorNombre("C");
            Assert.IsTrue(unaInstalacion.CompareTo(otraInstalacion) < 0);
        }

        [TestMethod]
        public void CompareToElementoSCADATest3()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("PL3", "Cuareim 2389", "Montevideo");
            PlantaIndustrial otraPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("PL1", "Cuareim 2389", "Montevideo");
            Assert.IsTrue(unaPlantaIndustrial.CompareTo(otraPlantaIndustrial) > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void CompareToElementoSCADATest4()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Z");
            unaInstalacion.CompareTo(new object());
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void CompareToElementoSCADATest5()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Z");
            unaInstalacion.CompareTo(null);
        }
    }
}
