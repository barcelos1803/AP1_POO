using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Carro : Veiculo
{
    public override string Tipo { get { return "Carro"; } }

    public Carro(string placa, string modelo) : base(placa, modelo)
    {
    }
    // Implementação do método para calcular o valor da estadia para carros
    public override decimal CalcularValorEstadia(int horas)
    {
        return horas * 10;
    }

    // Sobrescrita do método ExibirDados para incluir informações específicas de carros
    public override void ExibirDados()
    {
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Tipo: {Tipo}");
    }
}