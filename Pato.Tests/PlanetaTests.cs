using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pato.Services.Helpers;
using Pato.Services.Planetas;

namespace Pato.Services.Tests
{
    [TestClass()]
    public class PlanetaTests
    {
        [TestMethod()]
        public void PlanetaFerengi_Dia90_Test()
        {
            int dia = 90;
            var posExpected = new Posicion { X = 500, Y = 0};

            var planet = new Ferengi();

            var xy = planet.GetPosicion(dia);            
            Assert.AreEqual(posExpected.X, xy.X);
            Assert.AreEqual(posExpected.Y, xy.Y);
        }

        [TestMethod()]
        public void PlanetaFerengi_Dia180_Test()
        {
            int dia = 180;
            var posExpected = new Posicion { X = 0, Y = -500 };

            var planet = new Ferengi();

            var xy = planet.GetPosicion(dia);
            Assert.AreEqual(posExpected.X, xy.X);
            Assert.AreEqual(posExpected.Y, xy.Y);
        }

        [TestMethod()]
        public void PlanetaBetasoide_Dia30_Test()
        {
            var posExpected = new Posicion { X = 2000, Y = 0 };
            int dia = 30;

            var planet = new Betasoide();

            var xy = planet.GetPosicion(dia);
            Assert.AreEqual(posExpected.X, xy.X);
            Assert.AreEqual(posExpected.Y, xy.Y);
        }

        [TestMethod()]
        public void PlanetaBetasoide_Dia60_Test()
        {
            var posExpected = new Posicion { X = 0, Y = -2000 };
            int dia = 60;

            var planet = new Betasoide();

            var xy = planet.GetPosicion(dia);
            Assert.AreEqual(posExpected.X, xy.X);
            Assert.AreEqual(posExpected.Y, xy.Y);
        }

        [TestMethod()]
        public void PlanetaVulcano_Dia54_Test()
        {
            var posExpected = new Posicion { X = 1000, Y = 0 };
            int dia = 54;

            var planet = new Vulcano();

            var xy = planet.GetPosicion(dia);
            Assert.AreEqual(posExpected.X, xy.X);
            Assert.AreEqual(posExpected.Y, xy.Y);
        }

        [TestMethod()]
        public void PlanetaVulcano_Dia36_Test()
        {
            var posExpected = new Posicion { X = 0, Y = -1000 };
            int dia = 36;

            var planet = new Vulcano();

            var xy = planet.GetPosicion(dia);
            Assert.AreEqual(posExpected.X, xy.X);
            Assert.AreEqual(posExpected.Y, xy.Y);
        }
    }
}