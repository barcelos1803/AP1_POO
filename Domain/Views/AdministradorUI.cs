using Data.Context;
using Domain.Interfaces;

namespace Domain.Views
{
    
   public class AdministradorUI
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IEstacionamentoRepository _estacionamentoRepository;

        public AdministradorUI(IVeiculoRepository veiculoRepository, IEstacionamentoRepository estacionamentoRepository)
        {
            _veiculoRepository = veiculoRepository;
            _estacionamentoRepository = estacionamentoRepository;
        }

        public void Iniciar()
        {
            while (true)
            {
                Console.WriteLine("Digite a opcao desejada: ");
                Console.WriteLine("1 - Listar veiculos estacionados");
                Console.WriteLine("2 - Listar todos os veiculos");
                Console.WriteLine("3 - Sair");
                Console.WriteLine();

                string s = Console.ReadLine();

                switch (s)
                {
                    case "1":
                        var vagasOcupadas = _estacionamentoRepository.ObterVagasOcupadas();
                        foreach (var vaga in vagasOcupadas)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Vaga {vaga.Id}:\nTipo:{vaga.Veiculo.Tipo}\nPlaca:{vaga.Veiculo.Placa}\nModelo:{vaga.Veiculo.Modelo}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "2":
                        var todosVeiculos = _veiculoRepository.GetAll();
                        foreach (var veiculo in todosVeiculos)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Placa: {veiculo.Placa}\nModelo: {veiculo.Modelo}\nTipo: {veiculo.Tipo}");
                            Console.WriteLine();
                        }
                        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opcao invalida. Digite uma opcao valida.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}    