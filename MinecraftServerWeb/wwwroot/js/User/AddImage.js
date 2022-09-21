/*
$(document).ready(function () {
    var fileInput = $("#getFile");
    var previewLabel = $("#previewLabel");
    var imageName = $("#imageName");
    fileInput[0].addEventListener("change",
        function () {
            previewLabel[0].style.visibility = "visible";
            imageName[0].style.visibility = "visible";
            imageName[0].value = fileInput.files[0].name;

        });
});
*/



function previewImage() {

    var fileInput = window.$("#getFile");
    var previewLabel = window.$("#previewLabel");
    var imageName = window.$("#imageName");
    fileInput[0].addEventListener("change",
        function () {
            previewLabel[0].style.visibility = "visible";
            imageName[0].style.visibility = "visible";
            imageName[0].innerHTML = "wybrane zdjęcie: " + "<strong>" + fileInput[0].files[0].name + "<\strong>";

        }, false);
    fileInput.click();
}