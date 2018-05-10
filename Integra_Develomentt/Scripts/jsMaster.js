$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip({ delay: { show: 0, hide: 0} });
});
function ToolTip() {
    $('[data-toggle="tooltip"]').tooltip({ delay: { show: 0, hide: 0} });
}
function mdlToggle(mdl) {
    $(mdl).modal('toggle');
}
function mdlToggle2(mdl1, mdl2) {
    $(mdl1).modal('toggle');
    $(mdl2).modal('toggle');
}
function tab(nombre) {
    $(nombre).tab('show')
}
function select(nombre) {
    document.getElementById(nombre.id).select();
}
function focus(nombre) {
    document.getElementById(nombre.id).focus();
}
function redirect(pag) {
    location.href = pag;
}
function reload() {
    location.reload();
}