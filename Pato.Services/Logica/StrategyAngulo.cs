using System;

namespace Pato.Services.Strategy
{
    public abstract class StrategyAngulo
    {
        public abstract int GetAngulo(int anguloInit, int vel, int dia);
    }

    public class StrategyHorario : StrategyAngulo
    {
        public override int GetAngulo(int anguloInit, int vel, int dia)
        {
            // Calculo el angulo con la velocidad y el dia.
            var angulo = anguloInit + vel * dia;

            if (Math.Abs(angulo) > 360)
            {
                int resto = angulo % 360;

                angulo = resto;
            }

            return angulo;
        }
    }

    public class StrategyAntiHorario : StrategyAngulo
    {
        public override int GetAngulo(int anguloInit, int vel, int dia)
        {
            // Calculo el angulo con la velocidad y el dia.
            var angulo = anguloInit + vel* dia;

            if (Math.Abs(angulo) > 360)
            {
                return angulo % 360;
            }
            else
            {
                return 360 - Math.Abs(angulo);
            }
        }
    }    
}
