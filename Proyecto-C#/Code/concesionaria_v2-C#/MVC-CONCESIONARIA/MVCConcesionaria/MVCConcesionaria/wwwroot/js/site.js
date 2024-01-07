// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let usado = document.querySelector("#usado")
let kms = document.querySelector("#kms")
console.log(usado)
console.log(usado.checked)
usado.addEventListener("click", function () {
    if (kms.classList.contains("none")) {
        kms.classList.remove('none');
    } else {
        kms.classList.add('none');
    }
})