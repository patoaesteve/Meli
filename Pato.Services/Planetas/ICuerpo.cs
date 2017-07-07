using Pato.Services.Helpers;

namespace Pato.Services.Planetas
{
    public interface ICuerpo
    {
        string Nombre { get; set; }

        Posicion GetPosicion(int dia);
    }
}
