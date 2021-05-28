using ProyectoFinalCerveceria.Data;
using ProyectoFinalCerveceria.Models;
using ProyectoFinalCerveceria.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinalCerveceria.Controllers
{
    public class OrdersController : Controller
    {
        private BeerContext db = new BeerContext();
        public ActionResult NewOrder()
        {
            var orderView = new OrderView();
            cargarView(orderView);
            cargarCustomer();
            return View(orderView);
        }

        [HttpPost]
        public ActionResult NewOrder(OrderView orderView)
        {
            orderView = Session["orderView"] as OrderView;
            var customerId = int.Parse(Request["CustomerId"]);
            if (customerId == 0)
            {
                cargarCustomer();
                ViewBag.Error = "Debe seleccionar un cliente";
                return View(orderView);
            }
            var customer = db.Customers.Find(customerId);
            if (customer == null)
            {
                cargarCustomer();
                ViewBag.Error = "Cliente no existe";
                return View(orderView);
            }
            if(orderView.Products.Count == 0)
            {
                cargarCustomer();
                ViewBag.Error = "Debe ingresar detalles";
                return View(orderView);
            }

            int orderId = 0;

            using(var transaction = db.Database.BeginTransaction()) {
                try {
                    var order = new Order
                    {
                        CustomerId = customerId,
                        DateOrder = DateTime.Now,
                        OrderSatus = OrderSatus.Creado
                    };

                    db.Orders.Add(order);
                    db.SaveChanges();

                    orderId = db.Orders.ToList().Select(o => o.OrderID).Max();
                    foreach (var item in orderView.Products)
                    {
                        var orderDetail = new OrderDetail
                        {
                            ProductId = item.ProductId,
                            description = item.ProductName,
                            Price = item.Price,
                            Quantity = item.Quantity,
                            OrderID = orderId
                        };
                        db.OrderDetails.Add(orderDetail);
                        db.SaveChanges();
                    }
                    transaction.Commit();
                } catch (Exception ex)
                {
                    transaction.Rollback();
                    ViewBag.Error = "ERROR: " + ex.Message;
                    cargarCustomer();
                    return View(orderView);
                }
            
            }

            ViewBag.Message = string.Format("La orden:{0} guardada",orderId);
            cargarCustomer();
            cargarView(orderView);
            return View(orderView);
        }

        public ActionResult AddProduct()
        {
            cargarProduct();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var orderView = Session["orderView"] as OrderView;

            var productId = int.Parse(Request["ProductId"]);
            if (productId == 0)
            {
                cargarProduct();
                ViewBag.Error = "Debe seleccionar un producto";
                return View(productOrder);
            }

            var product = db.Products.Find(productId);
            if(product == null)
            {
                cargarProduct();
                ViewBag.Error = "Producto no existe";
                return View(productOrder);
            }
            productOrder = orderView.Products.Find(p => p.ProductId == productId);
            if(productOrder == null) { 
            productOrder = new ProductOrder
            {
                ProductName = product.ProductName,
                Price = product.Price,
                ProductId = product.ProductId,
                Quantity = float.Parse(Request["Quantity"])

            };
                orderView.Products.Add(productOrder);
            }
            else
            {
                productOrder.Quantity += float.Parse(Request["Quantity"]);
            }
           
            cargarCustomer();
            return View("NewOrder",orderView);
        }
        private void cargarCustomer()
        {
            var list = db.Customers.ToList();
            list.Add(new Customer { CustomerId = 0, Name = "- Seleccione", LastName = " un cliente -" });
            list = list.OrderBy(c => c.FullName).ToList();
            ViewBag.CustomerId = new SelectList(list, "CustomerId", "FullName");
        }

        private void cargarProduct()
        {
            var list = db.Products.ToList();
            list.Add(new Product { ProductId = 0, ProductName = "- Seleccione un producto -" });
            list = list.OrderBy(p => p.ProductName).ToList();
            ViewBag.ProductId = new SelectList(list, "ProductId", "ProductName");
        }

        private void cargarView(OrderView orderView)
        {
            orderView.Customer = new Customer();
            orderView.Products = new List<ProductOrder>();
            Session["orderView"] = orderView;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}