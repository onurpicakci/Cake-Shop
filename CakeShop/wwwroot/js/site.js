$.ajax({
    type: "GET",
    url: "/Header/GetCartTotal",
    success: function (data) {
        var cartTotal = data;
        $('.cart__price span').text('$' + cartTotal.toFixed(2));
    },
})

$.ajax({
    type: "GET",
    url: "/Header/GetCartItems",
    success: function (data) {
        var cartItemsCount = data;
        $('#basket_item_count').text(cartItemsCount);
    },
})


    
