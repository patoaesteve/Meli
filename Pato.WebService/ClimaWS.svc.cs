using Pato.Services;
using Pato.Services.Planetas;
using Pato.Services.Strategy;
using System;
using System.Collections.Generic;

namespace Pato.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ClimaWS : IClimaWS
    {
        public ClimaResponse Clima(int dia)
        {
            var planeta1 = new Planeta(new StrategyHorario());
            planeta1.Nombre = "Ferengi";
            planeta1.Velocidad = 1;
            planeta1.Distancia = 500;
            planeta1.AnguloInicial = 0;

            var planeta2 = new Planeta(new StrategyHorario());
            planeta2.Nombre = "Betasoide";
            planeta2.Velocidad = 3;
            planeta2.Distancia = 2000;
            planeta2.AnguloInicial = 0;

            var planeta3 = new Planeta(new StrategyAntiHorario());
            planeta3.Nombre = "Vulcano";
            planeta3.Velocidad = -5;
            planeta3.Distancia = 1000;
            planeta3.AnguloInicial = 0;

            var planetas = new List<IPlaneta>();
            planetas.Add(planeta1);
            planetas.Add(planeta2);
            planetas.Add(planeta3);

            var sistema = new Sistema(planetas, new Sol { Nombre = "Sol" }, 1);

            var ret = new ClimaResponse();
            ret.Dia = dia;
            ret.Clima = sistema.GetClima(dia).Clima;

            return ret;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
