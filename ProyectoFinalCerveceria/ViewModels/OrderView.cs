﻿using ProyectoFinalCerveceria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinalCerveceria.ViewModels
{
    public class OrderView
    {
        public Customer Customer { get; set; }
        public ProductOrder Product{ get; set; }
        public List<ProductOrder> Products { get; set; }
    }
}