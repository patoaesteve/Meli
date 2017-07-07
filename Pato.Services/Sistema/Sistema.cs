using Pato.Services.Helpers;
using Pato.Services.Logica;
using Pato.Services.Planetas;
using System.Collections.Generic;

namespace Pato.Services.Sistema
{
    public class Sistema : ISistema
    {
        IList<IPlaneta> _planetas;
        ICuerpo _sol;
        int _deltaColinealidad;

        public Sistema(IList<IPlaneta> planetasInit, ICuerpo solInit, int deltaColinealidad)
        {
            _planetas = planetasInit;
            _sol = solInit;
            _deltaColinealidad = deltaColinealidad;
        }

        public Resultado GetClima(int dia)
        {
            if (Trigonometry.Colinealidad(_planetas[0].GetPosicion(dia), _planetas[1].GetPosicion(dia), _planetas[2].GetPosicion(dia), _deltaColinealidad))
            {
                // Si los 3 planetas están en linea, reemplazo cualquiera de ellos por el sol, y verifico si tmb están en linea. 
                if (Trigonometry.Colinealidad(_planetas[0].GetPosicion(dia), _planetas[1].GetPosicion(dia), _sol.GetPosicion(dia), _deltaColinealidad))
                    return new Resultado { Dia = dia, Clima = Constants.Sequia, Lluvia = 0 };

                return new Resultado { Dia = dia, Clima = Constants.Optimo, Lluvia = 0 };
            }

            if (Trigonometry.PuntoEnTriangulo(_planetas[0].GetPosicion(dia), _planetas[1].GetPosicion(dia), _planetas[2].GetPosicion(dia), _sol.GetPosicion(dia)))
            {
                return new Resultado { Dia = dia, Clima = Constants.Lluvia, Lluvia = Trigonometry.GetPerimetro(_planetas[0].GetPosicion(dia), _planetas[1].GetPosicion(dia), _planetas[2].GetPosicion(dia)) };
            }

            return new Resultado { Dia = dia, Clima = Constants.Confuso, Lluvia = 0 };
        }
    }
}
