$(document).ready(function() {
    cargarTabla()
})

function cargarTabla() {
    const url = 'https://localhost:44313/segundo/GetObras'

    fetch(url)
    .then(response => response.json())
    .then(response => {
        if(response.success) {
            const body = document.querySelector("tbody")

            response.data.forEach(obra => {
                let fila = document.createElement("tr")
                fila.innerHTML += `<td>${obra.nombre}</td>`
                fila.innerHTML += `<td>${obra.datosVarios}</td>`
                fila.innerHTML += `<td>${obra.idTipoObraNavigation.nombre}</td>`
                fila.innerHTML += `<td>${obra.cantidadAlbaniles}</td>`
                if(obra.idTipoObraNavigation.nombre === "Edifico"){
                    fila.innerHTML += `<td>
                                            <button type="button" class="btn btn-info" id="btnAsignar" onclick="redireccionar('${obra.id}')">Asignar albañil</button>
                                        </td>`
                }
                fila.innerHTML += `<td>
                
                                    </td>`
                

                body.append(fila)
            });
        }
        else {
            console.log(response.errorMessage)
        }
    })
    .catch(err => {
        console.log(err)
    })
}

function redireccionar(id) {
    $(location).attr('href', `http://127.0.0.1:5500/altaalbanilxobra.html?id=${id}`)
}