using System;
using System.Collections.Generic;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    private List<Doacao> listaDoacoes = new List<Doacao>();

    public Usuario(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public void AdicionarDoacao(Doacao d)
    {
        listaDoacoes.Add(d);
    }

    public void ListarDoacoes()
    {
        Console.WriteLine($"\n=== Doações de {Nome} ===");
        if (listaDoacoes.Count == 0)
        {
            Console.WriteLine("Nenhuma doação encontrada.");
            return;
        }
        foreach (var d in listaDoacoes)
        {
            d.ExibirDetalhes();
        }
    }
}
