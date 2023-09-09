$(".heart__btn").click(function (e) {
    var cakeId = $(this).attr("data-wishlist-cakeId");
    e.preventDefault();
    $.post("/Wishlist/AddToWishlist", { "id": cakeId }, function (data) {
        if (data) {
            location.reload();
        }
    });
});

$(document).ready(function(){
    $("#search-button").click(function (){
        var searchQuery = $.trim($("#search-input").val());
        $("#query-list").html("");
        $.ajax({
            type: "POST",
            url: "/api/Search",
            data: JSON.stringify(searchQuery),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var cakes = data;
                $.each(cakes, function (i, cake) {
                    $("#query-list").append('<div class="col-lg-3 col-md-6 col-sm-6">' +
                        '<div class="product__item">' +
                        '<a href="/Cake/Details/' + cake.id + '">' +
                        '<div class="product__item__pic set-bg">' +
                        '<img src="' + cake.imageThumbnailUrl + '" alt="" width="263" height="270">' +
                        '<div class="product__label"><span>' + cake.category.name + '</span></div>' +
                        '</div>' +
                        '</a>' +
                        '<div class="product__item__text">' +
                        '<h6><a href="/Cake/Details/' + cake.id + '">' + cake.name + '</a></h6>' +
                        '<div class="product__item__price">$' + cake.price.toFixed(2) + '</div>' +
                        '<div class="cart_add">' +
                        '<a href="#" class="add-to-cart-btn" data-cake="' + cake.id + '">Add to cart</a>' +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '</div>');
                });
            },
            error: function (xhr, status, error) {
                
            }
        });
    });
});

