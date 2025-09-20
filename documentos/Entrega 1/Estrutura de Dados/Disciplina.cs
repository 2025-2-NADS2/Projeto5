using System;
using System.Collections.Generic;
using System.Linq;

namespace PI_EXEMPLO2ADS
{
    internal class Doacao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Objetivo { get; set; }
        public string Descricao { get; set; }
        public string Beneficiarios { get; set; }

        public List<RegistroDoacao> Registros { get; set; } = new List<RegistroDoacao>();

        public Doacao() { Id = 0; }

        public Doacao(int id, string nome, string objetivo)
        {
            Id = id;
            Nome = nome;
            Objetivo = objetivo;
        }

        public bool Maior(Doacao doacao) => Nome.CompareTo(doacao.Nome) > 0;

        public double TotalArrecadado() => Registros.Sum(r => r.Valor);

        public int TotalDoadores() => Registros.Count;

        public void AdicionarRegistro(string doador, double valor)
        {
            Registros.Add(new RegistroDoacao(doador, valor));
        }

        public void ImprimirTransparencia()
        {
            Console.WriteLine($"\nTransparência da doação: {Nome}");
            if (Registros.Count == 0)
            {
                Console.WriteLine("Nenhuma doação registrada.");
                return;
            }

            foreach (var r in Registros.OrderByDescending(r => r.Data))
                r.Imprimir();

            Console.WriteLine($"Total arrecadado: R$ {TotalArrecadado():F2} | Total de doadores: {TotalDoadores()}");
        }

        public void ImprimirFiltrado(double valorMin, double valorMax)
        {
            var filtradas = Registros.Where(r => r.Valor >= valorMin && r.Valor <= valorMax).OrderByDescending(r => r.Data);
            if (!filtradas.Any())
            {
                Console.WriteLine("Nenhuma doação dentro do valor informado.");
                return;
            }
            foreach (var r in filtradas)
                r.Imprimir();
        }
    }
}
