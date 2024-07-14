$(document).ready(function() {
    const idObra = GetParameters("id")

    $('#h1IdObra').text(`Id de Obra: ${idObra}`)

    cargarSelectAlbanilesDisponibles(idObra)
    
    $('#btnIngresarAlbanilXObras').click(function() {
        registrarAltaXObra()
    })
    
})

function cargarSelectAlbanilesDisponibles(idObra) {
    const url = `https://localhost:44313/segundo/GetAlbaniles/${idObra}`
    console.log(idObra)
    fetch(url)
    .then(response => response.json())
    .then(response => {
        if(response.success){
            const select = document.getElementById("albaniles")

            response.data.forEach(albanil => {
                let opt = document.createElement("option")
                opt.appendChild(document.createTextNode(albanil.nombre))
                opt.value = albanil.id

                select.append(opt)
            });
        }
        else {
            console.log(response.errorMessage)
        }
    })
    .catch(err => {
        console.log(err);
    })
}

function registrarAltaXObra() {
    const url = 'https://localhost:44313/segundo/PostAlbanilXObra'

    const obra = GetParameters("id")
    const albanil = $('#albaniles').val()
    const tareaARealizar = $('#tareaArealizarTextArea').val()
    
    fetch(url, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            idAlbanil: albanil,
            idObra: obra,
            tareaARealizar: tareaARealizar
        })
    })
    .then(response => response.json())
    .then(response => {
        if(response.success){
            Swal.fire({
                icon: "success",
                title: "Albañil ingresado correctamente",
                showConfirmButton: false,
                timer: 2500
            });
            setInterval(() => {
                location.reload()
            }, 2800)
        } else {
            console.log(response.errorMessage)
        }
    })
    .catch(err => {
        console.log(err)
    })
}

function GetParameters(param){
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&')

    for(var i = 0; i < url.length; i++){
        var urlParam = url[i].split('=')
        if(urlParam[0] == param){
            return urlParam[1]
        }
    }
}