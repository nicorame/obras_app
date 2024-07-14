//https://localhost:44313/primer/deportes/GetAll
//https://localhost:44313/primer/PostSocio

$(document).ready(function () {
    $('#altaSocio').validate({
        rules: {
            email: {
                required: true
            },
            nombre: {
                required: true
            },
            apellido: {
                required: true
            },
            dni: {
                required: true
            },
            deporte: {
                required: true
            },
            telefono: {
                required: true
            },
            calle: {
                required: true
            },
            codPostal: {
                required: true
            },
            provincia: {
                required: true
            },
            ciudad: {
                required: true
            },
            numero: {
                required: true
            },
        },
        messagess: {
            email: {
                required: "Ingresar"
            },
            nombre: {
                required: "Ingresar"
            },
            apellido: {
                required: "Ingresar"
            },
            dni: {
                required: "Ingresar"
            },
            deporte: {
                required: "Ingresar"
            },
            telefono: {
                required: "Ingresar"
            },
            calle: {
                required: "Ingresar"
            },
            codPostal: {
                required: "Ingresar"
            },
            provincia: {
                required: "Ingresar"
            },
            ciudad: {
                required: "Ingresar"
            },
            numero: {
                required: "Ingresar"
            },
        },
        errorClass: "text-danger mt-2"
    })

        cargarSelect()

        $('#btnRegistrarSocio').click(function () {
            if ($('#altaSocio').valid()) {
                altaSocio()
            }
        })
})

function cargarSelect() {
    const url = 'https://localhost:44313/primer/deportes/GetAll'

    fetch(url)
        .then(response => response.json())
        .then(response => {
            if (response.success) {

                const select = document.getElementById("idDeporte")

                response.data.forEach(deporte => {
                    let opt = document.createElement("option")
                    opt.appendChild(document.createTextNode(deporte.nombre))
                    opt.value = deporte.id

                    select.append(opt)
                });

            } else {
                console.log(response.errorMessage)
            }
        })
        .catch(err => {
            console.log(err)
        })
}

function altaSocio() {
    const url = 'https://localhost:44313/primer/PostSocio'

    const email = $('#idEmail').val();
    const nombre = $('#idNombre').val();
    const apellido = $('#idApellido').val();
    const dni = $('#idDni').val();
    const deporte = $('#idDeporte').val();
    const telefono = $('#idTelefono').val();
    const calle = $('#idCalle').val();
    const numero = $('#idNumero').val();
    const codPostal = $('#idCodPostal').val();
    const provincia = $('#idProvincia').val();
    const ciudad = $('#idCiudad').val();

    fetch(url, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            email: email,
            nombre: nombre,
            apellido: apellido,
            dni: dni,
            idDeporte: deporte,
            telefono: telefono,
            calle: calle,
            numero: numero,
            codPost: codPostal,
            provincia: provincia,
            ciudad: ciudad
        })
    })
    .then(response => response.json())
    .then(response => {
        if(!response.success){
            console.log(response.errorMessage)
        }
        else {
            Swal.fire({
                icon: "success",
                title: "Socio cargado",
                showConfirmButton: false,
                timer: 2400
            });
            localStorage.setItem("nombreSocio",nombre)
            localStorage.setItem("apellidoSocio", apellido)
            localStorage.setItem("dni", dni)

            setInterval(() => {
                location.reload()},
                2600
            )
        }
    })
    .catch(err => {
        console.log(err)
    })
}