using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class Veiculo
{
   // Propriedades
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public virtual string Tipo { get { return "Veículo"; } }

    // Construtor
    public Veiculo(string placa, string modelo)
    {
        Placa = placa;
        Modelo = modelo;
    }

    // Método abstrato para calcular o valor da estadia
    public abstract decimal CalcularValorEstadia(int horas);

    // Método para exibir informações do veículo
    public virtual void ExibirDados()
    {
        Console.WriteLine($"Placa: {Placa}- Modelo: {Modelo} - Tipo: {Tipo}");
    }
}