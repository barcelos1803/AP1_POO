using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class VeiculosRepository
{
    private static List<Veiculo> _veiculos;

    //construtuor
    static VeiculosRepository()
    {
        _veiculos = new List<Veiculo>();
    }

    // Adiciona um veículo
    public static void Adicionar(Veiculo veiculo)
    {
        _veiculos.Add(veiculo);
    }

    // Retorna todos os veículos
    public static List<Veiculo> ObterTodos()
    {
        return _veiculos;
    }

    // Retorna um veículo pela placa
    public static Veiculo ObterPorPlaca(string placa)
    {
        return _veiculos.Find(v => v.Placa == placa);
    }
}

