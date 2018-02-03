
///////Filtrado en las tablas, sirve para todas las paginas que contenga una tabla !////////////////

var busqueda = document.getElementById('buscar');
var table = document.getElementsByTagName('table')[0].tBodies[0];

buscaTabla = function () {
    texto = busqueda.value.toLowerCase();
    var r = 0;
    while (row = table.rows[r++]) {
        if (row.innerText.toLowerCase().indexOf(texto) !== -1) {
            row.style.display = null;
        } else
            row.style.display = 'none';

    }
}
busqueda.addEventListener('keyup', buscaTabla);