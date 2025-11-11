using System;

namespace InstitutoAlma.Models;

public class Documento
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Link { get; set; } = null!;
    public DateTime DataUpload { get; set; }

    // FK
    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}
