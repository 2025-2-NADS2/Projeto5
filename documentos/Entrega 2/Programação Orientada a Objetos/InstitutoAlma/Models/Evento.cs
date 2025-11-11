using System;
using System.Collections.Generic;

namespace InstitutoAlma.Models;

public class Evento
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Local { get; set; } = null!;
    public DateTime Data { get; set; }
    public string Descricao { get; set; } = null!;

    public List<Atividade> Atividades { get; set; } = new();
}
