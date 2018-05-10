//$(document).ready(function () {
//    $('#MainContent_grvPartidas').closest('div').attr('class', 'table-responsive');
//    $('#MainContent_grvPartidas').closest('div').attr('style', 'overflow: scroll; height:300px;');
////    $('#MainContent_grvPartidas').closest('div').attr('id', 'divGrvPartidas');
////    var DivResponsive = document.getElementById("divResponsiveGrvPartidas");
////    var DivGrvPartidas = document.getElementById("divGrvPartidas");
////    DivResponsive.removeChild(DivGrvPartidas);
//});
function GetKey(sender, eventArgs) {
    try {
        document.getElementById('MainContent_keycontainer').value = eventArgs.get_value();
    } catch (e) {
        document.getElementById('MainContent_keycontainer').value = eventArgs.get_value();
    }
}
function GetKeyProduct(sender, eventArgs) {
    try {
        document.getElementById('MainContent_hdnProducto').value = eventArgs.get_value();
    } catch (e) {
        document.getElementById('MainContent_hdnProducto').value = eventArgs.get_value();
    }
}
function Check(parametro) {
//    var seleccionados = document.getElementById('MainContent_hdnProductosSeleccionados').value;
//     if (seleccionados == 0 || seleccionados == undefined) {
//        document.getElementById('MainContent_hdnProductosSeleccionados').value = '0';

    if (parametro.firstChild.checked) {
//        var suma = parseFloat(cadenaImporte) + parseFloat(importepago);
//        document.getElementById("CPHIntegraCompany_txtPagoImporte").value = nuevoImportePago.toString();
        console.log('unchecked');
            
    } else {
        console.log('unchecked');
    }
}