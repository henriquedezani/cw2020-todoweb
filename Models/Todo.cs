using System.ComponentModel.DataAnnotations;

namespace TodoWeb.Models // ~ package Java
{
  public class Todo // Entitdade = tabela
  {
    // propriedade automática:
    [Required]
    public int Id { get; set; }

    [Required] // NOT NULL
    [MinLength(3)]
    [MaxLength(200)] // VARCHAR(200)
    public string Title { get; set; }

    public bool Done { get; set; } = false;
  }
}