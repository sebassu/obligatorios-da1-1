using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Excepciones;
using System;

namespace PruebasUnitarias
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class VariableTest
    {
        [TestMethod]
        public void VariableInvalidaTest()
        {
            Variable unaVariable = Variable.VariableInvalida();
            Assert.AreEqual("Variable inválida.", unaVariable.Nombre);
            Assert.AreEqual(0, unaVariable.MinimoAlarma);
            Assert.AreEqual(0, unaVariable.MinimoAdvertencia);
            Assert.AreEqual(0, unaVariable.MaximoAdvertencia);
            Assert.AreEqual(0, unaVariable.MaximoAlarma);
        }

        [TestMethod]
        public void SetValorActualTest1()
        {
            decimal nuevoValor = 125;
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.SetValorActual(nuevoValor);
            Assert.AreEqual(nuevoValor, unaVariable.ValorActual);
        }

        [TestMethod]
        public void SetValorActualTest2()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.SetValorActual(10);
            Assert.AreEqual(10, unaVariable.ValorActual);
        }

        [TestMethod]
        public void SetValorActualTest3()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.SetValorActual(-7);
            Assert.AreEqual(-7, unaVariable.ValorActual);
        }

        [TestMethod]
        public void NombreRangosAdvertenciaAlarmaTest1()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", -20M, -10M, 20M, 40M);
            Assert.AreEqual("Altura", unaVariable.Nombre);
            Assert.AreEqual(-20M, unaVariable.MinimoAlarma);
            Assert.AreEqual(-10M, unaVariable.MinimoAdvertencia);
            Assert.AreEqual(20M, unaVariable.MaximoAdvertencia);
            Assert.AreEqual(40M, unaVariable.MaximoAlarma);
        }

        [TestMethod]
        public void NombreRangosAdvertenciaAlarmaTest2ValoresIguales()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", 10M, 10M, 10M, 10M);
            Assert.AreEqual("Altura", unaVariable.Nombre);
            Assert.AreEqual(10M, unaVariable.MinimoAlarma);
            Assert.AreEqual(10M, unaVariable.MinimoAdvertencia);
            Assert.AreEqual(10M, unaVariable.MaximoAdvertencia);
            Assert.AreEqual(10M, unaVariable.MaximoAlarma);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreRangosAdvertenciaAlarmaTest3NombreInvalido()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("12,. #$%", -20M, -10M, 20M, 40M);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreRangosAdvertenciaAlarmaTest4MinimosInvalidos()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-100M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", -20M, -100M, 20M, 40M);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreRangosAdvertenciaAlarmaTest5RangoAdvertenciaInvalido()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", -20M, 10M, -10M, 40M);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreRangosAdvertenciaAlarmaTest6MaximosInvalidos()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Calor", -20M, -10M, 20M, 10M);
        }

        [TestMethod]
        public void NombreMinimoMaximoTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Altura", 0, 418);
            Assert.AreEqual("Altura", unaVariable.Nombre);
            Assert.AreEqual(0, unaVariable.MinimoAlarma);
            Assert.AreEqual(0, unaVariable.MinimoAdvertencia);
            Assert.AreEqual(418, unaVariable.MaximoAdvertencia);
            Assert.AreEqual(418, unaVariable.MaximoAlarma);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreMinimoMaximoTest2()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("12,. #$%", 0, 418);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreMinimoMaximoTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Velocidad", 970, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreMinimoMaximoTest4()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Velocidad", 900, 30);
        }

        [TestMethod]
        public void SetNombreTest1Valido()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = "Temperatura";
            Assert.AreEqual("Temperatura", unaVariable.Nombre);
        }

        [TestMethod]
        public void SetNombreTest2Espacios()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = " Presión - 123 ";
            Assert.AreEqual("Presión - 123", unaVariable.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetNombreTest3Numeros()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetNombreTest4Punctuacion()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = "@#&*! ., (";
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetNombreTest5Vacio()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = "";
        }

        [TestMethod]
        public void SetValoresLimitesTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Ondas Sonoras", -12, 20);
            unaVariable.SetValoresLimites(-20M, -10M, 30M, 40M);
            Assert.AreEqual(-20M, unaVariable.MinimoAlarma);
            Assert.AreEqual(-10M, unaVariable.MinimoAdvertencia);
            Assert.AreEqual(30M, unaVariable.MaximoAdvertencia);
            Assert.AreEqual(40M, unaVariable.MaximoAlarma);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValoresLimitesTest2()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Ondas Sonoras", -12, 20);
            unaVariable.SetValoresLimites(-20M, -30M, 30M, 40M);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValoresLimitesTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Ondas Sonoras", -12, 20);
            unaVariable.SetValoresLimites(-20M, -10M, -15M, 40M);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValoresLimitesTest4()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Ondas Sonoras", -12, 20);
            unaVariable.SetValoresLimites(-20M, -10M, 30M, 20M);
        }

        [TestMethod]
        public void ValorAlarmaTest1Dentro()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Volumen", 0, 400);
            unaVariable.SetValorActual(200.5M);
            Assert.IsFalse(unaVariable.AlarmaActiva);
        }

        [TestMethod]
        public void ValorAlarmaTest2PorEncima()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", 0, 400);
            unaVariable.SetValorActual(1000);
            Assert.IsTrue(unaVariable.AlarmaActiva);
        }

        [TestMethod]
        public void ValorAlarmaTest3PorDebajo()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", 0, 400);
            unaVariable.SetValorActual(-30);
            Assert.IsTrue(unaVariable.AlarmaActiva);
        }

        [TestMethod]
        public void ValorAdvertenciaTest1Dentro()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", -20M, -10M, 20M, 40M);
            unaVariable.SetValorActual(0.5M);
            Assert.IsFalse(unaVariable.AdvertenciaActiva);
        }

        [TestMethod]
        public void ValorAdvertenciaTest2PorEncima()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", -20M, -10M, 20M, 40M);
            unaVariable.SetValorActual(30);
            Assert.IsTrue(unaVariable.AdvertenciaActiva);
        }

        [TestMethod]
        public void ValorAdvertenciaTest3PorDebajo()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", -20M, -10M, 20M, 40M);
            unaVariable.SetValorActual(-15.5M);
            Assert.IsTrue(unaVariable.AdvertenciaActiva);
        }

        [TestMethod]
        public void AgregaValoresAHistoricoTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Velocidad", -10, 70);
            Assert.AreEqual(unaVariable.Historico.Count, 0);
        }

        [TestMethod]
        public void AgregaValoresAHistoricoTest2()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Altura", -100, 50);
            unaVariable.SetValorActual(30.1M);
            Assert.AreEqual(unaVariable.Historico.Count, 0);
        }

        [TestMethod]
        public void AgregaValoresAHistoricoTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0, 75);
            unaVariable.SetValorActual(-50);
            unaVariable.SetValorActual(-125.3M);
            int largo = 0;
            ArrayList valoresSinFecha = new ArrayList();
            foreach (Medicion elemento in unaVariable.Historico)
            {
                valoresSinFecha.Add(elemento.Valor);
                largo++;
            }
            CollectionAssert.Contains(valoresSinFecha, -50M);
            Assert.AreEqual(1, largo);
        }

        [TestMethod]
        public void EqualsVariableTest1()
        {
            Variable unaVariable = Variable.VariableInvalida();
            Assert.AreEqual(unaVariable, unaVariable);
        }

        [TestMethod]
        public void EqualsVariableTest2()
        {
            Variable variable1 = Variable.NombreMinimoMaximo("Intensidad lumínica", -10, 775);
            Variable variable2 = Variable.NombreMinimoMaximo("Intensidad lumínica", -10, 775);
            Assert.AreNotEqual(variable1, variable2);
            Assert.AreNotEqual(variable2, variable1);
        }

        [TestMethod]
        public void EqualsVariableTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 0, 1000);
            Tipo objetoDeOtroTipo = Tipo.TipoInvalido();
            Assert.AreNotEqual(unaVariable, objetoDeOtroTipo);
        }

        [TestMethod]
        public void GetComponentePadreTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0.9M, 100);
            unDispositivo.AgregarVariable(unaVariable);
            CollectionAssert.Contains(unaVariable.ElementoPadre.Variables, unaVariable);
        }

        [TestMethod]
        public void GetComponentePadreTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Evaporadores");
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", 0, 99);
            unaInstalacion.AgregarVariable(unaVariable);
            CollectionAssert.Contains(unaVariable.ElementoPadre.Variables, unaVariable);
        }

        [TestMethod]
        public void SetComponentePadreTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 90, 100);
            unaVariable.ElementoPadre = null;
            Assert.AreEqual(null, unaVariable.ElementoPadre);
        }

        [TestMethod]
        public void SetComponentePadreTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0.9M, 100);
            unaVariable.ElementoPadre = unDispositivo;
            Assert.AreEqual(unDispositivo, unaVariable.ElementoPadre);
        }

        [TestMethod]
        public void CompareToTestVariable1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Nombre", 0, 10);
            Assert.AreEqual(0, unaVariable.CompareTo(unaVariable));
        }

        [TestMethod]
        public void CompareToTestVariable2()
        {
            Variable variable1 = Variable.NombreMinimoMaximo("ABC", 0, 10);
            Variable variable2 = Variable.NombreMinimoMaximo("DEF", -100, 100);
            Assert.IsTrue(variable1.CompareTo(variable2) < 0);
        }

        [TestMethod]
        public void CompareToTestVariable3()
        {
            Variable variable1 = Variable.NombreMinimoMaximo("XYZ", 0, 10);
            Variable variable2 = Variable.NombreMinimoMaximo("DEF", -100, 100);
            Assert.IsTrue(variable1.CompareTo(variable2) > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void CompareToTestVariable4()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Nombre", 0, 10);
            unaVariable.CompareTo(new object());
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void CompareToTestVariable5()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Nombre", 0, 10);
            unaVariable.CompareTo(null);
        }

        [TestMethod]
        public void ToStringVariableTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Variable", -10, 30);
            unaVariable.SetValorActual(1);
            Assert.AreEqual("Variable: 1 (-10, -10, 30, 30)", unaVariable.ToString());
        }

        [TestMethod]
        public void ToStringVariableTest2()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", -20M, -10M, 30M, 40M);
            Assert.AreEqual("Temperatura: N/A (-20, -10, 30, 40)", unaVariable.ToString());
        }

        [TestMethod]
        public void ActivacionAlarmaModificacionTest()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", -20M, -10M, 30M, 40M);
            unaVariable.SetValorActual(0);
            Assert.IsFalse(unaVariable.AlarmaActiva);
            unaVariable.SetValoresLimites(70M, 100M, 300M, 400M);
            Assert.IsTrue(unaVariable.AlarmaActiva);
        }

        [TestMethod]
        public void ActivacionAdvertenciaModificacionTest()
        {
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", -20M, -10M, 30M, 40M);
            unaVariable.SetValorActual(80.5M);
            Assert.IsFalse(unaVariable.AdvertenciaActiva);
            unaVariable.SetValoresLimites(70M, 100M, 300M, 400M);
            Assert.IsTrue(unaVariable.AdvertenciaActiva);
        }
    }
}