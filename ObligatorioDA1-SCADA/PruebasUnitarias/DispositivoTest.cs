using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Excepciones;

namespace PruebasUnitarias
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DispositivoTest
    {
        [TestMethod]
        public void DispositivoInvalidoTest()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            Assert.AreEqual("Dispositivo inválido.", unDispositivo.Nombre);
            Assert.AreEqual("Tipo inválido.", unDispositivo.Tipo.Nombre);
            Assert.AreEqual(unDispositivo.EnUso, false);
            Assert.AreEqual(0, unDispositivo.Variables.Count);
        }

        [TestMethod]
        public void SetEnUsoDispositivoTest1()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.EnUso = true;
            Assert.IsTrue(unDispositivo.EnUso);
        }

        [TestMethod]
        public void SetEnUsoDispositivoTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.EnUso = false;
            Assert.IsFalse(unDispositivo.EnUso);
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
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void SetDispositivoTipoTest3()
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
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void NombreTipoEnUsoTest3()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("12!,.1#@2", unTipo, true);
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void NombreTipoEnUsoTest4()
        {
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", null, false);
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
        [ExpectedException(typeof(ComponenteExcepcion))]
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
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void DecrementarCantidadAlarmasTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            unDispositivo.DecrementarAlarmas();
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void IncrementarCantidadAlarmasTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.DecrementarAlarmas();
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            uint cantidadAnterior = unDispositivo.CantidadAdvertenciasActivas;
            unDispositivo.IncrementarAdvertencias();
            Assert.AreEqual(cantidadAnterior + 1, unDispositivo.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void IncrementarCantidadAdvertenciasTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.IncrementarAdvertencias();
        }

        [TestMethod]
        public void DecrementarCantidadAdvertenciasTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            uint cantidadAnterior = unDispositivo.CantidadAdvertenciasActivas;
            unDispositivo.IncrementarAdvertencias();
            unDispositivo.DecrementarAdvertencias();
            Assert.AreEqual(cantidadAnterior, unDispositivo.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void DecrementarCantidadAdvertenciasTest3()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            unDispositivo.DecrementarAdvertencias();
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void IncrementarCantidadAdvertenciasTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.DecrementarAdvertencias();
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void AgregarCompoenenteDispositivoTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            Dispositivo otroDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.AgregarComponente(otroDispositivo);
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void EliminarComponenteTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            Dispositivo otroDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.EliminarComponente(otroDispositivo);
        }

        [TestMethod]
        public void DependenciasDispositivoTest()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            CollectionAssert.AreEqual(unDispositivo.Dependencias, new List<Componente>());
        }
    }
}