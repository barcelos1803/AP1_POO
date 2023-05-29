﻿using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Views
{
    public class EstacionamentoUI
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IEstacionamentoRepository _estacionamentoRepository;
        private readonly IProprietarioRepository _proprietarioRepository;

        public EstacionamentoUI(IVeiculoRepository veiculoRepository, IEstacionamentoRepository estacionamentoRepository, IProprietarioRepository proprietarioRepository)
        {
            _veiculoRepository = veiculoRepository;
            _estacionamentoRepository = estacionamentoRepository;
            _proprietarioRepository = proprietarioRepository;
        }

        public void Iniciar()
        {
            while (true)
            {
                Console.WriteLine("Digite a opção desejada: ");
                Console.WriteLine("1 - Estacionar veículo");
                Console.WriteLine("2 - Desocupar vaga");
                Console.WriteLine("3 - Listar veículos estacionados");
                Console.WriteLine("4 - Menu ADM");
                Console.WriteLine("5 - Sair");
                Console.WriteLine();

                string s = Console.ReadLine();

                switch (s)
                {
                    case "1":
                        Console.WriteLine("Digite o Nome do proprietário: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Digite o CPF do proprietário: ");
                        string cpf = Console.ReadLine();

                        Console.WriteLine("Digite a placa do veículo: ");
                        string placa = Console.ReadLine();

                        Console.WriteLine("Digite o modelo do veículo: ");
                        string modelo = Console.ReadLine();

                        Console.WriteLine("Digite o tipo do veículo (1 - Carro, 2 - Moto): ");
                        string tipoVeiculo = Console.ReadLine();
                        
                        Proprietario proprietario = new Proprietario(nome, cpf);
                        Veiculo veiculo;

                        switch (tipoVeiculo)
                        {
                            case "1":
                                veiculo = new Carro(placa, modelo);
                                veiculo.Proprietario = proprietario;
                                break;
                            case "2":
                                veiculo = new Moto(placa, modelo);
                                veiculo.Proprietario = proprietario;
                                break;
                            default:
                                Console.WriteLine("Tipo de veículo inválido.");
                                continue;
                        }

                        try
                        {
                            _estacionamentoRepository.Estacionar(veiculo);
                            _veiculoRepository.Save(veiculo);
                            _proprietarioRepository.Save(proprietario);

                            Console.WriteLine();
                            Console.WriteLine("== VEÍCULO REGISTRADO ==");
                            Console.WriteLine($"Placa: {placa}\nModelo: {modelo}\nTipo: {veiculo.Tipo}");
                            Console.WriteLine($"Proprietário: {proprietario.Nome} (CPF: {proprietario.Cpf})");
                            Console.WriteLine("== VEÍCULO REGISTRADO ==");
                            Console.WriteLine();

                            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine();

                            Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                            Console.ReadKey();
                            Console.WriteLine();
                        }
                        break;
                    case "2":
                        Console.WriteLine("Digite o número da vaga: ");
                        int numeroVaga = Convert.ToInt32(Console.ReadLine());

                        _estacionamentoRepository.Desocupar(numeroVaga);
                        Console.WriteLine();
                        Console.WriteLine($"Vaga {numeroVaga} desocupada.");
                        Console.WriteLine();

                        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "3":
                        var vagasOcupadas = _estacionamentoRepository.ObterVagasOcupadas();
                        foreach (var vaga in vagasOcupadas)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Vaga {vaga.Id}:\nTipo: {vaga.Veiculo.Tipo}\nPlaca: {vaga.Veiculo.Placa}\nModelo: {vaga.Veiculo.Modelo}");
                            if (vaga.Veiculo.Proprietario != null)
                            {
                                Console.WriteLine($"Proprietário: {vaga.Veiculo.Proprietario.Nome} (CPF: {vaga.Veiculo.Proprietario.Cpf})");
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                    case "4":
                        AdministradorUI administradorUI = new AdministradorUI(_veiculoRepository, _estacionamentoRepository);
                        administradorUI.Iniciar();
                        break;
                    case "5":
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Digite uma opção válida.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}