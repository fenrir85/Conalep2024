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
function DownloadZip(nombreArchivo, base64Zip) {
    const byteCharacters = atob(base64Zip);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);

    const blob = new Blob([byteArray], { type: 'application/zip' });
    const url = URL.createObjectURL(blob);

    const a = document.createElement('a');
    a.href = url;
    a.download = nombreArchivo;
    document.body.appendChild(a);
    a.click();

    document.body.removeChild(a);
    URL.revokeObjectURL(url);
}
