$(document).ready(function () {
    $(".long-text").each(function () {
        var content = $(this).text(); // Sadece metni al
        var maxLength = 50;

        if (content.length > maxLength) {
            var trimmedContent = content.substring(0, maxLength);
            var showMoreContent = content.substring(maxLength, content.length);
            var html = trimmedContent + '<span class="more-content">' + showMoreContent + '</span> <a href="#" class="show-more-link">More</a>';
            $(this).html(html);

            $(this).find(".show-more-link").click(function (e) {
                e.preventDefault();
                $(this).siblings(".more-content").toggle();
                $(this).text($(this).text() === "More" ? "Fewer" : "More");
            });

            $(this).find(".more-content").hide();
        }
    });
});
