$(document).ready(function() {
    const nombre = localStorage.getItem("nombreSocio")
    const apellido = localStorage.getItem("apellidoSocio")
    const dni = localStorage.getItem("dni")

    $('#SocioLocalStorage').text(`Socio: ${nombre}, ${apellido} - ${dni}`)

    cargarListado()
})

function cargarListado() {
    const url = 'https://localhost:44313/primer/GetAll'

    fetch(url)
    .then(response => response.json())
    .then(response => {
        if(response.success){
            const body = document.querySelector("tbody")

            response.data.forEach(socio => {
                let fila = document.createElement("tr")
                fila.innerHTML += `<td>${socio.nombre}</td>`
                fila.innerHTML += `<td>${socio.apellido}</td>`
                fila.innerHTML += `<td>${socio.dni}</td>`
                fila.innerHTML += `<td>${socio.idDeporteNavigation.nombre}</td>`
                
                if(socio.idDeporteNavigation.nombre === "Tenis"){
                    fila.innerHTML +=   `<td>
                                            <button type="button" class="btn btn-info" onclick="infoTenis('${socio.nombre}', '${socio.apellido}', '${socio.dni}', '${socio.idDeporteNavigation.nombre}', '${socio.fechaAlta}')">Mostrar mas</button>
                                        </td>`
                } else{
                    fila.innerHTML +=   `<td>
                                            <button type="button" class="btn btn-info" onclick="info('${socio.nombre}', '${socio.apellido}', '${socio.dni}')">Mostrar mas</button>
                                        </td>`         
                }

                body.append(fila)
            });


        } else {
            console.log(response.errorMessage)
        }
    })
    .catch(err => {
        console.log(err)
    })    
}

function infoTenis(nombre, apellido, dni, deporteNombre, fechaAlta){
    Swal.fire({
        icon: "success",
        title: `Nombre: ${nombre}. Apellido: ${apellido}. Dni: ${dni}. Deporte: ${deporteNombre}. Fecha de alta: ${fechaAlta}`,
        showConfirmButton: false,
        timer: 3500
    });
}

function info(nombre, apellido,dni){
    Swal.fire({
        icon: "success",
        title: `Nombre: ${nombre}. Apellido: ${apellido}. Dni: ${dni}.`,
        showConfirmButton: false,
        timer: 3500
    });
}