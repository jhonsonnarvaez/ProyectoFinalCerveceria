using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalCerveceria.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage ="Campo Obligatorio")]
        [StringLength(30,ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres",MinimumLength = 3)]
        public string FirstName { get; set; }
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(30, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string LastName { get; set; }
        [Display(Name = "Salario")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Salary { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Hora de Ingreso")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Tipo de Documento")]
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        [Display(Name = "N° Identificación")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(13, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 10)]
        public string Document { get; set; }
        
    }
}