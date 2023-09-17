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

const passwordInput = document.getElementById('password-input');
const showHideButton = document.getElementById('show-hide-button');

passwordInput.addEventListener('focus', () => {
    showHideButton.style.display = 'block'; // Inputa tıklandığında butonu görünür yap
});

passwordInput.addEventListener('blur', () => {
    showHideButton.style.display = 'none'; // Input'tan çıkıldığında butonu gizle
});

showHideButton.addEventListener('click', () => {
    // Buton tıklandığında parolayı göster/gizle işlemini gerçekleştirin
    if (passwordInput.type === 'password') {
        passwordInput.type = 'text';
        showHideButton.querySelector('i').classList.remove('fa-eye-slash');
        showHideButton.querySelector('i').classList.add('fa-eye');
    } else {
        passwordInput.type = 'password';
        showHideButton.querySelector('i').classList.remove('fa-eye');
        showHideButton.querySelector('i').classList.add('fa-eye-slash');
    }
});
