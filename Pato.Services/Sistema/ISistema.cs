using Pato.Services.Helpers;

namespace Pato.Services.Sistema
{
    public interface ISistema
    {
        Resultado GetClima(int dia);        
    }
}
