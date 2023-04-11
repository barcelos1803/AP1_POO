using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AdministradorUI
{
    public static void Show()
    {
        Console.WriteLine("Selecione uma opção:");
        Console.WriteLine("1 - Listar veículos estacionados");
        Console.WriteLine("2 - Mostrar quantidade de vagas livres");
        Console.WriteLine("3 - Calcular dívida de um veículo");
        Console.WriteLine("4 - Pesquisar veículo por placa");
        Console.WriteLine("5 - Voltar menu usuário");
        Console.WriteLine("6 - Sair");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                ListarVeiculosEstacionados();
                break;
            case 2:
                MostrarQuantidadeVagasLivres();
                break;
            case 3:
                CalcularDividaVeiculo();
                break;
            case 4:
                PesquisarVeiculoPorPlaca();
                break;
            case 5:
                EstacionamentoUI.Iniciar();
                break;
            case 6:
                Console.WriteLine("Saindo...");
                return;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }

        Show();
    }
    public static void ListarVeiculosEstacionados()
    {
        Console.WriteLine("Veículos estacionados:");

        var vagasOcupadas = EstacionamentoRepository.ObterVagasOcupadas();
        foreach (var vaga in vagasOcupadas)
        {
            Console.WriteLine(" ");
            Console.WriteLine($"Vaga {vaga.Numero}:");
            vaga.Veiculo.ExibirDados();
            Console.WriteLine(" ");
        }
        Console.WriteLine(" ");
        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
        Console.ReadKey();
    }

    public static void MostrarQuantidadeVagasLivres()
    {
        var vagasLivres = EstacionamentoRepository.ObterVagasLivres();
        int quantidadeVagasLivres = vagasLivres.Count;

        Console.WriteLine(" ");
        Console.WriteLine($"Quantidade de vagas livres: {quantidadeVagasLivres}");
        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
        Console.ReadKey();
    }

    public static void CalcularDividaVeiculo()
    {
        Console.WriteLine(" ");
        Console.Write("Digite a placa do veículo: ");
        string placa = Console.ReadLine();

        var veiculo = VeiculosRepository.ObterTodos().FirstOrDefault(v => v.Placa == placa);
        if (veiculo == null)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Veículo não encontrado.");
            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
            Console.WriteLine(" ");
            Console.ReadKey();
            return;
        }

        var vaga = EstacionamentoRepository.ObterVagas().FirstOrDefault(v => v.Veiculo == veiculo);
        if (vaga == null || !vaga.Ocupada)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Veículo não está estacionado.");
            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
            Console.WriteLine(" ");
            Console.ReadKey();
            return;
        }
        Console.WriteLine(" ");
        Console.Write("Digite a quantidade de horas: ");
        Console.WriteLine(" ");
        int horas = int.Parse(Console.ReadLine());

        decimal divida = vaga.Veiculo.CalcularValorEstadia(horas);

        Console.WriteLine("=== Informações do veículo ===");
        veiculo.ExibirDados();
        Console.WriteLine($"A dívida do veículo é de R$ {divida:F2}");
        Console.WriteLine(" ");
        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
        Console.WriteLine(" ");
        Console.ReadKey();
    }
    public static void PesquisarVeiculoPorPlaca()
    {
        Console.WriteLine(" ");
        Console.WriteLine("Digite a placa do veículo:");
        Console.WriteLine(" ");
        string placa = Console.ReadLine();
        var veiculo = VeiculosRepository.ObterPorPlaca(placa);
        if (veiculo != null)
        {
            Console.WriteLine(" ");
            Console.WriteLine("=== Informações do veículo ===");
            veiculo.ExibirDados();
            Console.WriteLine("=== Informações do veículo ===");
            Console.WriteLine(" ");
        }
        else
        {
            Console.WriteLine(" ");
            Console.WriteLine("Veículo não encontrado.");
            Console.WriteLine(" ");
        }
        Console.WriteLine(" ");
        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
        Console.ReadKey();
    }
}