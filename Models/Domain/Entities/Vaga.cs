
namespace Models.Domain.Entities
{
    public class Vaga : Entity
    {
        // Propriedades
        public int Numero { get; set; }
        public bool Ocupada { get; set; }
        public Veiculo Veiculo { get; set; }

        // Construtor
        public Vaga(int numero)
        {
            Numero = numero;
            Ocupada = false;
        }
        public Vaga()
        {
            
        }

        //     public void Ocupar(Veiculo veiculo)
        // {
        //     Ocupada = true;
        //     Veiculo = veiculo;
        // }

        //     public void Desocupar()
        // {
        //     Ocupada = false;
        //     Veiculo = null;
        // }
    }
}