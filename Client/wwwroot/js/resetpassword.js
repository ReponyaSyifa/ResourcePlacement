// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("tezz");

$(document).ready(function () {

    $('#submitReset').click(function () {
        var reset = {};
        reset.Email = $('#email').val();

        //console.log(emp);
        $.ajax({
            url: "https://localhost:44338/api/account/resetpassword",
            type: "POST",
            data: JSON.stringify(reset),
            contentType: "application/json",
            success: function () {
                Swal.fire({
                    icon: 'success',
                    title: 'Email Sent!',
                    showConfirmButton: false,
                    timer: 1500
                })
            },
            error: function (err) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong, Call Helpdesk!',
                    showConfirmButton: false,
                    timer: 1800
                })
            }
        });
    })
});