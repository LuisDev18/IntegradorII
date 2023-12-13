$(document).ready(function () {

});


function ValidateAccess() {    

    var user = document.getElementById('txtCIP').value;
    var password = document.getElementById('txtPassword').value;
    
    if (password.length == 0) {
        toastr.error("Debe ingresar la contraseña!");
    }
    else if (user.length < 1 || user.length > 9) {
        toastr.error("El usuario debe tener entre 1 y 9 digitos");
    }
    else {
        document.getElementById("loader").style.display = "block";

        $.ajax({
            method: "POST",
            dataType: "json",
            url: "/User/ValidateAccess",
            data: {
                'user': user,
                'password': password,
            },
            error: function () {
                document.getElementById("loader").style.display = "none";
                swal("Ocurrió un error inesperado", "No se pudo establecer la conexión.", "error");
            },
            success: function (response) {
                debugger;
                if (response.ok == true) {
                    toastr.success("Bienvenido " + response.usernameCIP + "!");
                    setTimeout(function () {
                        window.open('/User/RedirectUser', "_self");
                    }, 2000);

                }
                else {
                    swal("Acceso denegado", response.data.message, "error");
                    document.getElementById("loader").style.display = "none";
                }

            }
        })
    }    
}

document.getElementById("txtPassword").addEventListener("keypress", function (event) {
    // If the user presses the "Enter" key on the keyboard
    if (event.key === "Enter") {
        // Cancel the default action, if needed
        event.preventDefault();
        // Trigger the button element with a click
        ValidateAccess();
    }
}); 
