$("#btnGuardar").click(function () {
    var nombre = $(".nombre").val();
    var precio = $(".precio").val();
    var descripcion = $(".descripcion").val();

    if (nombre == "") {
        alert("El Nombre es requerido");
    }
    else
    {
        var xhr = $.ajax({
            url: "CrearProducto",
            type: "POST",
            data: {
                "Nombre": nombre,
                "Precio": precio,
                "Descripcion": descripcion
            }
        });
        xhr.done(function (data) {
            if (data.success) {
                alert('Has agregado un nuevo producto!');
                setTimeout(function () {
                    location.href = "../Home/ListaProductos";
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
$(document).ready(function () {
    $(function () {
        $.ajax({
            type: 'GET',
            url: "ListaCategoria",
            success: function (response) {
                $.each(response,function(indice, fila){
                    $('#categorias').append("<option value='" + fila.Nombre + "'>" + fila.Nombre + "</option>")
                });
            }
        });
    });
});