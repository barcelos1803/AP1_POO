

namespace Models.Domain.Entities
{
    public class Proprietario : Entity
    {
        public Proprietario(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public Proprietario()
        {
            
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }

        public IList<Veiculo> Veiculos { get; set; }
    }
}