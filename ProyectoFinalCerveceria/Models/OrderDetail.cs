using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalCerveceria.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public decimal Price { get; set; }
        [Display(Name = "Cantidad")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}