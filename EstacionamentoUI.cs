public class EstacionamentoUI 
{
    public static void Iniciar()
    {
        while (true)
        {
            Console.WriteLine("Digite a opcao desejada: ");
            Console.WriteLine("1 - Estacionar veiculo");
            Console.WriteLine("2 - Desocupar vaga");
            Console.WriteLine("3 - Listar veiculos estacionados");
            Console.WriteLine("4 - Menu ADM");
            Console.WriteLine("5 - Sair");
            Console.WriteLine(" ");

            string s = Console.ReadLine();

            switch (s)
            {
                case "1":
                    Console.WriteLine("Digite a placa do veiculo: ");
                    string placa = Console.ReadLine();

                    Console.WriteLine("Digite o modelo do veiculo: ");
                    string modelo = Console.ReadLine();

                    Console.WriteLine("Digite o tipo do veiculo (1 - Carro, 2 - Moto): ");
                    string tipoVeiculo = Console.ReadLine();

                    Veiculo veiculo;

                    switch (tipoVeiculo)
                    {
                        case "1":
                            veiculo = new Carro(placa, modelo);
                            break;
                        case "2":
                            veiculo = new Moto(placa, modelo);
                            break;
                        default:
                            Console.WriteLine("Tipo de veiculo invalido.");
                            continue;
                    }

                    try
                    {
                        EstacionamentoRepository.Estacionar(veiculo);
                        VeiculosRepository.Adicionar(veiculo);
                        Console.WriteLine(" ");
                        Console.WriteLine("==VEICULO REGISTRADO==");
                        Console.WriteLine($"Placa: {placa}\nModelo: {modelo}\nTipo: {veiculo.Tipo}");
                        Console.WriteLine("==VEICULO REGISTRADO==");
                        Console.WriteLine(" ");
                        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                        Console.ReadKey();
                        Console.WriteLine(" ");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(" ");
                        Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                        Console.ReadKey();
                        Console.WriteLine(" ");
                    }
                    break;
                case "2":
                    Console.WriteLine("Digite o numero da vaga: ");
                    int numeroVaga = Convert.ToInt32(Console.ReadLine());

                    EstacionamentoRepository.Desocupar(numeroVaga);
                    Console.WriteLine(" ");
                    Console.WriteLine($"Vaga {numeroVaga} desocupada.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.WriteLine(" ");
                    break;
                case "3":
                    var vagasOcupadas = EstacionamentoRepository.ObterVagasOcupadas();
                    foreach (var vaga in vagasOcupadas)
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine($"Vaga {vaga.Numero}:\nTipo:{vaga.Veiculo.Tipo}\nPlaca:{vaga.Veiculo.Placa}\nModelo:{vaga.Veiculo.Modelo}");
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.WriteLine(" ");
                    break;
                case "4":
                    AdministradorUI.Show();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine(" ");
                    Console.WriteLine("Opcao invalida.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Pressione uma tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.WriteLine(" ");
                    break;
            }
        }
    }
}