$("#wishlistRemove").click(function () {
    var cakeId = $(this).attr("data-cakeId");
    $.post("/Wishlist/RemoveWishlist", { "id": cakeId }, function (data) {
        if (data){
            location.reload();
        }
    });
});

$.ajax({
    type: "GET",
    url: "/Wishlist/GetWishlistItems/",
    success: function (data) {
        var wishlistItemsCount = parseInt(data);
        var newIconPath = "/template/img/icon/heart-orange-icon.png";
        if (wishlistItemsCount > 0) {
            $(document).ready(function () {
                $("#heartIcon").hover(function () {
                    $(this).attr("src", newIconPath);
                }
                , function () {
                    $(this).attr("src", "/template/img/icon/heart-white.png");
                });
            });
        }
    }
});




