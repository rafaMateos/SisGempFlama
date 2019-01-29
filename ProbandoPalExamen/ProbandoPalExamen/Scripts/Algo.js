
window.onload = inicializaPagina;

function inicializaPagina() {
    //var divTabla = document.getElementById("divDeTabla");
    //divTabla.removeChild(divTabla.childNodes[0]);
    getListadoPersonas();
}

/**
  [HttpGet("{id}")]
        public string Get(int id, string foo, string bar)
        {
            return id + " " + foo + " " + bar;
        }
GET api / valores / 5
OBTENER api / valores / 5? Foo = a
OBTENER api / valores / 5? Bar = b
GET api / values ​​/ 5? Foo = a & bar = b

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

    var header = tbl.createTHead();
    var row = header.insertRow(0);
    row.insertCell(0).innerHTML = "<b>Nombre</b>";
    row.insertCell(1).innerHTML = "<b>Apellidos</b>";
    row.insertCell(2).innerHTML = "<b>Fecha nacimiento</b>";
    row.insertCell(3).innerHTML = "<b>Direccion</b>";
    row.insertCell(4).innerHTML = "<b>Telefono</b>";
    row.insertCell(5);
    row.insertCell(6);

    var tbdy = document.createElement('tbody');
    var BotonCrear = document.getElementById('Create');
   

    for (var i = 0; i < ListadoPersonas.length; i++) {

        //Añadimos las filas segun la longitud del array
        //Al crear las filas tenemos que tener en cuenta la cantidad de personas que vamos a tener en nuestro array.
        var hilera = document.createElement('tr');

        //<img width="50" height="50" src="../Content/jefe.png" />

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
       
        hilera.appendChild(celdaEditar);


        var celdaBorrar = document.createElement("td");
        var botonBorrar = document.createElement("input");
        botonBorrar.setAttribute("type", "button");
        botonBorrar.setAttribute("name", "BotonBorrar");
        botonBorrar.setAttribute("class", "mdl-button mdl-js-button mdl-button--raised mdl-button--colored");
        botonBorrar.setAttribute("value", "Borrar");
        celdaBorrar.setAttribute("id", ListadoPersonas[i].idPersona);
        
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

function getListadoPersonas() {


    var divTabla = document.getElementById("divDeTabla");
    divTabla.removeChild(divTabla.childNodes[0]);

    //alert('Hellow da'):
    var millamada = new XMLHttpRequest();
    //millamada.open('GET', "/Default/Index");
    millamada.open('GET', "https://apirestpersonasrafael.azurewebsites.net/api/personas/");

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