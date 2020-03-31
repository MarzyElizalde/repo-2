using Entities;
using System.Threading.Tasks;

namespace Business
{
    public interface IBsTurno
    {
        Task<int> agregaTurnoJsonAsync(Turno turno);
    }
}
