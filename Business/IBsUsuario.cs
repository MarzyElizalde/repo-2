using Models;
using System.Threading.Tasks;

namespace Business
{
    public interface IBsUsuario
    {
        Task<int> agregarUsuario(Usuario usuario);
    }
}
