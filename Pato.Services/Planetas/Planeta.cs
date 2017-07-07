using Pato.Services.Helpers;
using Pato.Services.Logica;
using Pato.Services.Strategy;

namespace Pato.Services.Planetas
{
    public abstract class Planeta : IPlaneta
    {
        public string Nombre { get; set; }
        public int Velocidad { get; set; }
        public int Distancia { get; set; }
        public int AnguloInicial { get; set; }

        public StrategyAngulo Strategy { get; set; }

        public Posicion GetPosicion(int dia)
        {
            var angulo = Strategy.GetAngulo(AnguloInicial, Velocidad, dia);

            var xyPos = Trigonometry.DegreesToXY(angulo, Distancia);

            return xyPos;
        }
    }
}
