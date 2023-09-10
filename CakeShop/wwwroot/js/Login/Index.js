$(".password-visibility-button").click(function (){
    let button = $(this);
    let input = button.parent().find("input");
    if(!input){
        return;
    }
    
    if(input.attr("type") === "password") {
        input.attr("type", "text");
    } else {
        input.attr("type", "password");
    }
    
    let icon = button.find("i");
    if(icon) {
        icon.toggleClass("fa-eye-slash").toggleClass("fa-eye");
    }
})