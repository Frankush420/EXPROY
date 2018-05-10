function borrartxt(nombre) {
    document.getElementById(nombre.id).value = "";
}
function ValidarCampos(){
    var hdn = document.getElementById("MainContent_hdnValidacion");
    var txt = document.getElementById("MainContent_txtNombre");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el nombre.";
        return false;
    } else {
        hdn.value = "";
    }
}
function cambiarnombre(parametro) {
    var valor = document.getElementById(parametro.id).value;
    var lbl = document.getElementById("MainContent_lblNombreClasificacion");
    
    lbl.innerHTML = valor.toUpperCase();
}
function modal() {
    $('#ventana1').modal('show');
}
function reload() {
    location.reload();
}