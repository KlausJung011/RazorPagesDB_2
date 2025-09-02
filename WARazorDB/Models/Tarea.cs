using System.ComponentModel.DataAnnotations;

namespace WARazorDB.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la tarea es obligatorio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
        [Display(Name = "Nombre de la Tarea")]
        public string nombreTarea { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Vencimiento")]
        [CustomValidation(typeof(Tarea), nameof(ValidateFechaVencimiento))]
        public DateTime fechaVencimiento { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Required(ErrorMessage = "El ID de usuario es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de usuario debe ser mayor a 0")]
        [Display(Name = "ID Usuario")]
        public int idUsuario { get; set; }

        public static ValidationResult ValidateFechaVencimiento(DateTime fechaVencimiento, ValidationContext context)
        {
            if (fechaVencimiento.Date < DateTime.Today)
            {
                return new ValidationResult("La fecha de vencimiento no puede ser anterior a hoy");
            }
            return ValidationResult.Success;
        }

        public static readonly string[] EstadosPermitidos = { "Pendiente", "En Curso", "Finalizado", "Cancelado" };
    }
}
