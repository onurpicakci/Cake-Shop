$(".heart__btn").click(function (e) {
    var cakeId = $(this).attr("data-wishlist-cakeId");
    e.preventDefault();
    $.post("/Wishlist/AddToWishlist", { "id": cakeId }, function (data) {
        if (data) {
            location.reload();
        }
    });
});