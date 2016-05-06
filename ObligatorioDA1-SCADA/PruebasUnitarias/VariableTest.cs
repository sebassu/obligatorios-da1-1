using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections;

namespace PruebasUnitarias
{
    [TestClass]
    public class VariableTest
    {
        [TestMethod]
        public void SetValorActualTest1()
        {
            double nuevoValor = 125;
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.ValorActual = nuevoValor;
            Assert.AreEqual(nuevoValor, unaVariable.ValorActual);
        }

        [TestMethod]
        public void SetValorActualTest2()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.ValorActual = 0;
            Assert.AreEqual(0, unaVariable.ValorActual);
        }

        [TestMethod]
        public void SetValorActualTest3()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.ValorActual = -7;
            Assert.AreEqual(-7, unaVariable.ValorActual);
        }

        [TestMethod]
        public void NombreMinimoMaximoTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Altura", 0, 418);
            Assert.AreEqual("Altura", unaVariable.Nombre);
            Assert.AreEqual(0, unaVariable.Minimo);
            Assert.AreEqual(418, unaVariable.Maximo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NombreMinimoMaximoTest2()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("12,. #$%", 0, 418);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NombreMinimoMaximoTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Velocidad", 970, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NombreMinimoMaximoTest4()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Velocidad", 900, 30);
        }

        [TestMethod]
        public void setNombreTest1Valido()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = "Temperatura";
            Assert.AreEqual("Temperatura", unaVariable.Nombre);
        }

        [TestMethod]
        public void setNombreTest2Espacios()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = " Presión - 123 ";
            Assert.AreEqual("Presión - 123", unaVariable.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNombreTest3Numeros()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNombreTest4Punctuacion()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = "@#&*! ., (";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void setNombreTest5Vacio()
        {
            Variable unaVariable = Variable.VariableInvalida();
            unaVariable.Nombre = "";
        }

        [TestMethod]
        public void SetValorMinimoTest1Valido()
        {
            double nuevoValor = 0;
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -273.15, 500);
            unaVariable.Minimo = nuevoValor;
            Assert.AreEqual(nuevoValor, unaVariable.Minimo);
        }

        [TestMethod]
        public void SetValorMinimoTest2Valido()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -273.15, 500);
            unaVariable.Minimo = -300.9;
            Assert.AreEqual(-300.9, unaVariable.Minimo);
        }

        [TestMethod]
        public void SetValorMinimoTest3ValidoIguales()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -273.15, 500);
            unaVariable.Minimo = 500;
            Assert.AreEqual(500, unaVariable.Minimo);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetValorMinimoTest4Invalido()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -273.15, 500);
            unaVariable.Minimo = 1000;
        }

        [TestMethod]
        public void SetValorMaximoTest1Valido()
        {
            double nuevoValor = 200;
            Variable unaVariable = Variable.NombreMinimoMaximo("Presión", 0, 100);
            unaVariable.Maximo = nuevoValor;
            Assert.AreEqual(nuevoValor, unaVariable.Maximo);
        }

        [TestMethod]
        public void SetValorMaximoTest2Valido()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Presión", 0, 9999);
            unaVariable.Maximo = 2000.7;
            Assert.AreEqual(2000.7, unaVariable.Maximo);
        }

        [TestMethod]
        public void SetValorMaximoTest3Iguales()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Presión", 0, 9999);
            unaVariable.Maximo = 0;
            Assert.AreEqual(0, unaVariable.Maximo);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetValorMaximoTest4Invalido()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Presión", 0, 9999);
            unaVariable.Maximo = -20;
        }

        [TestMethod]
        public void ValorFueraDeRangoTest1Dentro()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Volumen", 0, 400);
            unaVariable.ValorActual = 200.5;
            Assert.AreEqual(false, unaVariable.ValorFueraDeRango());
        }

        [TestMethod]
        public void ValorFueraDeRangoTest2PorEncima()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", 0, 400);
            unaVariable.ValorActual = 1000;
            Assert.AreEqual(true, unaVariable.ValorFueraDeRango());
        }

        [TestMethod]
        public void ValorFueraDeRangoTest3PorDebajo()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", 0, 400);
            unaVariable.ValorActual = -30;
            Assert.AreEqual(true, unaVariable.ValorFueraDeRango());
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
            unaVariable.ValorActual = 30.1;
            Assert.AreEqual(unaVariable.Historico.Count, 0);
        }

        [TestMethod]
        public void AgregaValoresAHistoricoTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0, 75);
            unaVariable.ValorActual = -50;
            unaVariable.ValorActual = -125.3;
            int largo = 0;
            ArrayList valoresSinFecha = new ArrayList();
            foreach (Tuple<DateTime, double> elemento in unaVariable.Historico)
            {
                valoresSinFecha.Add(elemento.Item2);
                largo++;
            }
            CollectionAssert.Contains(valoresSinFecha, -50D);
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
        public void GetDispositivoPadreTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0.9, 100);
            unDispositivo.AgregarVariable(unaVariable);
            CollectionAssert.Contains(unaVariable.Dispositivo.Variables, unaVariable);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetDispositivoPadreTest1()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0.9, 100);
            unaVariable.DispositivoPadre = null;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetDispositivoPadreTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Radiación", 0.9, 100);
            unaVariable.DispositivoPadre = unDispositivo;
        }
    }
}