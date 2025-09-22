using System;

public class Documento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Link { get; set; }
    public DateTime DataUpload { get; set; }

    public Documento(int id, string nome, string link, DateTime dataUpload)
    {
        Id = id;
        Nome = nome;
        Link = link;
        DataUpload = dataUpload;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"[Documento] ID: {Id} | {Nome} | Link: {Link} | Data: {DataUpload.ToShortDateString()}");
    }
}
