using System.ComponentModel.DataAnnotations;
using System;

namespace TodoWeb.Models // ~ package Java
{
  public class Todo // Entitdade = tabela
  {
    // propriedade automática:
    public Guid Id { get; set; } // uuid_v4 ASDASDA123123-ASD-ASDASD-123SS (RFC)

    [Required(ErrorMessage="Campo obrigatório.")] 
    [MinLength(3, ErrorMessage="O campo Title deve conter no mínimo 3 caracteres.")]
    [MaxLength(200)]
    public string Title { get; set; }

    public bool Done { get; set; } = false;
  }
}