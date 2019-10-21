// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* When the input field receives input, convert the value from fahrenheit to celsius */
var url = 'https://newsapi.org/v2/top-headlines?' +
    'country=us&' +
    'apiKey=296d91888e5347b49bf9dc9574843ea3';
var req = new Request(url);
fetch(req)
    .then(function (response) {
        console.log(response.json());
    })