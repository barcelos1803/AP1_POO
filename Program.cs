using Data.Context;
using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Views;

public class Program
{
    static void Main(string[] args)
    {
        var db = new DataContext();
        IVeiculoRepository veiculoRepository = new VeiculosRepository(db);
        IEstacionamentoRepository estacionamentoRepository = new EstacionamentoRepository(db);

        EstacionamentoRepository.InicializarEstacionamento(estacionamentoRepository, 20);

        IProprietarioRepository proprietarioRepository = new ProprietarioRepository(db);

        EstacionamentoUI estacionamentoUI = new EstacionamentoUI(veiculoRepository, estacionamentoRepository, proprietarioRepository);
        estacionamentoUI.Iniciar();
    }
}
