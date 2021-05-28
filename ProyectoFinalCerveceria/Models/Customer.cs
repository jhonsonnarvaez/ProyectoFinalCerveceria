using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalCerveceria.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Display(Name = "N° Identificación")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(13, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 10)]
        public string Identification { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(30, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string Name { get; set; }
        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(30, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 3)]
        public string LastName { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Address { get; set; }
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(10, ErrorMessage = "El campo {0} debe tener {1} caracteres")]
        public string PhoneNumber { get; set; }
        public int DocumentTypeId { get; set; }
        public string FullName { get { return string.Format("{0} {1}", Name, LastName); } }
        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}