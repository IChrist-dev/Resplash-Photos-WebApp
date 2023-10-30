// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#photoModal").on('show.bs.modal', function (event) {
    // Image that was clicked
    const btnImage= event.relatedTarget

    // Get the photo url from data-bs-* attribute
    const url = btnImage.getAttribute('data-bs-photo')

    // Switch the image
    const modalImg = photoModal.querySelector('#img-modal')
    modalImg.src = url

});