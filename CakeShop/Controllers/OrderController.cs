using Application.Interfaces;
using CakeShop.ViewModels;
using Domain.Entity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers;

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

        return View(order);
    }

    public IActionResult CheckoutComplete()
    {
        ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious cakes!";
        return View();
    }

    public IActionResult DownloadInvoice()
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            int orderId = _orderService.GetLastOrderId();
            Order order = _orderService.GetOrderById(orderId);
            PdfGenerate(memoryStream, order);

            byte[] bytes = memoryStream.ToArray();
            memoryStream.Close();

            return File(bytes, "application/pdf", "Invoice.pdf");
        }
    }

    private static void PdfGenerate(MemoryStream memoryStream, Order order)
    {
        Document document = new Document(PageSize.A4, 50, 50, 25, 25);
        PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

        document.Open();

        Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
        Paragraph title = new Paragraph("Invoice", titleFont);
        title.Alignment = Element.ALIGN_CENTER;
        document.Add(title);

        Paragraph orderInfo = new Paragraph($"Order No: {order.Id}");
        orderInfo.Alignment = Element.ALIGN_CENTER;
        document.Add(orderInfo);

        Paragraph customerInfo = new Paragraph($"Customer: {order.FirstName} {order.LastName}");
        document.Add(customerInfo);

        PdfPTable table = new PdfPTable(3);
        table.WidthPercentage = 100;
        table.SpacingBefore = 10f;
        table.SpacingAfter = 10f;

        PdfPCell cell1 = new PdfPCell(new Phrase("Product Name"));
        cell1.BackgroundColor = new BaseColor(240, 240, 240);
        table.AddCell(cell1);

        PdfPCell cell2 = new PdfPCell(new Phrase("Amount"));
        cell2.BackgroundColor = new BaseColor(240, 240, 240);
        table.AddCell(cell2);

        PdfPCell cell3 = new PdfPCell(new Phrase("Price"));
        cell3.BackgroundColor = new BaseColor(240, 240, 240);
        table.AddCell(cell3);

        foreach (var orderDetail in order.OrderDetails)
        {
            table.AddCell(orderDetail.Cake.Name);
            table.AddCell(orderDetail.Amount.ToString());
            table.AddCell("$" + orderDetail.Price.ToString());
        }

        document.Add(table);

        Paragraph address = new Paragraph($"\n{order.AddressLine1}" +
                                          $"\n{order.AddressLine2} " +
                                          $"\n{order.City}" +
                                          $" / {order.Country}" +
                                          $"\n{order.State}" +
                                          $" / {order.ZipCode}");

        address.Alignment = Element.ALIGN_LEFT;

        document.Add(address);

        decimal totalAmount = order.OrderTotal;
        string formattedTotal = string.Format("{0:C}", totalAmount);
        Font totalFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
        Paragraph total = new Paragraph($"Total: ${formattedTotal}", totalFont);
        total.Alignment = Element.ALIGN_RIGHT;
        document.Add(total);

        document.Close();
    }
}