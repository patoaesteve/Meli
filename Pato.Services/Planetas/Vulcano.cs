using Pato.Services.Strategy;

namespace Pato.Services.Planetas
{
    public class Vulcano : Planeta
    {
        public Vulcano()
        {
            Strategy = new StrategyAntiHorario();
            Nombre = "Vulcano";
            Velocidad = -5;
            Distancia = 1000;
            AnguloInicial = 0;
        }
    }
}
