
window.onload = inicializaEventos;

function inicializaEventos() {

    document.getElementById("btn_ApiPersona").addEventListener("click", callmenene,false);

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

        } else if(millamada.readyState == 4 && millamada.status == 200) {
          document.getElementById("TextoMostrar").innerHTML = millamada.responseText;
        }
    }
        
    millamada.send();
}





