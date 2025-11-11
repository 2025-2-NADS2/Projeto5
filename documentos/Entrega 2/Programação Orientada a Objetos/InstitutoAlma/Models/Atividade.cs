using System;

namespace InstitutoAlma.Models;

public class Atividade
{
    public int Id { get; set; }
    public string Titulo { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public DateTime Data { get; set; }

    // FK
    public int EventoId { get; set; }
    public Evento? Evento { get; set; }
}
