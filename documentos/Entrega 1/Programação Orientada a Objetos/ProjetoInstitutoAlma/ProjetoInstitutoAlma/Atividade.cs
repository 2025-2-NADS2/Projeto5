using System;

public class Atividade
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }

    public Atividade(int id, string titulo, string descricao, DateTime data)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Data = data;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"[Atividade] ID: {Id} | {Titulo} - {Descricao} | Data: {Data.ToShortDateString()}");
    }
}
