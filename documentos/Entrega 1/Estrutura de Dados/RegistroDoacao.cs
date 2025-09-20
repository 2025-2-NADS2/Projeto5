using System;

namespace PI_EXEMPLO2ADS
{
    internal class RegistroDoacao
    {
        public string Doador { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }

        public RegistroDoacao(string doador, double valor)
        {
            Doador = doador;
            Valor = valor;
            Data = DateTime.Now;
        }

        public void Imprimir()
        {
            Console.WriteLine($"{Data:dd/MM/yyyy HH:mm} - {Doador} - R$ {Valor:F2}");
        }
    }
}
