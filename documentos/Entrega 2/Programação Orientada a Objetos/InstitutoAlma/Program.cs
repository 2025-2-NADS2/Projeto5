using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// --- Dados iniciais ---
var usuarios = new List<Usuario>
{
    new Usuario { Id = 1, Nome = "Enzo Ribeiro", Email = "enzo@email.com" },
    new Usuario { Id = 2, Nome = "Rikelmy Ancieto", Email = "ricks@email.com" }
};

var doacoes = new List<Doacao>
{
    new Doacao { Id = 1, Doador = usuarios[0], Valor = 50, Data = DateTime.Now, MetodoPagamento = "Pix" },
    new Doacao { Id = 2, Doador = usuarios[1], Valor = 100, Data = DateTime.Now, MetodoPagamento = "Cartão de Crédito" }
};

var atividades = new List<Atividade>
{
    new Atividade { Id = 1, Titulo = "Palestra", Descricao = "Palestra de ", Data = new DateTime(2025, 12, 3) },
    new Atividade { Id = 2, Titulo = "Campanha do agasalho", Descricao = "Coleta de roupas", Data = new DateTime(2025, 10, 15) }
};

var eventos = new List<Evento>
{
    new Evento { Id = 1, Nome = "Natal Solidário", Local = "Comunidade", Data = new DateTime(2025, 12, 25), Descricao = "Presente para crianças" },
    new Evento { Id = 2, Nome = "Sábado da Sopa", Local = "Pátio", Data = new DateTime(2025, 11, 5), Descricao = "Sopa de graça para quem precisa" }
};

var documentos = new List<Documento>
{
    new Documento { Id = 1, Nome = "Relatório 2025", Link = "relatorio2025.pdf", DataUpload = new DateTime(2025, 9, 1) }
};

// --- Endpoints mínimos ---
app.MapGet("/", () => "Instituto Alma API está rodando!");

app.MapGet("/usuarios", () => usuarios);
app.MapGet("/doacoes", () => doacoes);
app.MapGet("/atividades", () => atividades);
app.MapGet("/eventos", () => eventos);
app.MapGet("/documentos", () => documentos);

// --- Rodar app ---
app.Run();


// --- Classes do projeto ---
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    private List<Doacao> listaDoacoes = new List<Doacao>();

    public void AdicionarDoacao(Doacao d) => listaDoacoes.Add(d);
    public void ListarDoacoes() => listaDoacoes.ForEach(d => Console.WriteLine(d));
}

public class Doacao
{
    public int Id { get; set; }
    public Usuario Doador { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
    public string MetodoPagamento { get; set; }
}

public class Atividade
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
}

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Local { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; }
}

public class Documento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Link { get; set; }
    public DateTime DataUpload { get; set; }
}
