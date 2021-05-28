using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalCerveceria.Models
{
    public class DocumentType
    {
        [Key]
        [Display(Name = "Tipo de Documento")]
        public int DocumentTypeId { get; set; }
        [Display(Name = "Tipo de Documento")]
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}