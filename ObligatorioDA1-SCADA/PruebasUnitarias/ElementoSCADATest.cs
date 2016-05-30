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
            IElementoSCADA unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "Molino";
            Assert.AreEqual("Molino", unDispositivo.Nombre);
        }

        [TestMethod]
        public void SetNombreElementoSCADATest2()
        {
            IElementoSCADA unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "  centrifugadora-12  ";
            Assert.AreEqual("centrifugadora-12", unDispositivo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetNombreElementoSCADATest3()
        {
            IElementoSCADA unaInstalacion = Instalacion.InstalacionInvalida();
            unaInstalacion.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetNombreElementoSCADATest4()
        {
            IElementoSCADA unaInstalacion = Instalacion.InstalacionInvalida();
            unaInstalacion.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetNombreElementoSCADATest5()
        {
            IElementoSCADA unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Nombre = " !%$@<> . @#$";
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest1()
        {
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 0, 10);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 99;
            Assert.AreEqual((uint)1, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest2NoEnUso()
        {
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -70, 10);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 200;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest3Anidadas()
        {
            IElementoSCADA unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            IElementoSCADA instalacion1 = Instalacion.ConstructorNombre("Instalación hija");
            IElementoSCADA instalacion2 = Instalacion.ConstructorNombre("Otro hijo independiente");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 0, 10);
            unDispositivo.AgregarVariable(unaVariable);
            instalacion1.AgregarDependencia(unDispositivo);
            unaPlantaIndustrial.AgregarDependencia(instalacion1);
            unaPlantaIndustrial.AgregarDependencia(instalacion2);
            unaVariable.ValorActual = -300;
            Assert.AreEqual((uint)1, instalacion1.CantidadAlarmasActivas);
            Assert.AreEqual((uint)1, unaPlantaIndustrial.CantidadAlarmasActivas);
            Assert.AreEqual((uint)0, instalacion2.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest4DentroDelRango()
        {
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -30, 200);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 3000;
            unaVariable.ValorActual = 50;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest5Desactivacion()
        {
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", -200, 80);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 3000;
            unDispositivo.EnUso = false;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest6Activacion()
        {
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            Variable unaVariable = Variable.NombreMinimoMaximo("Presión", -10, 10);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 3000;
            unDispositivo.EnUso = true;
            Assert.AreEqual((uint)1, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest1()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            IElementoSCADA unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            unDispositivo.AgregarVariable(unaVariable);
            unaPlantaIndustrial.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 30;
            Assert.AreEqual((uint)1, unaPlantaIndustrial.CantidadAdvertenciasActivas);
            Assert.AreEqual((uint)0, unaPlantaIndustrial.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest2NoEnUso()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 30;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAdvertenciasActivas);
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest3Anidadas()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            IElementoSCADA unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            IElementoSCADA instalacion1 = Instalacion.ConstructorNombre("Instalación hija");
            IElementoSCADA instalacion2 = Instalacion.ConstructorNombre("Otro hijo independiente");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            unDispositivo.AgregarVariable(unaVariable);
            unaPlantaIndustrial.AgregarDependencia(unDispositivo);
            unaPlantaIndustrial.AgregarDependencia(instalacion1);
            unaPlantaIndustrial.AgregarDependencia(instalacion2);
            unaVariable.ValorActual = -15;
            Assert.AreEqual((uint)1, unaPlantaIndustrial.CantidadAdvertenciasActivas);
            Assert.AreEqual((uint)1, unaPlantaIndustrial.CantidadAdvertenciasActivas);
            Assert.AreEqual((uint)0, instalacion2.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest4RangoNormal()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 30;
            unaVariable.ValorActual = 0;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest5Alarma()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 30;
            unaVariable.ValorActual = -300;
            Assert.AreEqual((uint)1, unaInstalacion.CantidadAlarmasActivas);
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest6Desactivacion()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 30;
            unDispositivo.EnUso = false;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasPadreTest7Activacion()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarDependencia(unDispositivo);
            unaVariable.ValorActual = 30;
            unDispositivo.EnUso = true;
            Assert.AreEqual((uint)1, unaInstalacion.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        public void GetInstalacionPadreTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            IElementoSCADA unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            IElementoSCADA unaInstalacion = Instalacion.ConstructorNombre("Molinos");
            unaInstalacion.AgregarDependencia(unDispositivo);
            CollectionAssert.Contains(unDispositivo.ElementoPadre.Dependencias, unDispositivo);
        }

        [TestMethod]
        public void EqualsTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
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
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Un nombre", unTipo, true);
            Assert.AreNotEqual(unaInstalacion, unDispositivo);
        }

        [TestMethod]
        public void CompareToElementoSCADATest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
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
