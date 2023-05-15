using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Moto : Veiculo
{
    public override string Tipo { get { return "Moto"; } }

    public string Cor { get; private set; }

        // Construtor
    public Moto(string placa, string modelo) : base(placa, modelo)
    {
    }
    public Moto(string placa, string modelo, string cor) : base(placa, modelo)
    {
        Cor = cor;
    }

    // Implementação do método para calcular o valor da estadia para motos
    public override decimal CalcularValorEstadia(int horas)
    {
        return horas * 5;
    }

    // Sobrescrita do método ExibirDados para incluir informações específicas de motos
    public override void ExibirDados()
    {
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Modelo da moto: {Modelo}");
            Console.WriteLine($"Tipo: {Tipo}");
    }

}