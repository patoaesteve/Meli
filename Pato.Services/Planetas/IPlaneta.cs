using Pato.Services.Helpers;

namespace Pato.Services.Planetas
{
    public interface IPlaneta
    {
        int Velocidad { get; set; }
        int Distancia { get; set; }
        int AnguloInicial { get; set; }
        string Nombre { get; set; }
        Posicion GetPosicion(int dia);
    }
}
