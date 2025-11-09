using PI_EXEMPLO2ADS;
using System;

namespace PI_EXEMPLO2ADS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Campanha campanha = new Campanha(1, "ONG Solidária");

            // Adiciona doações iniciais
            campanha.AddDoacao(1, "Doação de Alimentos");
            campanha.AddDoacao(2, "Doação de Roupas");
            campanha.AddDoacao(3, "Doação de Brinquedos");

            int opcao;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=========================================");
                Console.WriteLine("          SISTEMA DE DOAÇÕES             ");
                Console.WriteLine("=========================================");
                Console.ResetColor();

                Console.WriteLine("1 - Listar Doações");
                Console.WriteLine("2 - Ordenar Doações (A-Z)");
                Console.WriteLine("3 - Pesquisar Doação");
                Console.WriteLine("4 - Remover Doação");
                Console.WriteLine("5 - Registrar Doação");
                Console.WriteLine("6 - Ver Transparência");
                Console.WriteLine("7 - Ordenar por Valor Arrecadado");
                Console.WriteLine("8 - Relatório Resumido");
                Console.WriteLine("9 - Filtrar Doações por Valor");
                Console.WriteLine("10 - Exportar relatório CSV");
                Console.WriteLine("11 - Listar Atividades (Banco Simulado)");
                Console.WriteLine("12 - Mostrar Transparência Financeira (Banco Simulado)");
                Console.WriteLine("13 - Filtrar Transparência (por valor/data)");
                Console.WriteLine("14 - Exportar Transparência para CSV");
                Console.WriteLine("0 - Sair");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Escolha uma opção: ");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida! Digite um número.");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                Console.Clear();
                switch (opcao)
                {
                    case 1:
                        campanha.Imprimir();
                        break;

                    case 2:
                        campanha.BubbleSort();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Doações ordenadas alfabeticamente!");
                        Console.ResetColor();
                        break;

                    case 3:
                        Console.Write("Digite parte do nome da doação: ");
                        string busca = Console.ReadLine();
                        bool encontrada = false;
                        foreach (var d in campanha.Doacoes)
                        {
                            if (d != null && d.Nome.Contains(busca, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Encontrado: {d.Id} - {d.Nome}");
                                Console.ResetColor();
                                encontrada = true;
                            }
                        }
                        if (!encontrada)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nenhuma doação encontrada.");
                            Console.ResetColor();
                        }
                        break;

                    case 4:
                        Console.Write("Digite o ID da doação para remover: ");
                        if (int.TryParse(Console.ReadLine(), out int idRemover))
                        {
                            if (campanha.RemoverDoacao(idRemover))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Doação removida com sucesso!");
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Doação não encontrada.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ID inválido.");
                            Console.ResetColor();
                        }
                        break;

                    case 5:
                        Console.Write("Digite o ID da doação: ");
                        if (int.TryParse(Console.ReadLine(), out int idDoacao))
                        {
                            var doacao = Array.Find(campanha.Doacoes, d => d != null && d.Id == idDoacao);
                            if (doacao != null)
                            {
                                Console.Write("Nome do doador: ");
                                string nomeDoador = Console.ReadLine();

                                Console.Write("Valor da doação: R$ ");
                                if (double.TryParse(Console.ReadLine(), out double valor))
                                {
                                    doacao.AdicionarRegistro(nomeDoador, valor);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Doação registrada com sucesso!");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Valor inválido.");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Doação não encontrada.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ID inválido.");
                            Console.ResetColor();
                        }
                        break;

                    case 6:
                        Console.Write("Digite o ID da doação para ver transparência: ");
                        if (int.TryParse(Console.ReadLine(), out int idTransparencia))
                        {
                            var doacao = Array.Find(campanha.Doacoes, d => d != null && d.Id == idTransparencia);
                            if (doacao != null)
                                doacao.ImprimirTransparencia();
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Doação não encontrada.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ID inválido.");
                            Console.ResetColor();
                        }
                        break;

                    case 7:
                        campanha.OrdenarPorValor();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Doações ordenadas por total arrecadado (maior para menor)!");
                        Console.ResetColor();
                        break;

                    case 8:
                        campanha.Imprimir();
                        double totalGeral = 0;
                        foreach (var d in campanha.Doacoes)
                        {
                            if (d != null)
                                totalGeral += d.TotalArrecadado();
                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Total geral arrecadado: R$ {totalGeral:F2}");
                        Console.ResetColor();
                        break;

                    case 9:
                        Console.Write("Digite valor mínimo: R$ ");
                        double min = double.TryParse(Console.ReadLine(), out min) ? min : 0;
                        Console.Write("Digite valor máximo: R$ ");
                        double max = double.TryParse(Console.ReadLine(), out max) ? max : double.MaxValue;
                        foreach (var d in campanha.Doacoes)
                        {
                            if (d != null)
                                d.ImprimirFiltrado(min, max);
                        }
                        break;

                    case 10:
                        Console.Write("Digite caminho do arquivo CSV (ex: C:\\relatorio.csv): ");
                        string caminho = Console.ReadLine();
                        campanha.ExportarCSV(caminho);
                        break;

                    case 11:
                        new BancoFake().ListarAtividades();
                        break;

                    case 12:
                        new BancoFake().ListarTransparencia();
                        break;

                    case 13:
                        var banco3 = new BancoFake();
                        Console.Write("Digite o valor mínimo (R$): ");
                        double valorMinimo = double.TryParse(Console.ReadLine(), out valorMinimo) ? valorMinimo : 0;

                        Console.Write("Digite data inicial (dd/mm/aaaa) ou deixe vazio: ");
                        string dataInicioTxt = Console.ReadLine();
                        DateTime? dataInicio = DateTime.TryParse(dataInicioTxt, out DateTime dtIni) ? dtIni : null;

                        Console.Write("Digite data final (dd/mm/aaaa) ou deixe vazio: ");
                        string dataFimTxt = Console.ReadLine();
                        DateTime? dataFim = DateTime.TryParse(dataFimTxt, out DateTime dtFim) ? dtFim : null;

                        banco3.FiltrarTransparencia(valorMinimo, dataInicio, dataFim);
                        break;

                    case 14:
                        var banco4 = new BancoFake();
                        Console.Write("Digite o caminho para salvar o CSV (ex: C:\\transparencia.csv): ");
                        string caminhoCSV = Console.ReadLine();
                        banco4.ExportarTransparenciaCSV(caminhoCSV);
                        break;

                    case 0:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Saindo... Até mais!");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();

            } while (opcao != 0);
        }
    }
}
A