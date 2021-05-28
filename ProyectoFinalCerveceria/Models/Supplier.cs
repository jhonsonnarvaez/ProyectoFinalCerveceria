using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalCerveceria.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Display(Name = "Nombre de la Empresa")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 5)]
        public string CompanyName { get; set; }
        [Display(Name = "Dirección de la Empresa")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres", MinimumLength = 5)]
        public string CompanyAddress { get; set; }
        [Display(Name = "Correo de la Empresa")]
        public string CompanyEmail { get; set; }
        [Display(Name = "Teléfono de la Empresa")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(10, ErrorMessage = "El campo {0} debe tener {1} caracteres")]
        public string CompanyPhoneNumber { get; set; }
        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
    }
}