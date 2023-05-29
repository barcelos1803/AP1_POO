namespace Domain.Entities
{
    public class Carro : Veiculo
    {
        public Carro(string placa, string modelo)
        {
            Placa = placa;
            Modelo = modelo;
        }

        public override string Tipo { get { return "Carro"; } }


        // Implementação do método para calcular o valor da estadia para carros
        public override decimal CalcularValorEstadia(int horas)
        {
            return horas * 10;
        }

        // Sobrescrita do método ExibirDados para incluir informações específicas de carros
        public override void ExibirDados()
        {
                Console.WriteLine($"Proprietario: {Proprietario.Nome}");
                Console.WriteLine($"id: {Id}");
                Console.WriteLine($"Placa: {Placa}");
                Console.WriteLine($"Modelo do carro: {Modelo}");
                Console.WriteLine($"Tipo: {Tipo}");
        }
    }
}