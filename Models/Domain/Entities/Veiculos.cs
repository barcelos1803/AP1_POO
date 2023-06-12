
namespace Models.Domain.Entities
{
    public abstract class Veiculo : Entity
    {
    // Propriedades
        public int ProprietarioId { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public virtual string Tipo { get { return "Veículo"; } }
        public Proprietario Proprietario { get; set; }
        public virtual ICollection<Vaga>Vagas { get; set; } // Propriedade de navegação reversa

        public Veiculo()
        {
            // Construtor sem parâmetros
        }

        // Método abstrato para calcular o valor da estadia
        public abstract decimal CalcularValorEstadia(int horas);

        // Método para exibir informações do veículo
        public virtual void ExibirDados()
        {
            Console.WriteLine($"proprietario: {Proprietario.Nome}Id: {Id}- Placa: {Placa}- Modelo: {Modelo} - Tipo: {Tipo}");
        }
    }
}