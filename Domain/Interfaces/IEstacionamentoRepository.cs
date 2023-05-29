using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEstacionamentoRepository : IBaseRepository<Vaga>
    {
        public  List<Vaga> ObterVagasOcupadas();
        public List<Vaga> ObterVagasLivres();
        public void Estacionar(Veiculo veiculo);
        public void Desocupar(int numero);
    }
}