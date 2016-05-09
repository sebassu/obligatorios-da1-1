using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Diagnostics.CodeAnalysis;

namespace PruebasUnitarias
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ComponenteTest
    {
        [TestMethod]
        public void SetNombreComponenteTest1()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "Molino";
            Assert.AreEqual("Molino", unDispositivo.Nombre);
        }

        [TestMethod]
        public void SetNombreComponenteTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "  centrifugadora-12  ";
            Assert.AreEqual("centrifugadora-12", unDispositivo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreComponenteTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreComponenteTest4()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreComponenteTest5()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = " !%$@<> . @#$";
        }

        [TestMethod]
        public void AgregarVariableTest1()
        {
            Variable unaVariable = Variable.VariableInvalida();
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.AgregarVariable(unaVariable);
            CollectionAssert.Contains(unDispositivo.Variables, unaVariable);
        }

        [TestMethod]
        public void AgregarVariableTest2()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Una variable cualquiera", 0, 10);
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.AgregarVariable(unaVariable);
            CollectionAssert.Contains(unDispositivo.Variables, unaVariable);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AgregarVariableTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.AgregarVariable(null);
        }

        [TestMethod]
        public void AlarmasActivasDispositivoTest1()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            Assert.AreEqual(unDispositivo.CantidadAlarmasActivas, (uint)0);
        }

        [TestMethod]
        public void AlarmasActivasDispositivoTest2()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Una variable cualquiera", 0, 10);
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            unDispositivo.AgregarVariable(unaVariable);
            unaVariable.ValorActual = 5;
            Assert.AreEqual(unDispositivo.CantidadAlarmasActivas, (uint)0);
        }

        [TestMethod]
        public void AlarmasActivasDispositivoTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Una variable cualquiera", -10, 30);
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            unDispositivo.AgregarVariable(unaVariable);
            unaVariable.ValorActual = 100;
            Assert.AreEqual(unDispositivo.CantidadAlarmasActivas, (uint)1);
        }

        [TestMethod]
        public void AlarmasActivasDispositivoTest4()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Una variable cualquiera", -10, 30);
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            unDispositivo.AgregarVariable(unaVariable);
            unaVariable.ValorActual = -100;
            Assert.AreEqual(unDispositivo.CantidadAlarmasActivas, (uint)1);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            uint cantidadAnterior = unDispositivo.CantidadAlarmasActivas;
            unDispositivo.IncrementarAlarmas();
            Assert.AreEqual(cantidadAnterior + 1, unDispositivo.CantidadAlarmasActivas);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IncrementarCantidadAlarmasTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.IncrementarAlarmas();
        }

        [TestMethod]
        public void DecrementarCantidadAlarmasTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            uint cantidadAnterior = unDispositivo.CantidadAlarmasActivas;
            unDispositivo.IncrementarAlarmas();
            unDispositivo.DecrementarAlarmas();
            Assert.AreEqual(cantidadAnterior, unDispositivo.CantidadAlarmasActivas);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DecrementarCantidadAlarmasTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            uint cantidadAnterior = unDispositivo.CantidadAlarmasActivas;
            unDispositivo.DecrementarAlarmas();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void IncrementarCantidadAlarmasTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.DecrementarAlarmas();
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest1()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 0, 10);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarComponente(unDispositivo);
            unaVariable.ValorActual = 99;
            Assert.AreEqual((uint)1, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest2NoEnUso()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -70, 10);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarComponente(unDispositivo);
            unaVariable.ValorActual = 200;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest3Anidadas()
        {
            Instalacion instalacion1 = Instalacion.ConstructorNombre("Instalación padre");
            Instalacion instalacion2 = Instalacion.ConstructorNombre("Instalación hija");
            Instalacion instalacion3 = Instalacion.ConstructorNombre("Otro hijo independiente");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", 0, 10);
            unDispositivo.AgregarVariable(unaVariable);
            instalacion2.AgregarComponente(unDispositivo);
            instalacion1.AgregarComponente(instalacion2);
            instalacion1.AgregarComponente(instalacion3);
            unaVariable.ValorActual = -300;
            Assert.AreEqual((uint)1, instalacion2.CantidadAlarmasActivas);
            Assert.AreEqual((uint)1, instalacion1.CantidadAlarmasActivas);
            Assert.AreEqual((uint)0, instalacion3.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest4DentroDelRango()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Temperatura", -30, 200);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarComponente(unDispositivo);
            unaVariable.ValorActual = 3000;
            unaVariable.ValorActual = 50;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest5Desactivacion()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Variable unaVariable = Variable.NombreMinimoMaximo("Calor", -200, 80);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarComponente(unDispositivo);
            unaVariable.ValorActual = 3000;
            unDispositivo.EnUso = false;
            Assert.AreEqual((uint)0, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasPadreTest6Activacion()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Nombre instalación");
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            Variable unaVariable = Variable.NombreMinimoMaximo("Presión", -10, 10);
            unDispositivo.AgregarVariable(unaVariable);
            unaInstalacion.AgregarComponente(unDispositivo);
            unaVariable.ValorActual = 3000;
            unDispositivo.EnUso = true;
            Assert.AreEqual((uint)1, unaInstalacion.CantidadAlarmasActivas);
        }

        [TestMethod]
        public void GetInstalacionPadreTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Molinos");
            unaInstalacion.AgregarComponente(unDispositivo);
            CollectionAssert.Contains(unDispositivo.InstalacionPadre.Dependencias, unDispositivo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetInstalacionPadreTest1()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Molinos");
            unaInstalacion.InstalacionPadre = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetInstalacionPadreTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Molinos");
            unDispositivo.InstalacionPadre = unaInstalacion;
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
        public void CompareToTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Assert.AreEqual(0, unDispositivo.CompareTo(unDispositivo));
        }

        [TestMethod]
        public void CompareToTest2()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("A");
            Instalacion otraInstalacion = Instalacion.ConstructorNombre("C");
            Assert.IsTrue(unaInstalacion.CompareTo(otraInstalacion) < 0);
        }

        [TestMethod]
        public void CompareToTest3()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Z");
            Instalacion otraInstalacion = Instalacion.ConstructorNombre("C");
            Assert.IsTrue(unaInstalacion.CompareTo(otraInstalacion) > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToTest4()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Z");
            unaInstalacion.CompareTo(new object());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToTest5()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Z");
            unaInstalacion.CompareTo(null);
        }

        [TestMethod]
        public void ToStringTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Centrifugadora", unTipo, true);
            Assert.AreEqual("Centrifugadora (D)", unDispositivo.ToString());
        }

        [TestMethod]
        public void ToStringTest2()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Paneles");
            Assert.AreEqual("Paneles (I)", unaInstalacion.ToString());
        }
    }
}