using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio;
using System.Diagnostics.CodeAnalysis;
using Excepciones;
using System;

namespace PruebasUnitarias
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ComponenteTest
    {
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
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void AgregarVariableTest3()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.AgregarVariable(null);
        }

        [TestMethod]
        public void EliminarVariableTest1()
        {
            Variable unaVariable = Variable.VariableInvalida();
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.AgregarVariable(unaVariable);
            unDispositivo.EliminarVariable(unaVariable);
            CollectionAssert.DoesNotContain(unDispositivo.Variables, unaVariable);
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void EliminarVariableTest2()
        {
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unDispositivo.EliminarVariable(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void SetInstalacionPadreTest1()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Molinos");
            unaInstalacion.InstalacionPadre = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
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
        [ExpectedException(typeof(ComponenteExcepcion))]
        public void CompareToTest4()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Z");
            unaInstalacion.CompareTo(new object());
        }

        [TestMethod]
        [ExpectedException(typeof(ComponenteExcepcion))]
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

        [TestMethod]
        public void EliminarComponenteTest()
        {
            Instalacion unaInstalacion = Instalacion.ConstructorNombre("Paneles");
            Assert.AreEqual("Paneles (I)", unaInstalacion.ToString());
        }
    }
}