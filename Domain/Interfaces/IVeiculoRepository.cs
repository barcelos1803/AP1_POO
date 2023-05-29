using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Veiculo ObterPorPlaca(string placa);
    }
}