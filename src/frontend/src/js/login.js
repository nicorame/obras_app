$(document).ready(function() {
    $('#login').validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            password: {
                required: true
            }
        },
        messages: {
            email: {
                required: "Ingresar email",
                email: "Ingresar email valido"
            },
            password: {
                required: "Ingresar password"
            }
        },
        errorClass:"text-danger mt-2"
    })

    $('#btnIngresar').click(function() {
        if($('#login').valid()){
            login()
        }
    })

})

function login() {
    const url = 'https://localhost:44313/login/post'

    const email = $('#idEmail').val()
    const password = $('#idPassword').val()

    fetch(url, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            email: email,
            password: password
        })
    })
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            Swal.fire({
                icon: "error",
                title: "Email o Password incorrectas",
                showConfirmButton: false,
                timer: 2500
            });
        } else {
            const token = response.data.token
            localStorage.setItem("token", token)
            console.log(token)
            setTimeout(() => {
                $(location).attr('href', 'http://127.0.0.1:5500/altasocio.html')
            }, 1800);
        }
    })
    .catch(err => {
        console.log(err)
    })
}