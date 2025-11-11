using System.Collections.Generic;

namespace InstitutoAlma.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;

    public List<Doacao> Doacoes { get; set; } = new();
    public List<Documento> Documentos { get; set; } = new();
    

}

