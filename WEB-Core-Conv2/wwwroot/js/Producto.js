$("#btnGuardar").click(function () {
    var Nombre = $(".Nombre").val();
    var Precio = $(".Precio").val();
    var Descripcion = $(".Descripcion").val();

    if (Nombre == "") {
        alert("El Nombre es requerido");
    }
    else
    {
        var xhr = $.ajax({
            url: "CrearProducto",
            type: "POST",
            data: {
                "Nombre": Nombre,
                "Precio": Precio,
                "Descripcion": Descripcion
            }
        });
        xhr.done(function (data) {
            if (data.success) {
                alert('Has agregado un nuevo producto!');
                setTimeout(function () {
                    location.href = "../Home/Producto";
                }, 2000)
            }
            else {
                alert('Error');
            }
        });
        xhr.fail(function () {
            notif({
                msg: "Error al guardar el producto",
                    type: "error"
            });
        });
    }
})