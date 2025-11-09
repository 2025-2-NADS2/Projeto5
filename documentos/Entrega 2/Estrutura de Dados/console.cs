using System;
using System.IO;

namespace PI_EXEMPLO2ADS
{
    internal class Campanha
    {
        public string Nome { get; set; }
        public int Id { get; set; }

        public Doacao[] Doacoes { get; set; }
        private int QtdeDoacao;

        public Campanha(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Doacoes = new Doacao[40];
            QtdeDoacao = 0;
        }

        public bool AddDoacao(int id, string nome)
        {
            Doacao d = new Doacao(id, nome, "");
            Doacoes[QtdeDoacao] = d;
            QtdeDoacao++;
            return true;
        }

        public void Imprimir()
        {
            Console.WriteLine($"\n=== Doações da campanha: {Nome} ===");
            for (int i = 0; i < QtdeDoacao; i++)
            {
                var doacao = Doacoes[i];
                double total = doacao.TotalArrecadado();
                Console.WriteLine($"{doacao.Id} - {doacao.Nome} | Total arrecadado: R$ {total:F2} | Doadores: {doacao.TotalDoadores()}");
                Console.WriteLine("-----------------------------");
            }
        }

        public void BubbleSort()
        {
            int N = QtdeDoacao;
            Doacao aux;
            for (int i = N - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (Doacoes[j].Maior(Doacoes[j + 1]))
                    {
                        aux = Doacoes[j];
                        Doacoes[j] = Doacoes[j + 1];
                        Doacoes[j + 1] = aux;
                    }
                }
            }
        }

        public void OrdenarPorValor()
        {
            for (int i = 0; i < QtdeDoacao - 1; i++)
            {
                for (int j = 0; j < QtdeDoacao - i - 1; j++)
                {
                    if (Doacoes[j].TotalArrecadado() < Doacoes[j + 1].TotalArrecadado())
                    {
                        var temp = Doacoes[j];
                        Doacoes[j] = Doacoes[j + 1];
                        Doacoes[j + 1] = temp;
                    }
                }
            }
        }

        public bool RemoverDoacao(int id)
        {
            for (int i = 0; i < QtdeDoacao; i++)
            {
                if (Doacoes[i].Id == id)
                {
                    for (int j = i; j < QtdeDoacao - 1; j++)
                        Doacoes[j] = Doacoes[j + 1];

                    Doacoes[QtdeDoacao - 1] = null;
                    QtdeDoacao--;
                    return true;
                }
            }
            return false;
        }

        public void ExportarCSV(string caminho)
        {
            using (StreamWriter sw = new StreamWriter(caminho))
            {
                sw.WriteLine("ID;Nome da Doação;Doador;Valor;Data");
                foreach (var d in Doacoes)
                {
                    if (d != null)
                    {
                        foreach (var r in d.Registros)
                        {
                            sw.WriteLine($"{d.Id};{d.Nome};{r.Doador};{r.Valor:F2};{r.Data:dd/MM/yyyy HH:mm}");
                        }
                    }
                }
            }
            Console.WriteLine($"Relatório exportado para {caminho}");
        }
    }
}
