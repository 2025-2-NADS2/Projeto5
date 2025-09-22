using System;

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Local { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; }

    public Evento(int id, string nome, string local, DateTime data, string descricao)
    {
        Id = id;
        Nome = nome;
        Local = local;
        Data = data;
        Descricao = descricao;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"[Evento] ID: {Id} | {Nome} - {Descricao} | Local: {Local} | Data: {Data.ToShortDateString()}");
    }
}
