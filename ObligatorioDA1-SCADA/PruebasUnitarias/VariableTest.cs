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
            Assert.AreEqual("Nombre inválido.", unaVariable.Nombre);
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
            unaVariable.ValorActual = nuevoValor;
            Assert.AreEqual(nuevoValor, unaVariable.ValorActual);
        }

        [TestMethod]
        public void SetValorActualTest2()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.ValorActual = 10;
            Assert.AreEqual(10, unaVariable.ValorActual);
        }

        [TestMethod]
        public void SetValorActualTest3()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.ValorActual = -7;
            Assert.AreEqual(-7, unaVariable.ValorActual);
        }

        [TestMethod]
        public void NombreRangosAdvertenciaAlarmaTest1()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            Assert.AreEqual("Altura", unaVariable.Nombre);
            Assert.AreEqual(-20M, unaVariable.MinimoAlarma);
            Assert.AreEqual(-10M, unaVariable.MinimoAdvertencia);
            Assert.AreEqual(20M, unaVariable.MaximoAdvertencia);
            Assert.AreEqual(40M, unaVariable.MaximoAlarma);
        }

        [TestMethod]
        public void NombreRangosAdvertenciaAlarmaTest2ValoresIguales()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(10M, 10M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(10M, 10M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
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
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("12,. #$%", rangoAdvertencia, rangoAlarma);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreRangosAdvertenciaAlarmaTest4MinimosInvalidos()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-200M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreRangosAdvertenciaAlarmaTest5RangoAdvertenciaInvalido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(10M, -10M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void NombreRangosAdvertenciaAlarmaTest6MaximosInvalidos()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 10M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Calor", rangoAdvertencia, rangoAlarma);
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
        public void SetValorMinimoAlarmaTest1Valido()
        {
            decimal nuevoValor = -15;
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAlarma = nuevoValor;
            Assert.AreEqual(nuevoValor, unaVariable.MinimoAlarma);
        }

        [TestMethod]
        public void SetValorMinimoAlarmaTest2Valido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAlarma = -300.9M;
            Assert.AreEqual(-300.9M, unaVariable.MinimoAlarma);
        }

        [TestMethod]
        public void SetValorMinimoAlarmaTest3ValidoIguales()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAlarma = -10M;
            Assert.AreEqual(-10M, unaVariable.MinimoAlarma);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValorMinimoAlarmaTest4Invalido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Altura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAlarma = -9.9M;
        }

        [TestMethod]
        public void SetValorMinimoAdvertenciaTest1Valido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAdvertencia = -15;
            Assert.AreEqual(-15M, unaVariable.MinimoAdvertencia);
        }

        [TestMethod]
        public void SetValorMinimoAdvertenciaTest2Valido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAdvertencia = 0.5M;
            Assert.AreEqual(0.5M, unaVariable.MinimoAdvertencia);
        }

        [TestMethod]
        public void SetValorMinimoAlarmaTest3ValidoIgualMinimoAlarma()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAdvertencia = -20M;
            Assert.AreEqual(-20M, unaVariable.MinimoAdvertencia);
        }

        [TestMethod]
        public void SetValorMinimoAlarmaTest4ValidoIgualMaximoAdvertencia()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAdvertencia = 20M;
            Assert.AreEqual(20M, unaVariable.MinimoAdvertencia);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValorMinimoAlarmaTest5InvalidoSuperior()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAdvertencia = 20.1M;
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValorMinimoAlarmaTest6InvalidoInferior()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
            unaVariable.MinimoAdvertencia = -21M;
        }

        [TestMethod]
        public void SetValorMaximoAdvertenciaTest1Valido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Volumen", rangoAdvertencia, rangoAlarma);
            unaVariable.MaximoAdvertencia = 30M;
            Assert.AreEqual(30M, unaVariable.MaximoAdvertencia);
        }

        [TestMethod]
        public void SetValorMaximoAdvertenciaTest2Valido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Volumen", rangoAdvertencia, rangoAlarma);
            unaVariable.MaximoAdvertencia = 0.9M;
            Assert.AreEqual(0.9M, unaVariable.MaximoAdvertencia);
        }

        [TestMethod]
        public void SetValorMinimoAlarmaTest3ValidoIgualMinimoAdvertencia()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Volumen", rangoAdvertencia, rangoAlarma);
            unaVariable.MaximoAdvertencia = -10M;
            Assert.AreEqual(-10M, unaVariable.MaximoAdvertencia);
        }

        [TestMethod]
        public void SetValorMinimoAlarmaTest4ValidoIgualMaximoAlarma()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Volumen", rangoAdvertencia, rangoAlarma);
            unaVariable.MaximoAdvertencia = 40M;
            Assert.AreEqual(40M, unaVariable.MaximoAdvertencia);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValorMinimoAlarmaTest5InvalidoSuperior()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
            unaVariable.MaximoAdvertencia = 41M;
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValorMinimoAlarmaTest6InvalidoInferior()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Temperatura", rangoAdvertencia, rangoAlarma);
            unaVariable.MaximoAdvertencia = -10.9M;
        }

        [TestMethod]
        public void SetValorMaximoTest1Valido()
        {
            decimal nuevoValor = 200;
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Calor", rangoAdvertencia, rangoAlarma);
            unaVariable.Maximo = nuevoValor;
            Assert.AreEqual(nuevoValor, unaVariable.Maximo);
        }

        [TestMethod]
        public void SetValorMaximoTest2Valido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Calor", rangoAdvertencia, rangoAlarma);
            unaVariable.Maximo = 30M;
            Assert.AreEqual(2000.7M, unaVariable.Maximo);
        }

        [TestMethod]
        public void SetValorMaximoTest3IgualMaximoAdvertencia()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Calor", rangoAdvertencia, rangoAlarma);
            unaVariable.Maximo = 20M;
            Assert.AreEqual(20M, unaVariable.Maximo);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetValorMaximoTest4Invalido()
        {
            Tuple<decimal, decimal> rangoAdvertencia = Tuple.Create(-10M, 20M);
            Tuple<decimal, decimal> rangoAlarma = Tuple.Create(-20M, 40M);
            Variable unaVariable = Variable.NombreRangosAdvertenciaAlarma("Calor", rangoAdvertencia, rangoAlarma);
            unaVariable.Maximo = 19M;
        }

        [TestMethod]
        public void ValorFueraDeRangoTest1Dentro()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Volumen", 0, 400);
            unaVariable.ValorActual = 200.5M;
            Assert.AreEqual(false, unaVariable.EstaFueraDeRango);
        }

        [TestMethod]
        public void ValorFueraDeRangoTest2PorEncima()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", 0, 400);
            unaVariable.ValorActual = 1000;
            Assert.AreEqual(true, unaVariable.EstaFueraDeRango);
        }

        [TestMethod]
        public void ValorFueraDeRangoTest3PorDebajo()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", 0, 400);
            unaVariable.ValorActual = -30;
            Assert.AreEqual(true, unaVariable.EstaFueraDeRango);
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
            unaVariable.ValorActual = 30.1M;
            Assert.AreEqual(unaVariable.Historico.Count, 0);
        }

        [TestMethod]
        public void AgregaValoresAHistoricoTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0, 75);
            unaVariable.ValorActual = -50;
            unaVariable.ValorActual = -125.3M;
            int largo = 0;
            ArrayList valoresSinFecha = new ArrayList();
            foreach (Tuple<DateTime, decimal> elemento in unaVariable.Historico)
            {
                valoresSinFecha.Add(elemento.Item2);
                largo++;
            }
            CollectionAssert.Contains(valoresSinFecha, -50M);
            Assert.AreEqual(largo, 1);
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
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0.9M, 100);
            unDispositivo.AgregarVariable(unaVariable);
            CollectionAssert.Contains(unaVariable.ComponentePadre.Variables, unaVariable);
        }

        [TestMethod]
        public void GetComponentePadreTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Evaporadores");
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", 0, 99);
            unaInstalacion.AgregarVariable(unaVariable);
            CollectionAssert.Contains(unaVariable.ComponentePadre.Variables, unaVariable);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetComponentePadreTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 90, 100);
            unaVariable.ComponentePadre = null;
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void SetComponentePadreTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0.9M, 100);
            unaVariable.ComponentePadre = unDispositivo;
        }

        [TestMethod]
        public void CompareToTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Nombre", 0, 10);
            Assert.AreEqual(0, unaVariable.CompareTo(unaVariable));
        }

        [TestMethod]
        public void CompareToTest2()
        {
            Variable variable1 = Variable.NombreMinimoMaximo("ABC", 0, 10);
            Variable variable2 = Variable.NombreMinimoMaximo("DEF", -100, 100);
            Assert.IsTrue(variable1.CompareTo(variable2) < 0);
        }

        [TestMethod]
        public void CompareToTest3()
        {
            Variable variable1 = Variable.NombreMinimoMaximo("XYZ", 0, 10);
            Variable variable2 = Variable.NombreMinimoMaximo("DEF", -100, 100);
            Assert.IsTrue(variable1.CompareTo(variable2) > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void CompareToTest4()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Nombre", 0, 10);
            unaVariable.CompareTo(new object());
        }

        [TestMethod]
        [ExpectedException(typeof(VariableExcepcion))]
        public void CompareToTest5()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Nombre", 0, 10);
            unaVariable.CompareTo(null);
        }

        [TestMethod]
        public void ToStringTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Variable", -10, 30);
            unaVariable.ValorActual = 1;
            Assert.AreEqual("Variable: 1 (-10 - 30)", unaVariable.ToString());
        }

        [TestMethod]
        public void ToStringTest2()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Variable", -10, 30);
            Assert.AreEqual("Variable: N/A (-10 - 30)", unaVariable.ToString());
        }
    }
}