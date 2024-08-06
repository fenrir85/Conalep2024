function downloadFileFromStream(filename, stream) {
    const blob = new Blob([stream], { type: 'application/octet-stream' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.style.display = 'none';
    a.href = url;
    a.download = filename;
    document.body.appendChild(a);
    a.click();
    URL.revokeObjectURL(url);
}
function DescargarExcel(nombreArchivo, base64Archivo) {

    const link = document.createElement("a");
    link.download = nombreArchivo;

    /*link.href = "data:application/octet-stream;base64," + base64;*/
    link.href = "data:application/vnd.ms-excel;base64," + base64Archivo;
    /* link.href = "data:application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;base64," + base64Archivo;*/

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);


}
