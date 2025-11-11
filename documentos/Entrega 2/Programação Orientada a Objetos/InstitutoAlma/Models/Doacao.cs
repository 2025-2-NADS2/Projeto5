using System;

namespace InstitutoAlma.Models;

public class Doacao
{
    public int Id { get; set; }
    public double Valor { get; set; }
    public DateTime Data { get; set; }
    public string MetodoPagamento { get; set; } = null!;

    // FK
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}
