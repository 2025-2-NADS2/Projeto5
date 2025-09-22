using System;

public class Doacao
{
    public int Id { get; set; }
    public Usuario Doador { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
    public string MetodoPagamento { get; set; }

    public Doacao(int id, Usuario doador, double valor, DateTime data, string metodoPagamento)
    {
        if (valor <= 0)
            throw new ArgumentException("O valor da doação deve ser maior que zero.");

        Id = id;
        Doador = doador;
        Valor = valor;
        Data = data;
        MetodoPagamento = metodoPagamento;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"[Doação] ID: {Id} | Doador: {Doador.Nome} | Valor: R${Valor:F2} | Data: {Data.ToShortDateString()} | Método: {MetodoPagamento}");
    }
}
