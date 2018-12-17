﻿
//Aqui cargamos 
window.onload = inicializaPagina;

function inicializaPagina() {

    getListadoPersonas();
}

/*
 
 Funcion ejemplo para crear una tabla

 */ 

function tableCreate(ListadoPersonas) {

    // var body = document.getElementsByTagName('body')[0];//Cogemos el primer elemento del array para que solo haya un body
    var div = document.getElementById('divDeTabla');
    div.setAttribute('class', 'table-responsive-vertical shadow-z-1');
    var tbl = document.createElement('table');
    tbl.style.width = '100%';
    tbl.setAttribute('class', 'mdl-data-table mdl-js-data-table mdl-data-table--selectable mdl-shadow--2dp');
    tbl.setAttribute('border', '3px');
   

    var tbdy = document.createElement('tbody');

    for (var i = 0; i < ListadoPersonas.length; i++) {

        //Añadimos las filas segun la longitud del array
        //Al crear las filas tenemos que tener en cuenta la cantidad de personas que vamos a tener en nuestro array.
        var hilera = document.createElement('tr');

        for (var prop in ListadoPersonas[0]) {

            var celda = document.createElement('td');
            var textocelda = document.createTextNode(ListadoPersonas[i][prop]);
            //i == 1 && j == 1 ? celda.setAttribute('padding', '2') : null;


            celda.appendChild(textocelda);
            hilera.appendChild(celda);
          
        }

        var celdaEditar = document.createElement("td");
        var botonEditar = document.createElement("input");
        botonEditar.setAttribute('name', 'botonEditar');
        botonEditar.setAttribute('class', 'mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect');
        botonEditar.setAttribute("type", "button");
        botonEditar.setAttribute("value", "Editar");
        celdaEditar.appendChild(botonEditar);
        celdaEditar.setAttribute("id", ListadoPersonas[i].idPersona);
        celdaEditar.addEventListener("click", getPersona, false);
        hilera.appendChild(celdaEditar);


        var celdaBorrar = document.createElement("td");
        var botonBorrar = document.createElement("input");
        botonBorrar.setAttribute("type", "button");
        botonBorrar.setAttribute("name", "BotonBorrar");
        botonBorrar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect");
        botonBorrar.setAttribute("value", "Borrar");
        celdaBorrar.setAttribute("id", ListadoPersonas[i].idPersona);
        celdaBorrar.addEventListener("click", clickBorrar, false);
        celdaBorrar.appendChild(botonBorrar);
        
        hilera.appendChild(celdaBorrar);

        tbdy.appendChild(hilera);

        //Debemos dar estilo a nuestra tabla despues que este creada obviamente
        
    }

    //var td = document.getElementsByTagName('td');
    //td.setAttribute('class', 'mdl-data-table__cell--non-numeric');
    //var th = document.getElementsByTagName('th');
    //th.setAttribute('class', 'mdl-data-table__cell--non-numeric');

    tbl.appendChild(tbdy);
    document.getElementById('divDeTabla').appendChild(tbl);

   
  
}

function clikEditar(Persona) {

    document.getElementById('Nombre').value = Persona.nombre;
    document.getElementById('Apellidos').value = Persona.apellidos;
    document.getElementById('Telefono').value = Persona.telefono;
    document.getElementById('Direccion').value = Persona.direccion;
    document.getElementById('Departamento').value = Persona.IdDept;
    
    // Get the modal
    var modal = document.getElementById('myModalEditar');
    var span = document.getElementsByTagName('span');
    // Get the button that opens the modal

   

    // When the user clicks the button, open the modal 

    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        } else if (event.target == si) {
            modal.style.display = "none";
            Editar(Persona);
        }

    }
}

