using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Excepciones;

namespace PruebasUnitarias
{
    [TestClass]
    [ExcludeFromCodeCoverage]
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
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetDispositivoTipoTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.Tipo = null;
        }

        [TestMethod]
        public void NombreTipoTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Assert.AreEqual(unDispositivo.Nombre, "Nombre válido");
            Assert.AreEqual(unDispositivo.Tipo, unTipo);
            Assert.AreEqual(false, unDispositivo.EnUso);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void NombreTipoTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("12!,.1#@2", unTipo);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void NombreTipoTest3()
        {
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", null);
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
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(unaVariable);
            unaVariable.ValorActual = 5;
            Assert.AreEqual(unDispositivo.CantidadAlarmasActivas, (uint)0);
        }

        [TestMethod]
        public void AlarmasActivasDispositivoTest3()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Una variable cualquiera", -10, 30);
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(unaVariable);
            unaVariable.ValorActual = 100;
            Assert.AreEqual(unDispositivo.CantidadAlarmasActivas, (uint)1);
        }

        [TestMethod]
        public void AlarmasActivasDispositivoTest4()
        {
            Variable unaVariable = Variable.NombreMinimoMaximo("Una variable cualquiera", -10, 30);
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(unaVariable);
            unaVariable.ValorActual = -100;
            Assert.AreEqual(unDispositivo.CantidadAlarmasActivas, (uint)1);
        }

        [TestMethod]
        public void IncrementarCantidadAlarmasTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            uint cantidadAnterior = unDispositivo.CantidadAlarmasActivas;
            unDispositivo.IncrementarAlarmas();
            Assert.AreEqual(cantidadAnterior + 1, unDispositivo.CantidadAlarmasActivas);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void IncrementarCantidadAlarmasTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.IncrementarAlarmas();
        }

        [TestMethod]
        public void DecrementarCantidadAlarmasTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            uint cantidadAnterior = unDispositivo.CantidadAlarmasActivas;
            unDispositivo.IncrementarAlarmas();
            unDispositivo.DecrementarAlarmas();
            Assert.AreEqual(cantidadAnterior, unDispositivo.CantidadAlarmasActivas);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void DecrementarCantidadAlarmasTest2()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            unDispositivo.DecrementarAlarmas();
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void IncrementarCantidadAlarmasTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.DecrementarAlarmas();
        }

        [TestMethod]
        public void IncrementarCantidadAdvertenciasTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            uint cantidadAnterior = unDispositivo.CantidadAdvertenciasActivas;
            unDispositivo.IncrementarAdvertencias();
            Assert.AreEqual(cantidadAnterior + 1, unDispositivo.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void IncrementarCantidadAdvertenciasTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.IncrementarAdvertencias();
        }

        [TestMethod]
        public void DecrementarCantidadAdvertenciasTest1()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            uint cantidadAnterior = unDispositivo.CantidadAdvertenciasActivas;
            unDispositivo.IncrementarAdvertencias();
            unDispositivo.DecrementarAdvertencias();
            Assert.AreEqual(cantidadAnterior, unDispositivo.CantidadAdvertenciasActivas);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void DecrementarCantidadAdvertenciasTest3()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            unDispositivo.AgregarVariable(Variable.VariableInvalida());
            unDispositivo.DecrementarAdvertencias();
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void IncrementarCantidadAdvertenciasTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.DecrementarAdvertencias();
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void AgregarDependenciaDispositivoTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Dispositivo otroDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.AgregarDependencia(otroDispositivo);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void EliminarDependenciaDispositivoTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Nombre válido", unTipo);
            Dispositivo otroDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.EliminarDependencia(otroDispositivo);
        }

        [TestMethod]
        public void DependenciasDispositivoTest()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            CollectionAssert.AreEqual(unDispositivo.Dependencias, new List<Componente>());
        }

        [TestMethod]
        public void ToStringDispositivoTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipo("Centrifugadora", unTipo);
            Assert.AreEqual("Centrifugadora (D)", unDispositivo.ToString());
        }
    }
}