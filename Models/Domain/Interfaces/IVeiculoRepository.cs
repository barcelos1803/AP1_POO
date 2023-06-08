using Models.Domain.Entities;

namespace Models.Domain.Interfaces
{
    public interface IVeiculoRepository : IBaseRepository<Veiculo>
    {
        Veiculo ObterPorPlaca(string placa);
    }
}