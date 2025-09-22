using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Listas para armazenar os objetos
        List<Usuario> usuarios = new List<Usuario>();
        List<Doacao> doacoes = new List<Doacao>();
        List<Atividade> atividades = new List<Atividade>();
        List<Evento> eventos = new List<Evento>();
        List<Documento> documentos = new List<Documento>();

        // Criar usuários
        Usuario usuario1 = new Usuario(1, "Enzo Ribeiro", "enzo@email.com");
        Usuario usuario2 = new Usuario(2, "Rikelmy Ancieto", "ricks@email.com");
        usuarios.Add(usuario1);
        usuarios.Add(usuario2);

        // Criar doações
        Doacao doacao1 = new Doacao(1, usuario1, 50.0, DateTime.Now, "Pix");
        Doacao doacao2 = new Doacao(2, usuario2, 100.0, DateTime.Now, "Cartão de Crédito");
        doacoes.Add(doacao1);
        doacoes.Add(doacao2);
        usuario1.AdicionarDoacao(doacao1);
        usuario2.AdicionarDoacao(doacao2);

        // Criar atividades
        atividades.Add(new Atividade(1, "Palestra", "Palestra de ", new DateTime(2025, 12, 03)));
        atividades.Add(new Atividade(2, "Campanha do agasalho", "Coleta de roupas", new DateTime(2025, 10, 15)));

        // Criar eventos
        eventos.Add(new Evento(1, "Natal Solidário", "Comunidade", new DateTime(2025, 12, 25), "Presente para crianças"));
        eventos.Add(new Evento(2, "Sabado da Sopa", "Pátio", new DateTime(2025, 11, 5), "Sopa de graça para quem precisa"));

        // Criar documentos
        documentos.Add(new Documento(1, "Relatório 2025", "relatorio2025.pdf", new DateTime(2025, 9, 1)));

        // Listar usuários
        Console.WriteLine("\n=== LISTA DE USUÁRIOS ===");
        foreach (var u in usuarios)
            Console.WriteLine($"ID: {u.Id} | Nome: {u.Nome} | Email: {u.Email}");

        // Listar todas as doações
        Console.WriteLine("\n=== LISTA DE TODAS AS DOAÇÕES ===");
        foreach (var d in doacoes)
            d.ExibirDetalhes();

        // Listar atividades
        Console.WriteLine("\n=== LISTA DE ATIVIDADES ===");
        foreach (var a in atividades)
            a.ExibirDetalhes();

        // Listar eventos
        Console.WriteLine("\n=== LISTA DE EVENTOS ===");
        foreach (var e in eventos)
            e.ExibirDetalhes();

        // Listar documentos
        Console.WriteLine("\n=== LISTA DE DOCUMENTOS ===");
        foreach (var doc in documentos)
            doc.ExibirDetalhes();

        // Mostrar doações de um usuário específico
        usuario1.ListarDoacoes();
    }
}
