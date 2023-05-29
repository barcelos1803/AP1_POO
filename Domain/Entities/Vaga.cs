
namespace Domain.Entities
{
    public class Vaga : Entity
    {
        // Propriedades
        public bool Ocupada { get; private set; }
        public Veiculo Veiculo { get; private set; }

        // Construtor
        public Vaga(int id)
        {
            Id = id;
            Ocupada = false;
        }

            public void Ocupar(Veiculo veiculo)
        {
            Ocupada = true;
            Veiculo = veiculo;
        }

            public void Desocupar()
        {
            Ocupada = false;
            Veiculo = null;
        }
    }
}