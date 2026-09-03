using System.ComponentModel.DataAnnotations;

namespace SistemaGestaoConsultasUVV.Models;

public class Consulta
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a especialidade.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "A especialidade deve ter entre 2 e 100 caracteres.")]
    [Display(Name = "Especialidade")]
    public string Especialidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a data e hora.")]
    [Display(Name = "Data/Hora")]
    public DateTime DataHora { get; set; }

    [Required(ErrorMessage = "Informe a descrição.")]
    [StringLength(500, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 500 caracteres.")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }
}
