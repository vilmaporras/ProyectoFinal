// Evento que envía una petición Ajax al servidor
$('#btnGuardar').click(function (e) {

    var categoria = {
        nombre: $('.nombre').val(),
        descripcion: $('.descripcion').val()
    };

    $.ajax({
        type: "POST",
        url: "CrearCategoria",
        content: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(categoria),
        success: function (d) {
            if (d.success == true)
                alert('Has agregado una nueva categoría!!');
            else { }
        },
        error: function (xhr, textStatus, errorThrown) {
            alert('Error!!');
        }
    });
});