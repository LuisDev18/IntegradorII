$(document).ready(function () {

});


function UpdateClientInfo() {    
    
    var phone = document.getElementById('txtTelefono').value.trim();
    var email = document.getElementById('txtEmail').value.trim();
    var address = document.getElementById('txtDireccion').value.trim();

    var validEmail = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;                     
    var validPhone = /^[0-9]+$/;
        
    if (phone.length == 0 || email.length==0 || address.length==0) {
        toastr.error("Debe llenar todos los datos solicitados");        
    }
    else if (!phone.match(validPhone)){
        toastr.error("El número celular debe ser numérico");
    }
    else if (!email.match(validEmail)){
        toastr.error("El correo electrónico no tiene el formato correcto");
    }
    else {
        document.getElementById("loader").style.display = "block";

        $.ajax({
            method: "POST",
            dataType: "json",
            url: "/User/UpdatePersonalInfo",
            data: {
                'phone': phone,
                'email': email,
                'address': address
            },
            error: function () {
                document.getElementById("loader").style.display = "none";
                swal("Ocurrió un error inesperado", "No se pudo establecer la conexión.", "error");
            },
            success: function (response) {
                if (response.ok == true) {
                    toastr.success("Datos guardados correctamente");
                }
                else {
                    swal("Ocurrió un error inesperado", response.message, "error");                    
                }
                document.getElementById("loader").style.display = "none";
            }
        })
    }    
}