function Editar(Persona) {

    //var miLlamada = new XMLHttpRequest();
    //miLlamada.open("PUT", "https://rafaapirestpersona.azurewebsites.net/api/personas/" + idPersona);

    ////Mientras viene
    //miLlamada.onreadystatechange = function () {

    //    if (miLlamada.readyState < 4) {

    //        //document.getElementById("textoAMostrar").innerHTML = "Sending data..."
    //    }
    //    else
    //        if (miLlamada.readyState == 4 && miLlamada.status == 200) {

    //            //document.getElementById("mensajeOk").innerHTML = "Persona eliminada con exito"       
    //            inicializaPagina();


    //        }

    //};

    //miLlamada.send();


    
}

/*
 Funcion JS la cual hara una llamada a la api y nos devolvera un listado de las personas.
 */
function getListadoPersonas() {


    var divTabla = document.getElementById("divDeTabla");
    divTabla.removeChild(divTabla.childNodes[0]);
    //alert('Hellow da'):
    var millamada = new XMLHttpRequest();
    //millamada.open('GET', "/Default/Index");
    millamada.open('GET', "https://rafaapirestpersona.azurewebsites.net/api/personas/");

    //Mientras vienen los datos
    millamada.onreadystatechange = function () {

        var ArrayPersonas;

        //alert(millamada.readyState);
        if (millamada.readyState < 4) {

            //TODO

        } else if (millamada.readyState == 4 && millamada.status == 200) {

            //var oPersona = new Persona();
            ArrayPersonas = JSON.parse(millamada.responseText);
            tableCreate(ArrayPersonas);
        
        }
        
    }

    millamada.send();

}

function getPersona() {

    var id = this.id;

    var Persona = new Object();

    var millamada = new XMLHttpRequest();
    //millamada.open('GET', "/Default/Index");
    millamada.open('GET', "https://rafaapirestpersona.azurewebsites.net/api/personas/" + id);

    //Mientras vienen los datos
    millamada.onreadystatechange = function () {

        var ArrayPersonas;

        //alert(millamada.readyState);
        if (millamada.readyState < 4) {

            //TODO

        } else if (millamada.readyState == 4 && millamada.status == 200) {

            //var oPersona = new Persona();
                ArrayPersonas = JSON.parse(millamada.responseText);

                 Persona.idPersona = ArrayPersonas.idPersona;
            Persona.IdDept = ArrayPersonas.IdDept;
                 Persona.nombre = ArrayPersonas.nombre;
                 Persona.apellidos = ArrayPersonas.Apellidos;
                 Persona.fechaNacimiento = ArrayPersonas.fechaNacimiento;
                 Persona.direccion = ArrayPersonas.direccion;
                 Persona.telefono = ArrayPersonas.telefono;
           
    
                clikEditar(Persona);

        }

    }

    millamada.send();
   

}



function clickBorrar() {

    var idPersona = this.id;

    // Get the modal
    var modal = document.getElementById('myModal');
    var span = document.getElementsByTagName('span');
    // Get the button that opens the modal


    // When the user clicks the button, open the modal 

    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        } else if (event.target == si) {

            modal.style.display = "none";
            Borrar(idPersona);
        }
    }
}

   

        function Borrar(idPersona) {

            var miLlamada = new XMLHttpRequest();
            miLlamada.open("DELETE", "https://rafaapirestpersona.azurewebsites.net/api/personas/" + idPersona);

            //Mientras viene
            miLlamada.onreadystatechange = function () {

                if (miLlamada.readyState < 4) {

                    //document.getElementById("textoAMostrar").innerHTML = "Sending data..."
                }
                else
                    if (miLlamada.readyState == 4 && miLlamada.status == 204) {

                        //document.getElementById("mensajeOk").innerHTML = "Persona eliminada con exito"      
                        inicializaPagina();
                        


                    }

            };

           

            miLlamada.send();


}


class Persona {

    constructor(idPersona, IdDept, nombre, apellidos, fechaNacimiento, direccion, telefono) {

        this.idPersona = idPersona;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechaNacimiento = fechaNacimiento;
        this.direccion = direccion;
        this.telefono = telefono;
        this.IdDept = IdDept;

    }

    
}
    
