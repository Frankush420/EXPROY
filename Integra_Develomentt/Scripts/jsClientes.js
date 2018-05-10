function GetKey(sender, eventArgs) {
    try {
        document.getElementById('MainContent_keycontainer').value = eventArgs.get_value();
    } catch (e) {
        document.getElementById('MainContent_keycontainer').value = eventArgs.get_value();
    }
}
function LimpiarDatos() {
    document.getElementById("MainContent_txtDomicilio").value = "";
    document.getElementById("MainContent_txtColonia").value = "";
    document.getElementById("MainContent_txtCP").value = "";
    document.getElementById("MainContent_txtDelMun").value = "";
    document.getElementById("MainContent_txtEstado").value = "";
    document.getElementById("MainContent_txtTelefonoDomicilio").value = "";
    var e = document.getElementById("MainContent_drpTipoPersona");
    var indx = e.options[e.selectedIndex].value;
    if (indx == "1") {
        document.getElementById("MainContent_txtNombreFisicas").value = "";
        document.getElementById("MainContent_txtPaterno").value = "";
        document.getElementById("MainContent_txtMaterno").value = "";
        document.getElementById("MainContent_txtNombreCortoFisicas").value = "";
        document.getElementById("MainContent_txtCURP").value = "";
        document.getElementById("MainContent_txtRFCFisicas").value = "";
        document.getElementById("MainContent_txtFechaNacimiento").value = "";
        document.getElementById("MainContent_txtCelular").value = "";
        document.getElementById("MainContent_txtCorreoFisicas").value = "";
        document.getElementById("MainContent_txtNombreFisicas").focus();
    } else {
        document.getElementById("MainContent_txtNombreMorales").value = "";
        document.getElementById("MainContent_txtNombreCortoMorales").value = "";
        document.getElementById("MainContent_txtRFCMorales").value = "";
        document.getElementById("MainContent_txtCorreoMorales").value = "";
        document.getElementById("MainContent_txtNombreMorales").focus();
    }
}
function LimpiarDatos2() {
    document.getElementById("MainContent_txtDomicilio2").value = "";
    document.getElementById("MainContent_txtColonia2").value = "";
    document.getElementById("MainContent_txtCP2").value = "";
    document.getElementById("MainContent_txtDelMun2").value = "";
    document.getElementById("MainContent_txtEstado2").value = "";
    document.getElementById("MainContent_txtTelefonoDomicilio2").value = "";
    var e = document.getElementById("MainContent_drpTipoPersona2");
    var indx = e.options[e.selectedIndex].value;
    if (indx == "1") {
        document.getElementById("MainContent_txtNombreFisicas2").value = "";
        document.getElementById("MainContent_txtPaterno2").value = "";
        document.getElementById("MainContent_txtMaterno2").value = "";
        document.getElementById("MainContent_txtNombreCortoFisicas2").value = "";
        document.getElementById("MainContent_txtCURP2").value = "";
        document.getElementById("MainContent_txtRFCFisicas2").value = "";
        document.getElementById("MainContent_txtFechaNacimiento2").value = "";
        document.getElementById("MainContent_txtCelular2").value = "";
        document.getElementById("MainContent_txtCorreoFisicas2").value = "";
    } else {
        document.getElementById("MainContent_txtNombreMorales2").value = "";
        document.getElementById("MainContent_txtNombreCortoMorales2").value = "";
        document.getElementById("MainContent_txtRFCMorales2").value = "";
        document.getElementById("MainContent_txtCorreoMorales2").value = "";
    }
    document.getElementById("MainContent_txtBusqueda").focus();
}
function ValidarCampos() {
    mdlToggle('#mdlProceso');
    var hdn = document.getElementById("MainContent_hdnValidacion");
    hdn.value = "";
    var e = document.getElementById("MainContent_drpTipoPersona");
    var indx = e.options[e.selectedIndex].value;
    if (indx == "1") {
        var txt = document.getElementById("MainContent_txtNombreFisicas");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el nombre.";
            return false;
        }
        txt = document.getElementById("MainContent_txtPaterno");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el apellido paterno.";
            return false;
        }
        txt = document.getElementById("MainContent_txtMaterno");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el apellido materno.";
            return false;
        }
        txt = document.getElementById("MainContent_txtNombreCortoFisicas");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el nombre corto.";
            return false;
        }
        txt = document.getElementById("MainContent_txtCURP");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el CURP.";
            return false;
        }
        txt = document.getElementById("MainContent_txtRFCFisicas");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el RFC.";
            return false;
        }
        txt = document.getElementById("MainContent_txtFechaNacimiento");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere la fecha de nacimiento.";
            return false;
        }
        txt = document.getElementById("MainContent_txtCelular");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el teléfono celular.";
            return false;
        }
        txt = document.getElementById("MainContent_txtCorreoFisicas");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el correo electrónico.";
            return false;
        }
    }
    else {
        var txt = document.getElementById("MainContent_txtNombreMorales");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere la razón social.";
            return false;
        }
        txt = document.getElementById("MainContent_txtNombreCortoMorales");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el nombre corto.";
            return false;
        }
        txt = document.getElementById("MainContent_txtRFCMorales");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el RFC.";
            return false;
        }
        txt = document.getElementById("MainContent_txtCorreoMorales");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el correo electrónico.";
            return false;
        }
    }
    var txt = document.getElementById("MainContent_txtDomicilio");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el domicilio.";
        return false;
    }
    txt = document.getElementById("MainContent_txtColonia");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere la colonia.";
        return false;
    }
    txt = document.getElementById("MainContent_txtCP");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el código postal.";
        return false;
    }
    txt = document.getElementById("MainContent_txtDelMun");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere la delegación / municipio.";
        return false;
    }
    txt = document.getElementById("MainContent_txtEstado");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el estado.";
        return false;
    }
    txt = document.getElementById("MainContent_txtTelefonoDomicilio");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el teléfono del domicilio.";
        return false;
    }
}
function ValidarCampos2() {
    mdlToggle('#mdlProceso');
    var hdn = document.getElementById("MainContent_hdnValidacion");
    hdn.value = "";
    var e = document.getElementById("MainContent_drpTipoPersona2");
    var indx = e.options[e.selectedIndex].value;
    if (indx == "1") {
        var txt = document.getElementById("MainContent_txtNombreFisicas2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el nombre.";
            return false;
        }
        txt = document.getElementById("MainContent_txtPaterno2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el apellido paterno.";
            return false;
        }
        txt = document.getElementById("MainContent_txtMaterno2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el apellido materno.";
            return false;
        }
        txt = document.getElementById("MainContent_txtNombreCortoFisicas2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el nombre corto.";
            return false;
        }
        txt = document.getElementById("MainContent_txtCURP2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el CURP.";
            return false;
        }
        txt = document.getElementById("MainContent_txtRFCFisicas2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el RFC.";
            return false;
        }
        txt = document.getElementById("MainContent_txtFechaNacimiento2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere la fecha de nacimiento.";
            return false;
        }
        txt = document.getElementById("MainContent_txtCelular2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el teléfono celular.";
            return false;
        }
        txt = document.getElementById("MainContent_txtCorreoFisicas2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el correo electrónico.";
            return false;
        }
    }
    else {
        var txt = document.getElementById("MainContent_txtNombreMorales2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere la razón social.";
            return false;
        }
        txt = document.getElementById("MainContent_txtNombreCortoMorales2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el nombre corto.";
            return false;
        }
        txt = document.getElementById("MainContent_txtRFCMorales2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el RFC.";
            return false;
        }
        txt = document.getElementById("MainContent_txtCorreoMorales2");
        if (txt.value == "") {
            hdn.value = "Para continuar se requiere el correo electrónico.";
            return false;
        }
    }
    var txt = document.getElementById("MainContent_txtDomicilio2");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el domicilio.";
        return false;
    }
    txt = document.getElementById("MainContent_txtColonia2");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere la colonia.";
        return false;
    }
    txt = document.getElementById("MainContent_txtCP2");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el código postal.";
        return false;
    }
    txt = document.getElementById("MainContent_txtDelMun2");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere la delegación / municipio.";
        return false;
    }
    txt = document.getElementById("MainContent_txtEstado2");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el estado.";
        return false;
    }
    txt = document.getElementById("MainContent_txtTelefonoDomicilio2");
    if (txt.value == "") {
        hdn.value = "Para continuar se requiere el teléfono del domicilio.";
        return false;
    }
}
function ClientesFisicos() {
    $('#mdlClientes').modal('toggle');
    $('#tab2').tab('show')
    document.getElementById("MainContent_drpTipoPersona").selectedIndex = 0;
    __doPostBack('ctl00$MainContent$drpTipoPersona', 'OnSelectedIndexChanged')

}
function ClientesMorales() {
    $('#mdlClientes').modal('toggle');
    $('#tab2').tab('show')
    document.getElementById("MainContent_drpTipoPersona").selectedIndex = 1;
    __doPostBack('ctl00$MainContent$drpTipoPersona', 'OnSelectedIndexChanged')

}