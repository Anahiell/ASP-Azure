document.addEventListener('DOMContentLoaded', () => {
    const authButton = document.getElementById("auth-button");
    if (authButton) authButton.addEventListener('click', authButtonClick);
});

function authButtonClick() {
    const authEmail = document.getElementById("auth-email");
    if (!authEmail) throw "Element '#auth-email' not found";
    const authPassword = document.getElementById("auth-password");
    if (!authPassword) throw "Element '#auth-password' not found";

    const email = authEmail.value.trim();
    const password = authPassword.value;
    const authWarning = document.getElementById("auth-warning")
    if (email == "") {
        authWarning.classList.remove('visually-hidden');
        authWarning.innerText = "Enter Email";
        return;
    }
    if (password == "") {
        authWarning.classList.remove('visually-hidden');
        authWarning.innerText = "Enter Password";
        return;
    }
    fetch(`/api/auth?email=${email}&password=${password}`)       
        .then(r => r.json())        
        .then(j => {
            console.log(j);            
            if (j.status == "success") {
                window.location.reload();
            }
            else {
                authWarning.classList.remove('visually-hidden');
                authWarning.innerText = "error enter";
            }
        });
}
document.addEventListener('submit', e => {
    const form = e.target;

    if (form.id == 'category-form') {
        e.preventDefault(); 
        let formData = new FormData(form); 
        fetch("/api/shop/category", {
            method: 'POST',
            body: formData
        }).then(r => {
            console.log(r);
            if (r.status == 201) {
                window.location.reload();
            }
            else {
                r.text().then(alert);
            }
        });
    }
    if (form.id == 'product-form') {

        e.preventDefault();
        let formData = new FormData(form);
        fetch("/api/shop/product", {
            method: 'POST',
            body: formData
        }).then(r => {
            console.log(r);
            if (r.status == 201) {
                window.location.reload();
            }
            else {
                r.text().then(alert);
            }
        });
    }
});