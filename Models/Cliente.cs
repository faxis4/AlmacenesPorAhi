using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlmacenesPorAhi.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El RUT es obligatorio.")]
    [StringLength(15, ErrorMessage = "El RUT no puede superar los 15 caracteres.")]
    [Display(Name = "RUT")]
    public string Rut { get; set; } = string.Empty;

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(80, ErrorMessage = "El nombre no puede superar los 80 caracteres.")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido paterno es obligatorio.")]
    [StringLength(80, ErrorMessage = "El apellido paterno no puede superar los 80 caracteres.")]
    [Display(Name = "Apellido paterno")]
    public string ApellidoPaterno { get; set; } = string.Empty;

    [StringLength(80, ErrorMessage = "El apellido materno no puede superar los 80 caracteres.")]
    [Display(Name = "Apellido materno")]
    public string? ApellidoMaterno { get; set; }

    [EmailAddress(ErrorMessage = "El correo electronico no es valido.")]
    [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres.")]
    [Display(Name = "Correo electronico")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "El telefono ingresado no es valido.")]
    [StringLength(20, ErrorMessage = "El telefono no puede superar los 20 caracteres.")]
    [Display(Name = "Telefono")]
    public string? Telefono { get; set; }

    [StringLength(300, ErrorMessage = "La direccion no puede superar los 300 caracteres.")]
    [Display(Name = "Direccion")]
    public string? Direccion { get; set; }

    [StringLength(200, ErrorMessage = "Las preferencias no pueden superar los 200 caracteres.")]
    [Display(Name = "Preferencias")]
    public string? Preferencias { get; set; }

    [Required(ErrorMessage = "Debe indicar el estado.")]
    [StringLength(20)]
    [Display(Name = "Estado")]
    public string Estado { get; set; } = "Activo";

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [NotMapped]
    [Display(Name = "Nombre completo")]
    public string NombreCompleto => $"{Nombre} {ApellidoPaterno} {ApellidoMaterno}".Trim();

    [NotMapped]
    public string Inicial => string.IsNullOrWhiteSpace(Nombre) ? "?" : Nombre[0].ToString();
}
