using Pato.Services;
using Pato.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pato.Consola
{
    class Program
    {
        /// <summary>
        /// Años: son años Humanos. 
        /// Todos tienen 365 dias. (no se contempla biciestos)
        /// Si el triangulo no contiene al sol, entonces es incierto. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*
             * ● El planeta Ferengi se desplaza con una velocidad angular de 1 grados / día en sentido
             * horario.Su distancia con respecto al sol es de 500Km.
             * ● El planeta Betasoide se desplaza con una velocidad angular de 3 grados / día en sentido
             *  horario.Su distancia con respecto al sol es de 2000Km.
             * ● El planeta Vulcano se desplaza con una velocidad angular de 5 grados / día en sentido
             *  antihorario, su distancia con respecto al sol es de 1000Km.
             */

            var sistema = BigBang.CrearSistema();

            // Obtengo el clima de 10 años
            var resultados = new List<Resultado>();
            string[] arrayResult = new string[3650];

            for (int dia = 1; dia < 3650; dia++)
            { 
                var clima = sistema.GetClima(dia);
                resultados.Add(clima);               
            }

            // Proceso los resultados. 
            var periodos = new List<Periodo>();
            var periodo = new Periodo();

            var climaAnterior = resultados[0].Clima;
            var diaInicio = resultados[0].Dia;

            for (int i = 0; i < resultados.Count; i++)
            {
                var item = resultados[i];                

                if (climaAnterior != item.Clima || i == resultados.Count - 1)
                {
                    periodo.Clima = climaAnterior;
                    periodo.diaInicio = diaInicio;
                    periodo.diaFin = i == resultados.Count - 1 ? item.Dia : item.Dia - 1;

                    periodos.Add(periodo);

                    periodo = new Periodo();
                    diaInicio = item.Dia;
                }

                if (periodo.diaMaxLluvia > 0)
                    periodo.diaMaxLluvia = resultados[periodo.diaMaxLluvia - 1].Lluvia < item.Lluvia ? item.Dia : periodo.diaMaxLluvia;
                else
                    periodo.diaMaxLluvia = item.Lluvia > 0 ? item.Dia : 0;

                climaAnterior = item.Clima;
            }

            var periodosSequia = periodos.Where(x => x.Clima == Constants.Sequia).Count();
            var periodosLluvia = periodos.Where(x => x.Clima == Constants.Lluvia).Count();
            var picoLluvia = periodos.Where(x => x.Clima == Constants.Lluvia).Select(z => new { Inicio = z.diaInicio, Fin = z.diaFin, Pico = z.diaMaxLluvia }).ToList();
            var periodosOptimo = periodos.Where(x => x.Clima == Constants.Optimo).Count();

            Console.WriteLine(string.Format("Períodos de sequía: {0}", periodosSequia));
            Console.WriteLine(string.Format("Períodos de Lluvia: {0}", periodosLluvia));
            Console.WriteLine(string.Format("Días con pico de lluvia:"));
            foreach (var item in picoLluvia)
            {
                Console.WriteLine(string.Format("   Día inicio lluvia: {0} - Día fin lluvia {1} - Día pico lluvia: {2}", item.Inicio, item.Fin, item.Pico));
            }
            
            Console.WriteLine(string.Format("Períodos Optimos: {0}", periodosOptimo));
            Console.WriteLine("Presione tecla");
            Console.ReadKey();
        }
    }
}
