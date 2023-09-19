$(".cartItemRemove").click(function () {
    var cakeId = $(this).attr("data-cake-id");
    $.post("/ShoppingCart/ClearCartItem", { "cakeId": cakeId }, function (data) {
        if (data){
            location.reload();
        }
    });
});

$("#btn_clear_basket").click(function () {
    $.post("/ShoppingCart/ClearCart", function (data) {
        if (data) {
            location.reload();
        }
    });
});

$(".pro-qty .inc.qtybtn").click(function () {
    var proQtyDiv = $(this).closest(".quantity").find(".pro-qty");
    var cakeId = proQtyDiv.attr("data-cakeId");
    $.post("/ShoppingCart/AddToShoppingCart", { "cakeId": cakeId }, function (data) {
        if (data) {
            location.reload();
        }
    });
});

$(".pro-qty .dec.qtybtn").click(function () {
    var proQtyDiv = $(this).closest(".quantity").find(".pro-qty");
    var cakeId = proQtyDiv.attr("data-cakeId");
    $.post("/ShoppingCart/RemoveFromShoppingCart", { "cakeId": cakeId }, function (data) {
        if (data) {
            location.reload();
        }
    });
});

    
    