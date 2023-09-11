using Application.Interfaces;
using CakeShop.ViewModels;
using Domain.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICartItemService _cartItemService;

        public OrderController(IOrderService orderService, ICartItemService cartItemService)
        {
            _orderService = orderService;
            _cartItemService = cartItemService;
        }

        public IActionResult Checkout()
        {
            var order = new Order();
            var items = _cartItemService.GetShoppingCartItems();
            var total = _cartItemService.GetShoppingCartTotal();

            var checkoutViewModel = new CheckoutViewModel
            {
                CartItems = items,
                Order = order,
                ShoppingCartTotal = total
            };
            return View(checkoutViewModel);
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            ViewBag.Total = _cartItemService.GetShoppingCartTotal();
            var items = _cartItemService.GetShoppingCartItems();
            _cartItemService.ShoppingCartItems = items;

            if (_cartItemService.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is emtpy, add some cakes first");
            }

            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(order);
                _cartItemService.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            
            HttpContext.Session.SetInt32("OrderId", order.Id);

            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious cakes!";
            return View();
        }

        public IActionResult DownloadInvoice()
        {
            int orderId = HttpContext.Session.GetInt32("OrderId") ?? 0;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Order order = _orderService.GetOrderById(orderId);
                Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();
                document.Add(new Paragraph("Invoice"));
                document.Add(new Paragraph("Order Id: " + order.Id));
                document.Add(new Paragraph("Order Placed: " + order.OrderPlaced));
                document.Add(new Paragraph("Order Total: " + order.OrderTotal));
                document.Add(new Paragraph("Order Details: "));
                foreach (var orderDetail in order.OrderDetails)
                {
                    document.Add(new Paragraph("Cake Id: " + orderDetail.CakeId));
                    document.Add(new Paragraph("Amount: " + orderDetail.Amount));
                    document.Add(new Paragraph("Price: " + orderDetail.Price));
                }

                document.Close();

                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                
                return File(bytes, "application/pdf", "Invoice.pdf");
            }
        }
    }
}