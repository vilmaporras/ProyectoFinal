//Definir el evento click para el botòn Guardar
$("#btnGuardar").click(function () {
    //alert("Hola soy el evento click");
    //obtener los valores
    var nombre = $(".nombre").val();
    var descripcion = $(".descripcion").val();
    //Dejar caer los valores en el contenedor
    //$(".contenedor").text(nombre + " - " + descripcion);
    if (nombre == "" || descripcion == "") {
        alert("El campo Nombre es requerido");
    }
    else {
        //Hace la peticiòn al servidor para crear la nuva categhorìa
        //utilizar ajax
        var xhr = $.ajax({
            //url de destino
            url: "CrearCategoria",
            type: "POST",
            // agregar paràmetros de la peticiòn
            data: {
                "Nombre": nombre, //especificar a como se encuentra en la bd
                "Descripcion": descripcion
            }
        });
        xhr.done(function (data) {
            if (data.success) {
                //Swal.fire('Guardado', data.Message, 'success')
                alert('Has agregado una nueva categoría!!');
                //$(".nombre").val("");
                //$(".descripcion").val("");
                setTimeout(function () {
                    location.href = "../Home/ListaCategoria";
                }, 2000) //equivale a 2 segundos
            }
            else {
                alert('Error!!');
            }
        });

        xhr.fail(function () {
            notif({
                msg: "Error al guardar la categorìa",
                type: "error"
            });
        });
    }
});

