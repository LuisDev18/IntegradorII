$(document).ready(function () {

});


function ValidateAccess() {    

    var user = document.getElementById('txtCIP').value;
    var password = document.getElementById('txtPassword').value;

    if (user.length == 0 || password.length == 0) {
        toastr.error("Debe ingresar el usuario y la contraseña!");
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
                if (response.ok == true) {
                    toastr.success("Bienvenido " + response.body.usuario.usernameCIP + "!");
                    setTimeout(function () {
                        window.open('/User/RedirectUser', "_self");
                    }, 2000);

                }
                else {
                    swal("Acceso denegado", response.message, "error");
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
