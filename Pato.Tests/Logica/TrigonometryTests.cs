using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pato.Services.Helpers;

namespace Pato.Services.Logica.Tests
{
    [TestClass()]
    public class TrigonometryTests
    {
        int delta = 1;

        [TestMethod()]
        public void TresEnLineaTest()
        {
            var pplaneta0 = new Posicion { X = 5, Y = 100 };
            var pplaneta1 = new Posicion { X = 200, Y = 100 };
            var pplaneta2 = new Posicion { X = -250, Y = 100 };

            var result = Trigonometry.Colinealidad(pplaneta0, pplaneta1, pplaneta2, delta);

            Assert.AreEqual(true, result, "Están en linea.");
        }

        [TestMethod()]
        public void TresEnLineaFailTest()
        {
            var pplaneta0 = new Posicion { X = 5, Y = 111 };
            var pplaneta1 = new Posicion { X = 200, Y = -100 };
            var pplaneta2 = new Posicion { X = -250, Y = 100 };

            var result = Trigonometry.Colinealidad(pplaneta0, pplaneta1, pplaneta2, delta);

            Assert.AreEqual(false, result, "No están en linea.");
        }

        [TestMethod()]
        public void CuatroEnLineaTest()
        {
            var pplaneta0 = new Posicion { X = 5, Y = 0 };
            var pplaneta1 = new Posicion { X = 200, Y = 0 };
            var pplaneta2 = new Posicion { X = -250, Y = 0 };
            var pSol = new Posicion { X = 0, Y = 0 };

            var result1 = Trigonometry.Colinealidad(pplaneta0, pplaneta1, pplaneta2, delta);
            var result2 = Trigonometry.Colinealidad(pplaneta0, pplaneta1, pSol, 1);

            Assert.AreEqual(true, result1 && result2, "Los 4 están en linea.");
        }

        [TestMethod()]
        public void CuatroEnLineaFailTest()
        {
            var pplaneta0 = new Posicion { X = 5, Y = 11 };
            var pplaneta1 = new Posicion { X = 200, Y = 11 };
            var pplaneta2 = new Posicion { X = -250, Y = 11 };
            var pSol = new Posicion { X = 0, Y = 0 };

            var result1 = Trigonometry.Colinealidad(pplaneta0, pplaneta1, pplaneta2, delta);
            var result2 = Trigonometry.Colinealidad(pplaneta0, pplaneta1, pSol, delta);

            Assert.AreEqual(false, result1 && result2, "Los 4 NO están en linea.");
        }

        [TestMethod()]
        public void CuatroEnLinea2Test()
        {
            var pplaneta0 = new Posicion { X = -1000, Y = 0 };
            var pplaneta1 = new Posicion { X = 500, Y = 0 };
            var pplaneta2 = new Posicion { X = 2000, Y = 0 };
            var pSol = new Posicion { X = 0, Y = 0 };

            var result1 = Trigonometry.Colinealidad(pplaneta0, pplaneta1, pplaneta2, delta);
            var result2 = Trigonometry.Colinealidad(pplaneta0, pplaneta1, pSol, delta);

            Assert.AreEqual(true, result1 && result2, "Los 4 están en linea.");
        }

        [TestMethod()]
        public void PuntoEnTrianguloTest()
        {
            var pplaneta0 = new Posicion { X = 766, Y = 642 };
            var pplaneta1 = new Posicion { X = -219, Y = -449 };
            var pplaneta2 = new Posicion { X = -1956, Y = -415 };
            var pSol = new Posicion { X = 0, Y = 0 };

            var result = Trigonometry.PuntoEnTriangulo(pplaneta0, pplaneta1, pplaneta2, pSol);

            Assert.AreEqual(true, result, "El punto está dentro del triangulo.");
        }

        [TestMethod()]
        public void PuntoEnTrianguloFailTest()
        {
            var pplaneta0 = new Posicion { X = 766, Y = 700 };
            var pplaneta1 = new Posicion { X = -219, Y = 700 };
            var pplaneta2 = new Posicion { X = -1956, Y = 700 };
            var pSol = new Posicion { X = 0, Y = 0 };

            var result = Trigonometry.PuntoEnTriangulo(pplaneta0, pplaneta1, pplaneta2, pSol);

            Assert.AreEqual(false, result, "El punto NO está dentro del triangulo.");
        }
    }
}