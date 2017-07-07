using Pato.Services.Helpers;

namespace Pato.Services.Planetas
{
    public class Sol : ICuerpo
    {
        public Sol()
        {
            Nombre = "Sol";
        }

        public string Nombre { get; set; }    

        public Posicion GetPosicion(int dia)
        {
            return new Posicion { X = 0, Y = 0 };
        }
    }
}
