using System.ComponentModel.DataAnnotations;

namespace AlmacenesPorAhi.Models;

public class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
    [StringLength(80, ErrorMessage = "El nombre no puede superar los 80 caracteres.")]
    [Display(Name = "Nombre")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El apellido del cliente es obligatorio.")]
    [StringLength(80, ErrorMessage = "El apellido no puede superar los 80 caracteres.")]
    [Display(Name = "Apellido")]
    public string Apellido { get; set; } = string.Empty;

    [StringLength(20, ErrorMessage = "El numero de documento no puede superar los 20 caracteres.")]
    [Display(Name = "Numero de documento")]
    public string? NumeroDocumento { get; set; }

    [StringLength(50, ErrorMessage = "El tipo de documento no puede superar los 50 caracteres.")]
    [Display(Name = "Tipo de documento")]
    public string? TipoDocumento { get; set; }

    [Phone(ErrorMessage = "El telefono ingresado no es valido.")]
    [StringLength(20, ErrorMessage = "El telefono no puede superar los 20 caracteres.")]
    [Display(Name = "Telefono")]
    public string? Telefono { get; set; }

    [EmailAddress(ErrorMessage = "El correo electronico no es valido.")]
    [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres.")]
    [Display(Name = "Correo electronico")]
    public string? Email { get; set; }

    [StringLength(300, ErrorMessage = "La direccion no puede superar los 300 caracteres.")]
    [Display(Name = "Direccion")]
    public string? Direccion { get; set; }

    [Required(ErrorMessage = "Debe indicar el estado.")]
    [StringLength(20)]
    [Display(Name = "Estado")]
    public string Estado { get; set; } = "Activo";

    [DataType(DataType.Date)]
    [Display(Name = "Fecha de registro")]
    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    [Display(Name = "Nombre completo")]
    public string NombreCompleto => $"{Nombre} {Apellido}";

    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public string Inicial => string.IsNullOrWhiteSpace(Nombre) ? "?" : Nombre[0].ToString();
}
