using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PI_EXEMPLO2ADS
{
    internal class BancoFake
    {
        private List<(int Id, string Nome, string Descricao, DateTime Data)> atividades;
        private List<(int Id, string Descricao, double Valor, DateTime Data)> transparencia;

        public BancoFake()
        {
            // Dados simulados
            atividades = new List<(int, string, string, DateTime)>
            {
                (1, "Campanha de Doação", "Arrecadar alimentos para famílias carentes", new DateTime(2025, 10, 1)),
                (2, "Feira de Doações", "Evento para arrecadar roupas e brinquedos", new DateTime(2025, 10, 5)),
                (3, "Mutirão da Solidariedade", "Ação comunitária em bairros carentes", new DateTime(2025, 10, 12))
            };

            transparencia = new List<(int, string, double, DateTime)>
            {
                (1, "Doação de alimentos", 1500.00, new DateTime(2025, 9, 16)),
                (2, "Compra de materiais escolares", 800.00, new DateTime(2025, 9, 20)),
                (3, "Doação para manutenção da ONG", 1200.00, new DateTime(2025, 10, 2))
            };
        }

        // 📋 Lista de atividades
        public void ListarAtividades()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=== LISTA DE ATIVIDADES ===");
            Console.ResetColor();

            foreach (var a in atividades)
            {
                Console.WriteLine($"ID: {a.Id} | Nome: {a.Nome}");
                Console.WriteLine($"Descrição: {a.Descricao}");
                Console.WriteLine($"Data: {a.Data:dd/MM/yyyy}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        // 💰 Lista de registros de transparência
        public void ListarTransparencia()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=== REGISTROS DE TRANSPARÊNCIA ===");
            Console.ResetColor();

            double total = 0;
            foreach (var t in transparencia)
            {
                Console.WriteLine($"ID: {t.Id} | Descrição: {t.Descricao}");
                Console.WriteLine($"Valor: R$ {t.Valor:F2} | Data: {t.Data:dd/MM/yyyy}");
                Console.WriteLine("---------------------------------------------");
                total += t.Valor;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Total geral registrado: R$ {total:F2}");
            Console.ResetColor();
        }

        // 🔍 Filtro de transparência
        public void FiltrarTransparencia(double valorMinimo, DateTime? dataInicio, DateTime? dataFim)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n=== FILTRO DE TRANSPARÊNCIA ===");
            Console.ResetColor();

            var filtrado = transparencia
                .Where(t => t.Valor >= valorMinimo &&
                            (!dataInicio.HasValue || t.Data >= dataInicio.Value) &&
                            (!dataFim.HasValue || t.Data <= dataFim.Value))
                .OrderByDescending(t => t.Data)
                .ToList();

            if (!filtrado.Any())
            {
                Console.WriteLine("Nenhum registro encontrado com os critérios informados.");
                return;
            }

            double total = 0;
            foreach (var t in filtrado)
            {
                Console.WriteLine($"ID: {t.Id} | {t.Descricao}");
                Console.WriteLine($"Valor: R$ {t.Valor:F2} | Data: {t.Data:dd/MM/yyyy}");
                Console.WriteLine("---------------------------------------------");
                total += t.Valor;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Total filtrado: R$ {total:F2}");
            Console.ResetColor();
        }

        // 📤 Exporta os registros de transparência para CSV
        public void ExportarTransparenciaCSV(string caminho)
        {
            using (var sw = new StreamWriter(caminho))
            {
                sw.WriteLine("ID;Descrição;Valor;Data");
                foreach (var t in transparencia)
                {
                    sw.WriteLine($"{t.Id};{t.Descricao};{t.Valor.ToString("F2", CultureInfo.InvariantCulture)};{t.Data:dd/MM/yyyy}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nArquivo CSV exportado com sucesso para: {caminho}");
            Console.ResetColor();
        }
    }
}
