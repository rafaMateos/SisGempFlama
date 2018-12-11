
window.onload = inicializaEventos;

function inicializaEventos() {

    document.getElementById("btn_ApiPersona").addEventListener("click", callmenene, false);

}


function callmenene() {

    //alert('Hellow da'):
    var millamada = new XMLHttpRequest();
    //millamada.open('GET', "/Default/Index");
    millamada.open('GET', "https://rafaapirestpersona.azurewebsites.net/api/personas/");

    //Mientras vienen los datos
    millamada.onreadystatechange = function () {

        alert(millamada.readyState);

        if (millamada.readyState < 4) {

            document.getElementById("TextoMostrar").innerHTML = "Cargando...";

        } else if (millamada.readyState == 4 && millamada.status == 200) {

            var oPersona = new Persona();
            var ArrayPersonas = JSON.parse(millamada.responseText);
            oPersona = ArrayPersonas[0];
            document.getElementById("TextoMostrar").innerHTML = oPersona.nombre;
        }
    }
        
    millamada.send();
}


//Manera fea de crear clases y antigua , esta deprecated
function clsPersona(nombre, Apellidos, fechaNacimiento) {

    this.nombre = nombre;
    this.Apellidos = Apellidos;
    this.fechaNacimiento = fechaNacimiento;
}


//Forma bonita de crear clases
class Persona {

    //Creacion de la clase persona de la manera bonita
    constructor(nombre, Apellidos, fechaNacimiento) {

        this.nombre = nombre;
        this.Apellidos = Apellidos;
        this.fechaNacimiento = fechaNacimiento;
    }
}





