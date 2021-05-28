using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalCerveceria.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name ="Código de Producto")]
        public string ProductCode { get; set; }
        [Display(Name = "Descripción")]
        public string ProductName { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
        [Display(Name = "Cantidad")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public float Stock { get; set; }

        public byte[] Image { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}