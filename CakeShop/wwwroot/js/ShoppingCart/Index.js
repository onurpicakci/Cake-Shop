$(".icon_close").click(function () {
    var cakeId = $(this).attr("data-cake-id");
    $.post("/ShoppingCart/RemoveFromShoppingCart", { "cakeId": cakeId }, function (data) {
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
    var cakeId = $(this).attr("data-id");
    $.post("/ShoppingCart/AddToShoppingCart", { "cakeId": cakeId }, function (data) {
        if (data) {
            location.reload();
        }
    });
});
    
    