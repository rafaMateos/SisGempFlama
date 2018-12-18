
//Aqui cargamos 
window.onload = inicializaPagina;

function inicializaPagina() {

    //var divTabla = document.getElementById("divDeTabla");
    //divTabla.removeChild(divTabla.childNodes[0]);
    getListadoPersonas();
}

/*
 Funcion para crear una tabla
 */ 

function tableCreate(ListadoPersonas) {

    // var body = document.getElementsByTagName('body')[0];//Cogemos el primer elemento del array para que solo haya un body
    var div = document.getElementById('divDeTabla');
    div.setAttribute('class', 'table-responsive-vertical shadow-z-1');
    var tbl = document.createElement('table');
    tbl.style.width = '90%';
    tbl.style.margin = '0 auto';
    tbl.setAttribute('class', 'mdl-data-table mdl-js-data-table mdl-data-table--selectable mdl-shadow--2dp');
    tbl.setAttribute('border', '3px');
   

    var tbdy = document.createElement('tbody');
    var BotonCrear = document.getElementById('Create');
    BotonCrear.setAttribute("click", clickCrear, false);

    for (var i = 0; i < ListadoPersonas.length; i++) {

        //Añadimos las filas segun la longitud del array
        //Al crear las filas tenemos que tener en cuenta la cantidad de personas que vamos a tener en nuestro array.
        var hilera = document.createElement('tr');

        //<img width="50" height="50" src="../Content/jefe.png" />
        var celdaImagen = document.createElement("img");
        celdaImagen.setAttribute('src', '../Content/jefe.png');
        celdaImagen.setAttribute('width', '40');
        celdaImagen.setAttribute('height', '40');

        hilera.appendChild(celdaImagen);

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
        botonEditar.setAttribute('class', 'mdl-button mdl-js-button mdl-button--raised mdl-button--accent');
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
        botonBorrar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
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

    document.getElementById('gif').setAttribute('hidden', 'hidden');

   
  
}

function clikEditar(Persona) {

   
    var BotonEditar = document.getElementById('Edit');

    document.getElementById('Nombre').value = Persona.nombre;
    document.getElementById('Apellidos').value = Persona.Apellidos;
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

    //BotonEditar.onclick = function () {
    //    modal.style.display = "none";
    //    //Persona.idPersona = ArrayPersonas.idPersona;
    //    Persona.IdDept = document.getElementById('Departamento').value;
    //    Persona.nombre = document.getElementById('Nombre').value;
    //    Persona.Apellidos = document.getElementById('Apellidos').value;
    //    //Persona.fechaNacimiento = ArrayPersonas.fechaNacimiento;
    //    Persona.direccion = document.getElementById('Direccion').value;
    //    Persona.telefono = document.getElementById('Telefono').value;

    //    Editar(Persona);
    //}
    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        
        if (event.target == modal) {
            modal.style.display = "none";
        } else if (event.target == Edit) {
            
            modal.style.display = "none";
            //Persona.idPersona = ArrayPersonas.idPersona;
            Persona.IdDept = document.getElementById('Departamento').value;
            Persona.nombre = document.getElementById('Nombre').value;
            Persona.Apellidos = document.getElementById('Apellidos').value;
            //Persona.fechaNacimiento = ArrayPersonas.fechaNacimiento;
            Persona.direccion = document.getElementById('Direccion').value;
            Persona.telefono = document.getElementById('Telefono').value;
            Editar(Persona);
        }

    }

   
}

function limpiar() {

    document.getElementById('NombreCrear').value = " ";
    document.getElementById('ApellidosCrear').value = " ";
    document.getElementById('TelefonoCrear').value = " ";
    document.getElementById('DireccionCrear').value = " ";
    document.getElementById('DepartamentoCrear').value = " ";

}

function Editar(Persona) {


    var miLlamada = new XMLHttpRequest();

    var json = JSON.stringify(Persona);

    miLlamada.open("PUT", "https://rafaapirestpersona.azurewebsites.net/api/personas/");
    miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    

    //Mientras viene
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //document.getElementById("textoAMostrar").innerHTML = "Sending data..."
        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 204) {

                var popup = document.getElementById("ff");
                popup.classList.toggle("show");

                //document.getElementById("mensajeOk").innerHTML = "Persona eliminada con exito"       
                inicializaPagina();
                

            }
    };

    miLlamada.send(json);

 
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
                 Persona.Apellidos = ArrayPersonas.Apellidos;
                 Persona.fechaNacimiento = ArrayPersonas.fechaNacimiento;
                 Persona.direccion = ArrayPersonas.direccion;
                 Persona.telefono = ArrayPersonas.telefono;
           
    
                clikEditar(Persona);

        }

    }

    millamada.send();
   

}



function clickCrear() {

   

    var modal = document.getElementById('myModalCrear');
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
        } else if (event.target == crear) {
            
            modal.style.display = "none";
            var Persona = new Object();
            //Persona.idPersona = ArrayPersonas.idPersona;
            Persona.IdDept = document.getElementById('DepartamentoCrear').value;
            Persona.nombre = document.getElementById('NombreCrear').value;
            Persona.Apellidos = document.getElementById('ApellidosCrear').value;
            var dt = new Date('8/24/2009');
            Persona.fechaNacimiento = dt;
            Persona.direccion = document.getElementById('DireccionCrear').value;
            Persona.telefono = document.getElementById('TelefonoCrear').value;

            Crear(Persona);
        }
    }
}

function Crear(Persona) {

    var miLlamada = new XMLHttpRequest();

    var json = JSON.stringify(Persona);

    miLlamada.open("POST", "https://rafaapirestpersona.azurewebsites.net/api/personas/");
    miLlamada.setRequestHeader('Content-type', 'application/json; charset=utf-8');


    //Mientras viene
    miLlamada.onreadystatechange = function () {

        if (miLlamada.readyState < 4) {

            //document.getElementById("textoAMostrar").innerHTML = "Sending data..."
        }
        else
            if (miLlamada.readyState == 4 && miLlamada.status == 204) {
                limpiar();
                //document.getElementById("mensajeOk").innerHTML = "Persona eliminada con exito"       
                inicializaPagina();

            }
    };

    miLlamada.send(json);


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

    constructor(idPersona, IdDept, nombre, Apellidos, fechaNacimiento, direccion, telefono) {

        this.idPersona = idPersona;
        this.nombre = nombre;
        this.Apellidos = Apellidos;
        this.fechaNacimiento = fechaNacimiento;
        this.direccion = direccion;
        this.telefono = telefono;
        this.IdDept = IdDept;

    }

    
}
    

