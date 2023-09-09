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
    $("#search-input").on("input", function () {
        var searchQuery = $.trim($(this).val());
        $("#query-list").html("");
        if (searchQuery === "") {
            // get all cakes
            $.ajax({
                type: "GET",
                url: "/api/Search",
                success: function (cakes) {
                    displayCakes(cakes);
                }
            })
        }
        
        $.ajax({
            type: "POST",
            url: "/api/Search",
            data: JSON.stringify(searchQuery),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (cakes) {
                displayCakes(cakes);
            },
            error: function (xhr, status, error) {
            }
        });
    });
});

$(document).ready(function () {
    $("#select-category").change(function () {
        var selectedCategory = $("#select-category").val();
        if (selectedCategory === "") {
            return 
        }
        $.ajax({
            type: "GET",
            url: "/api/Search/category/" + selectedCategory,
            success: function (cakes) {
                displayCakes(cakes);
            },
            error: function (xhr, status, error) {
            }
        });
    });
});

function displayCakes(cakes) {
    $("#query-list").html("");
    $.each(cakes, function (i, cake) {
        $("#query-list").append('<div class="col-lg-3 col-md-6 col-sm-6">' +
            '<div class="product__item">' +
            '<a href="/Cake/Details/' + cake.id + '">' +
            '<div class="product__item__pic set-bg"  data-setbg="'+ cake.imageThumbnailUrl +'" style="background-image: url('+ cake.imageThumbnailUrl +');" >' +
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
}