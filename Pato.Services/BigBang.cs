using Pato.Services.Planetas;
using Pato.Services.Sistema;
using System.Collections.Generic;

namespace Pato.Services
{
    public class BigBang
    {
        private static ISistema _sistema;

        protected BigBang()
        {
        }

        public static ISistema CrearSistema()
        {
            if (_sistema == null)
            {
                var deltaColinealidad = 1;
                var sol = new Sol();

                var planetas = new List<IPlaneta>();
                planetas.Add(new Ferengi());
                planetas.Add(new Betasoide());
                planetas.Add(new Vulcano());

                _sistema = new Sistema.Sistema(planetas, sol, deltaColinealidad);
            }

            return _sistema;
        }
    }
}