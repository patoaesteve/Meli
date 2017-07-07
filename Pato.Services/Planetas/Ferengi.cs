using Pato.Services.Strategy;

namespace Pato.Services.Planetas
{
    public class Ferengi : Planeta
    {
        public Ferengi()
        {
            Strategy = new StrategyHorario();
            Nombre = "Ferengi";
            Velocidad = 1;
            Distancia = 500;
            AnguloInicial = 0;
        }
    }
}
