$("#wishlistRemove").click(function () {
    var cakeId = $(this).attr("data-cakeId");
    $.post("/Wishlist/RemoveWishlist", { "cakeId": cakeId }, function (data) {
        if (data){
            location.reload();
        }
    });
});