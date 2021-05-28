using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinalCerveceria.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Display(Name = "Fecha de Orden")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOrder { get; set; }
        public int CustomerId { get; set; }
        public OrderSatus OrderSatus { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}