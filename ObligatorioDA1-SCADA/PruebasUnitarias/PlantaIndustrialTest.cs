using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasUnitarias
{
    [TestClass]
    public class PlantaIndustrialTest
    {
        [TestMethod]
        public void PlantaInvalidaTest()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            Assert.AreEqual("Planta industrial inválida.", unaPlantaIndustrial.Nombre);
            Assert.AreEqual("Dirección inválida.", unaPlantaIndustrial.Direccion);
            Assert.AreEqual("Ciudad inválida.", unaPlantaIndustrial.Ciudad);
            Assert.AreEqual(0, unaPlantaIndustrial.Dependencias.Count);
        }

        [TestMethod]
        public void SetDireccionPlantaIndustrialTest1()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Direccion = "Cuareim 2389";
            Assert.AreEqual("Cuareim 2389", unaPlantaIndustrial.Direccion);
        }

        [TestMethod]
        public void SetDireccionPlantaIndustrialTest2Trim()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Direccion = "  18 de julio ap. 101  ";
            Assert.AreEqual("18 de julio ap. 101", unaPlantaIndustrial.Direccion);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetDireccionPlantaIndustrialTest3Invalida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Direccion = "12345";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetDireccionPlantaIndustrialTest4Invalida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Direccion = "asdasd";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetDireccionPlantaIndustrialTest5Invalida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Direccion = "$%)(/ ,. %#$";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetDireccionPlantaIndustrialTest6Invalida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Direccion = "";
        }

        [TestMethod]
        public void SetCiudadPlantaIndustrialTest1()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Ciudad = "Montevideo";
            Assert.AreEqual("Montevideo", unaPlantaIndustrial.Ciudad);
        }

        [TestMethod]
        public void SetCiudadPlantaIndustrialTest2Trim()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Ciudad = "  Buenos Aires  ";
            Assert.AreEqual("Buenos Aires", unaPlantaIndustrial.Ciudad);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetCiudadPlantaIndustrialTest3Inválida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Ciudad = "Montevideo-123";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetCiudadPlantaIndustrialTest4Inválida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Ciudad = "12345";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetCiudadPlantaIndustrialTest5Inválida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
            unaPlantaIndustrial.Ciudad = "  !#,. $%&/ ";
        }

        [TestMethod]
        [ExpectedException(typeof(ElementoSCADAExcepcion))]
        public void SetCiudadPlantaIndustrialTest6Inválida()
        {
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.PlantaInvalida();
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
            PlantaIndustrial unaPlantaIndustrial = PlantaIndustrial.NombreDireccionCiudad(" 2PL-1", " 1eim 2389 ", " Montevideo ");
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
    }
}
