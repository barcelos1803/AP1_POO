namespace Models.Domain.Entities
{
    public class Moto : Veiculo
    {
        public Moto(string placa, string modelo)
        {
            Placa = placa;
            Modelo = modelo;
        }

        public override string Tipo { get { return "Moto"; } }



        // Implementação do método para calcular o valor da estadia para motos
        public override decimal CalcularValorEstadia(int horas)
        {
            return horas * 5;
        }

        // Sobrescrita do método ExibirDados para incluir informações específicas de motos
        public override void ExibirDados()
        {
                Console.WriteLine($"Proprietario: {Proprietario.Nome}");
                Console.WriteLine($"Placa: {Id}");
                Console.WriteLine($"Placa: {Placa}");
                Console.WriteLine($"Modelo da moto: {Modelo}");
                Console.WriteLine($"Tipo: {Tipo}");
        }

    }
}