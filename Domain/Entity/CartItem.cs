using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class CartItem
{
    public int Id { get; set; }

    public Cake Cake { get; set; } = default!;

    public int Amount { get; set; }

    public string? ShoppingCartId { get; set; }
}