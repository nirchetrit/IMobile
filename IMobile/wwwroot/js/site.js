// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function updateTransition() {
    var el = document.querySelector("div.box");

    if (el) {
        el.className = "box1";
    } else {
        el = document.querySelector("div.box1");
        el.className = "box";
    }

    return el;
}

var intervalID = window.setInterval(updateTransition, 7000);
