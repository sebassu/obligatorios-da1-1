using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;

namespace PruebasUnitarias
{
    [TestClass]
    public class DispositivoTest
    {
        [TestMethod]
        public void DispositivoInvalidoTest()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            Assert.AreEqual("Nombre inválido.", unDispositivo.Nombre);
            Assert.AreEqual(unDispositivo.Tipo, Tipo.TipoInvalido());
            Assert.AreEqual(unDispositivo.EnUso, false);
        }

        [TestMethod]
        public void SetNombreDispositivoTest1()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "Molino";
            Assert.AreEqual("Molino", unDispositivo.Nombre);
        }

        [TestMethod]
        public void SetNombreDispositivoTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "  centrifugadora-12  ";
            Assert.AreEqual("centrifugadora-12", unDispositivo.Nombre);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreDispositivoTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreDispositivoTest4()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = "1234";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetNombreDispositivoTest5()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Nombre = " !%$@<> . @#$";
        }

        [TestMethod]
        public void SetEnUsoDispositivoTest1()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.EnUso = true;
            Assert.AreEqual(true, unDispositivo.EnUso);
        }

        [TestMethod]
        public void SetEnUsoDispositivoTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.EnUso = false;
            Assert.AreEqual(false, unDispositivo.EnUso);
        }

        [TestMethod]
        public void SetDispositivoTipoTest1()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            Tipo unTipo = Tipo.TipoInvalido();
            unDispositivo.Tipo = unTipo;
            Assert.AreEqual(unTipo, unDispositivo.Tipo);
        }

        [TestMethod]
        public void SetDispositivoTipoTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            Tipo unTipo = Tipo.NombreDescripcion("Eléctrico", "Es muy bueno");
            unDispositivo.Tipo = unTipo;
            Assert.AreEqual(unTipo, unDispositivo.Tipo);
        }

        [TestMethod]
        public void SetDispositivoTipoTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            Tipo unTipo = Tipo.NombreDescripcion("Eléctrico", "Es muy bueno");
            Tipo otroTipo = Tipo.NombreDescripcion("Eléctrico", "Es muy bueno");
            unDispositivo.Tipo = unTipo;
            Assert.AreEqual(otroTipo, unDispositivo.Tipo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetDispositivoTipoTest4()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Tipo = null;
        }

        [TestMethod]
        public void NombreTipoEnUsoTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, true);
            Assert.AreEqual(unDispositivo.Nombre, "Nombre válido");
            Assert.AreEqual(unDispositivo.Tipo, unTipo);
            Assert.AreEqual(unDispositivo.EnUso, true);
        }

        [TestMethod]
        public void NombreTipoEnUsoTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo);
            Assert.AreEqual(unDispositivo.Nombre, "Nombre válido");
            Assert.AreEqual(unDispositivo.Tipo, unTipo);
            Assert.AreEqual(unDispositivo.EnUso, false);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NombreTipoEnUsoTest3()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("12!,.1#@2", unTipo, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NombreTipoEnUsoTest4()
        {
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", null, false);
        }

        [TestMethod]
        public void VariablesDispositivoNuevoTest()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            Assert.AreEqual(unDispositivo.Variables.Count, 0);
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
    }
}