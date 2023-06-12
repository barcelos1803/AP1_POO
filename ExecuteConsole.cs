// using Models.Data.Context;
// using Models.Data.Repositories;
// using Models.Domain.Entities;
// using Models.Domain.Interfaces;
// using Models.Domain.Views;

// public class ExecuteConsole
// {
//     static void ExecuteConsoleLog(string[] args)
//     {
//         var db = new DataContext();
//         IVeiculoRepository veiculoRepository = new VeiculosRepository();
//         IEstacionamentoRepository estacionamentoRepository = new EstacionamentoRepository();

//         EstacionamentoRepository.InicializarEstacionamento(estacionamentoRepository, 20);

//         IProprietarioRepository proprietarioRepository = new ProprietarioRepository();

//         EstacionamentoUI estacionamentoUI = new EstacionamentoUI(veiculoRepository, estacionamentoRepository, proprietarioRepository);
//         estacionamentoUI.Iniciar();
//     }
// }
