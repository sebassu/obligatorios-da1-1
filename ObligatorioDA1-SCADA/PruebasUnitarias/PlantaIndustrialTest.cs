using Dominio;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace PruebasUnitarias
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PlantaIndustrialTest
    {
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void PlantaInvalidaTest()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            Assert.AreEqual("Planta industrial inválida.", unaPlantaIndustrial.Nombre);
            Assert.AreEqual("Dirección inválida.", unaPlantaIndustrial.Direccion);
            Assert.AreEqual("Ciudad inválida.", unaPlantaIndustrial.Ciudad);
            Assert.AreEqual(0, unaPlantaIndustrial.Dependencias.Count);
        }

        [TestMethod]
        public void SetDireccionPlantaIndustrialTest1()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Direccion = "Cuareim 2389";
            Assert.AreEqual("Cuareim 2389", unaPlantaIndustrial.Direccion);
        }

        [TestMethod]
        public void SetDireccionPlantaIndustrialTest2Trim()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Direccion = "  18 de julio ap. 101  ";
            Assert.AreEqual("18 de julio ap. 101", unaPlantaIndustrial.Direccion);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetDireccionPlantaIndustrialTest3Invalida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Direccion = "12345";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetDireccionPlantaIndustrialTest4Invalida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Direccion = "asdasd";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetDireccionPlantaIndustrialTest5Invalida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Direccion = "$%)(/ ,. %#$";
        }

        [TestMethod]
        public void SetDireccionPlantaIndustrialTest6Invalida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Direccion = "";
        }

        [TestMethod]
        public void SetCiudadPlantaIndustrialTest1()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Ciudad = "Montevideo";
            Assert.AreEqual("Montevideo", unaPlantaIndustrial.Ciudad);
        }

        [TestMethod]
        public void SetCiudadPlantaIndustrialTest2Trim()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Ciudad = "  Buenos Aires  ";
            Assert.AreEqual("Buenos Aires", unaPlantaIndustrial.Ciudad);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetCiudadPlantaIndustrialTest3Inválida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Ciudad = "Montevideo-123";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetCiudadPlantaIndustrialTest4Inválida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Ciudad = "12345";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetCiudadPlantaIndustrialTest5Inválida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Ciudad = "  !#,. $%&/ ";
        }

        [TestMethod]
        public void SetCiudadPlantaIndustrialTest6Inválida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            unaPlantaIndustrial.Ciudad = "";
        }

        [TestMethod]
        public void NombreDireccionCiudadTest1()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("PL1", "Cuareim 2389", "Montevideo");
            Assert.AreEqual("PL1", unaPlantaIndustrial.Nombre);
            Assert.AreEqual("Cuareim 2389", unaPlantaIndustrial.Direccion);
            Assert.AreEqual("Montevideo", unaPlantaIndustrial.Ciudad);
            Assert.AreEqual(0, unaPlantaIndustrial.Dependencias.Count);
        }

        [TestMethod]
        public void NombreDireccionCiudadTest2()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad(" 2PL-1", " 1reim 2389 ", " Montevideo ");
            Assert.AreEqual("2PL-1", unaPlantaIndustrial.Nombre);
            Assert.AreEqual("1reim 2389", unaPlantaIndustrial.Direccion);
            Assert.AreEqual("Montevideo", unaPlantaIndustrial.Ciudad);
            Assert.AreEqual(0, unaPlantaIndustrial.Dependencias.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void NombreDireccionCiudadTest3Error()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("121;:;:", "Cuareim 2389", "Montevideo");
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void NombreDireccionCiudadTest4Error()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("PL2", ";#34$", "Montevideo");
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void NombreDireccionCiudadTest6Error()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("PL3", "Cuareim 2389", "123A#$12");
        }

        [TestMethod]
        public void AgregarDependenciaPlantaIndustrialTest1()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            Dispositivo unDispositivo = Dispositivo.DispositivoInvalido();
            unaPlantaIndustrial.AgregarDependencia(unDispositivo);
            CollectionAssert.Contains(unaPlantaIndustrial.Dependencias, unDispositivo);
        }

        [TestMethod]
        public void AgregarDependenciaPlantaIndustrialTest2()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            Instalacion unaInstalacion = Instalacion.InstalacionInvalida();
            unaPlantaIndustrial.AgregarDependencia(unaInstalacion);
            CollectionAssert.Contains(unaPlantaIndustrial.Dependencias, unaInstalacion);
        }

        [TestMethod]
        public void EliminarDependenciaPlantaIndustrialTest()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaIndustrialInvalida();
            PlantaIndustrial otraPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("PL3", "Cuareim 2389", "Montevideo");
            unaPlantaIndustrial.AgregarDependencia(otraPlantaIndustrial);
            CollectionAssert.Contains(unaPlantaIndustrial.Dependencias, otraPlantaIndustrial);
            unaPlantaIndustrial.EliminarDependencia(otraPlantaIndustrial);
            CollectionAssert.DoesNotContain(unaPlantaIndustrial.Dependencias, otraPlantaIndustrial);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void AgregarVariablePlantaIndustrialTest()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("PL4", "Cuareim 2389", "Montevideo");
            Variable unaVariable = Variable.VariableInvalida();
            unaPlantaIndustrial.AgregarVariable(unaVariable);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void EliminarVariablePlantaIndustrialTest()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("PL4", "Cuareim 2389", "Montevideo");
            unaPlantaIndustrial.EliminarVariable(Variable.VariableInvalida());
        }

        [TestMethod]
        public void ToStringPlantaIndustrialTest()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad("GHY-12", "Cuareim 2389", "Montevideo");
            Assert.AreEqual("GHY-12 (P)", unaPlantaIndustrial.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void AgregarDependenciaCiclicaTest1()
        {
            PlantaIndustrial plantaIndustrial1 = PlantaIndustrial.PlantaIndustrialInvalida();
            PlantaIndustrial plantaIndustrial2 = PlantaIndustrial.PlantaIndustrialInvalida();
            PlantaIndustrial plantaIndustrial3 = PlantaIndustrial.PlantaIndustrialInvalida();
            plantaIndustrial1.AgregarDependencia(plantaIndustrial2);
            plantaIndustrial2.AgregarDependencia(plantaIndustrial3);
            plantaIndustrial3.AgregarDependencia(plantaIndustrial1);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void AgregarDependenciaCiclicaTest2()
        {
            PlantaIndustrial plantaIndustrial1 = PlantaIndustrial.PlantaIndustrialInvalida();
            PlantaIndustrial plantaIndustrial11 = PlantaIndustrial.PlantaIndustrialInvalida();
            plantaIndustrial1.AgregarDependencia(plantaIndustrial11);
            PlantaIndustrial plantaIndustrial2 = PlantaIndustrial.PlantaIndustrialInvalida();
            PlantaIndustrial plantaIndustrial21 = PlantaIndustrial.PlantaIndustrialInvalida();
            plantaIndustrial2.AgregarDependencia(plantaIndustrial21);
            plantaIndustrial11.AgregarDependencia(plantaIndustrial2);
            plantaIndustrial21.AgregarDependencia(plantaIndustrial1);
        }
    }
}
