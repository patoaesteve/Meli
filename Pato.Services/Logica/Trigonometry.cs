using Pato.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pato.Services.Logica
{
    public static class Trigonometry
    {
        /// <summary>
        /// Determina si un punto [x,y] está en el triangulo formado por los puntos p0, p1, p2.
        /// </summary>
        /// <param name="p0">Punto x,y perteneciente al triangulo</param>
        /// <param name="p1">Punto x,y perteneciente al triangulo</param>
        /// <param name="p2">Punto x,y perteneciente al triangulo</param>
        /// <param name="sol">Punto a determinar si es contenido en el triangulo. </param>
        /// <returns>True en caso de que se contenga. False caso contrario. </returns>
        public static bool PuntoEnTriangulo(Posicion p0, Posicion p1, Posicion p2, Posicion sol)
        {
            double area = 0.5 * (-p1.Y * p2.X + p0.Y * (-p1.X + p2.X) + p0.X * (p1.Y - p2.Y) + p1.X * p2.Y);
            int signo = area < 0 ? -1 : 1;

            //coordenadas baricéntricas para determinar si un punto está contenido en un triangulo.
            double s = (p0.Y * p2.X - p0.X * p2.Y + (p2.Y - p0.Y) * sol.X + (p0.X - p2.X) * sol.Y) * signo;
            double t = (p0.X * p1.Y - p0.Y * p1.X + (p0.Y - p1.Y) * sol.X + (p1.X - p0.X) * sol.Y) * signo;

            return s > 0 && t > 0 && (s + t) < 2 * area * signo;
        }

        /// <summary>
        /// Determina la colinelidad de 3 puntos. (Si los 3 puntos están en la misma linea). 
        /// </summary>
        /// <param name="p0">Posicion del punto A </param>
        /// <param name="p1">Posicion del punto B</param>
        /// <param name="p2">Posicion del punto C</param>
        /// <param name="deltaColinealidad">Delta para manejar el error. AC ~ AB + BC </param>
        /// <returns>True si son colineales. False caso contrario.</returns>        
        public static bool Colinealidad(Posicion p0, Posicion p1, Posicion p2, int deltaColinealidad)
        {
            var dist1 = GetDistancia(p0, p1);
            var dist2 = GetDistancia(p1, p2);
            var dist3 = GetDistancia(p0, p2);

            var distancias = new List<double>();
            distancias.Add(GetDistancia(p0, p1));
            distancias.Add(GetDistancia(p1, p2));
            distancias.Add(GetDistancia(p0, p2));

            var ac = distancias.Max();
            var ab_bc = distancias.Where(x => x != ac).ToList();

            if (ac - deltaColinealidad >= (ab_bc[0] + ab_bc[1]) || (ab_bc[0] + ab_bc[1]) <= ac + deltaColinealidad)
                return true;

            return false;

            //double area = Math.Round(0.5 * (-p1.Y * p2.X + p0.Y * (-p1.X + p2.X) + p0.X * (p1.Y - p2.Y) + p1.X * p2.Y), 1);
            //return area == 0 || Math.Abs(area) <= Constants.DeltaMismaLinea;            
        }

        /// <summary>
        /// Obtiene el perimetro del triangulo formado por los puntos pasados por parametro. 
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Perimetro</returns>
        public static double GetPerimetro(Posicion p0, Posicion p1, Posicion p2)
        {
            var distancia_p0p1 = Math.Sqrt(Math.Pow(p1.X - p0.X, 2) + Math.Pow(p1.Y - p0.Y, 2));
            var distancia_p1p2 = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            var distancia_p0p2 = Math.Sqrt(Math.Pow(p2.X - p0.X, 2) + Math.Pow(p2.Y - p0.Y, 2));

            return Math.Round(distancia_p0p1 + distancia_p1p2 + distancia_p0p2, Constants.Decimales);
        }

        /// <summary>
        /// Devuelve la distancia entre dos puntos. 
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns>Distancia entre point1 y point2</returns>
        public static double GetDistancia(Posicion point1, Posicion point2)
        {
            //pythagorean theorem c^2 = a^2 + b^2
            //thus c = square root(a^2 + b^2)
            double a = (double)(point2.X - point1.X);
            double b = (double)(point2.Y - point1.Y);

            return Math.Sqrt(a * a + b * b);
        }

        /// <summary>
        /// Convierte un angulo, a una posicion X,Y en cartesiano. 
        /// </summary>
        /// <param name="degrees">Angulo</param>
        /// <param name="radius">Radio</param>
        /// <returns></returns>
        public static Posicion DegreesToXY(double degrees, double radius)
        {
            Posicion xy = new Posicion();
            double radians = degrees * Math.PI / 180.0;

            xy.Y = Math.Round(Math.Cos(radians) * radius, Constants.Decimales);
            xy.X = Math.Round(Math.Sin(radians) * radius, Constants.Decimales);

            return xy;
        }
    }
}
