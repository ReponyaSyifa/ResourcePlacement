// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("tezz");

$(document).ready(function () {

    $('#submitReset').click(function () {
        var reset = {};
        reset.Email = $('#Email').val();

        //console.log(emp);
        $.ajax({
            url: "https://localhost:44338/API/Account/ResetPassword",
            type: "POST",
            data: JSON.stringify(emp),
            contentType: "application/json"
        }).done((result) => {
            alert('Email Sent');
        }).fail((err) => {
            alert('Send Email Failed');
        });
    })
});