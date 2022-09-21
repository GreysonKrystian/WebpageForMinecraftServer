function previewImage() {

    function resizePhoto(previewImg, photo, width, height) {

        const reader = new FileReader();
        reader.onload = function (e) {
            let img = document.createElement("img");
            img.onload = function () {
                let canvas = document.createElement("canvas");
                let ctx = canvas.getContext("2d");
                canvas.width = width;
                canvas.height = height;
                ctx.drawImage(img, 0, 0, width, height);
                previewImg.src = canvas.toDataURL(photo.type);
            }
            img.src = e.target.result;
        }
        reader.readAsDataURL(photo);
    }

    const fileInput = window.$("#getFile");
    const previewLabel = window.$("#previewLabel");
    const imageName = window.$("#imageName");
    const previewImageLarge = window.$("#previewPhotoLarge");
    const previewImageMedium = window.$("#previewPhotoMedium");
    const previewImageSmall = window.$("#previewPhotoSmall");
    const photoDiv = window.$("#photoDiv");

    fileInput.change(function (){
        previewLabel[0].style.visibility = "visible";
        imageName[0].style.visibility = "visible";
        const photo = fileInput[0].files[0];
        if (photo) {
            imageName[0].innerHTML = window.DOMPurify.sanitize("wybrane zdjęcie: " + "<strong>" + photo.name + "<\strong>");
            photoDiv[0].style.display = "flex";
            resizePhoto(previewImageLarge[0],photo, 300, 300);
            resizePhoto(previewImageMedium[0], photo, 150, 150);
            resizePhoto(previewImageSmall[0], photo, 50, 50);
        }

    });
    fileInput.click();
}

