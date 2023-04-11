using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class EstacionamentoRepository
{
    private static List<Vaga> _vagas;

        //construtor
    static EstacionamentoRepository()
    {
        _vagas = new List<Vaga>();

        // Inicializa as vagas
        for (int i = 1; i <= 20; i++)
        {
            _vagas.Add(new Vaga(i));
        }
    }

    // Retorna todas as vagas
    public static List<Vaga> ObterVagas()
    {
        return _vagas;
    }

    // Retorna uma vaga pelo número
    public static Vaga ObterVaga(int numero)
    {
        return _vagas.Find(v => v.Numero == numero);
    }

    // Retorna as vagas ocupadas
    public static List<Vaga> ObterVagasOcupadas()
    {
        return _vagas.FindAll(v => v.Ocupada == true);
    }

    // Retorna as vagas livres
    public static List<Vaga> ObterVagasLivres()
    {
        return _vagas.FindAll(v => v.Ocupada == false);
    }

    // Estaciona um veículo em uma vaga livre
    public static void Estacionar(Veiculo veiculo)
    {
        var vaga = _vagas.FirstOrDefault(v => v.Ocupada == false);

        if (vaga != null)
        {
            vaga.Ocupar(veiculo);
        }
        else
        {
            throw new Exception("Não há vagas livres.");
        }
    }

    // Desocupa uma vaga
    public static void Desocupar(int numero)
    {
        var vaga = _vagas.FirstOrDefault(v => v.Numero == numero);

        if (vaga != null)
        {
            vaga.Desocupar();
        }
    }
        
} 
