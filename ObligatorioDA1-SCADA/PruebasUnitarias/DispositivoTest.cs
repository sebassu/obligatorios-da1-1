using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
            Assert.AreEqual("Nombre inválido.", unDispositivo.Nombre);
            Assert.AreEqual(unDispositivo.Tipo, Tipo.TipoInvalido());
            Assert.AreEqual(unDispositivo.EnUso, false);
            Assert.AreEqual(0, unDispositivo.Variables.Count);
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
        [ExpectedException(typeof(NotSupportedException))]
        public void AgregarCompoenenteDispositivoTest()
        {
            Tipo unTipo = Tipo.NombreDescripcion("Cierto tipo", "Descripción");
            Dispositivo unDispositivo = Dispositivo.NombreTipoEnUso("Nombre válido", unTipo, false);
            Dispositivo otroDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.AgregarComponente(otroDispositivo);
        }

        [TestMethod]
        public void DependenciasDispositivoTest()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            CollectionAssert.AreEqual(unDispositivo.Dependencias, new List<Componente>());
        }
    }
}