function mostrar() {
    //alert("Funciona");
    document.getElementById('MainContent_lnkXLS').click();
    tabNuevos();
    //mdlToggle('#mdlProceso');
}
function borrartxt(nombre) {
    document.getElementById(nombre.id).value = "";
    document.getElementById(nombre.id).focus();
}
function ValidarCampos2() {
    var hdn = document.getElementById("MainContent_hdnValidacion");
    var txt = document.getElementById("MainContent_txtProducto");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el producto.";
        return false;
    } else {
        hdn.value = "";
    }
    txt = document.getElementById("MainContent_txtPrecio");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el precio.";
        return false;
    } else {
        hdn.value = "";
    }
}
function LimpiarDatos() {
    document.getElementById("MainContent_txtProducto").value = "";
    document.getElementById("MainContent_txtCaracteristicas").value = "";
    document.getElementById("MainContent_txtPrecio").value = "";
    document.getElementById("MainContent_txtClave").value = "";
    document.getElementById("MainContent_txtCodigoBarras").value = "";
    document.getElementById("MainContent_txtProducto").focus();
}
function tabNuevos() {
    $('#tab2').tab('show')
}
function smen() {
    document.getElementById('btn1').click();
}
function ATabNuevos() {
        $('#tab2 a[href="#nuevos"]').tab('show')
}