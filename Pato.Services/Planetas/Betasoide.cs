using Pato.Services.Strategy;

namespace Pato.Services.Planetas
{
    public class Betasoide : Planeta
    {
        public Betasoide()
        {
            Strategy = new StrategyHorario();
            Nombre = "Betasoide";
            Velocidad = 3;
            Distancia = 2000;
            AnguloInicial = 0;
        }
    }
}
