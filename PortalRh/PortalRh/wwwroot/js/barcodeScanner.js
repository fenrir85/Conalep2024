

window.startBarcodeScanner = () => {
    const video = document.getElementById('barcodeScanner');

    const constraints = {
        video: { facingMode: "environment" } // Rear camera
    };

    navigator.mediaDevices.getUserMedia(constraints)
        .then(function (stream) {
            video.srcObject = stream;
            video.play();
        })
        .catch(function (err) {
            console.log("An error occurred: " + err);
        });
};

window.scanBarcode = async () => {
    const video = document.getElementById('barcodeScanner');
    const canvas = document.createElement('canvas');
    const context = canvas.getContext('2d');

    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;

    context.drawImage(video, 0, 0, canvas.width, canvas.height);

    const imageData = context.getImageData(0, 0, canvas.width, canvas.height);
    const codeReader = new ZXing.BrowserQRCodeReader();

    const barcodeResult = await codeReader.decodeFromImage(imageData);
    return barcodeResult.text;
};
