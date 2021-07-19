﻿//$(document).ready(function () {
//    var table = $('#table1').DataTable({
//        dom: '<"html5buttons">Blfrtip',
//        language: {
//            buttons: {
//                colvis: 'Show / Hide', // label button show / hide
//                colvisRestore: "Reset Kolom" //lael untuk reset kolom ke default
//            }
//        },
//        buttons: [
//            { extend: 'colvis', postfixButtons: ['colvisRestore'] },
//            { extend: 'copy' },
//            { extend: 'csv', title: 'Daftar Karyawan' },
//            { extend: 'pdf', title: 'Daftar Karyawan', orientation: 'landscape' },
//            { extend: 'excel', title: 'Daftar Karyawan' },
//            { extend: 'print', title: 'Daftar Karyawan' },
//        ],

//        'ajax': {
//            url: "https://localhost:44320/internal/getall",
//            dataType: "JSON",
//            dataSrc: ""
//        },

//        "columns": [
//            {
//                "data": null,
//                "render": function (data, type, row) {
//                    let name = row["FirstName"] + " " + row["LastName"]
//                    return name;
//                }
//            },
//            {
//                "data": "Email"
//            },
//            {
//                "data": "Status"
//            },
//            {
//                "data": "Grade"
//            },
//            {
//                "data": null,
//                "render": function (data, type, row) {
//                    let namber = row["PhoneNumber"].substring(0, 2);
//                    let namber2 = row["PhoneNumber"].substring(1);
//                    if (namber == "08") {
//                        let indo = "+62 ";
//                        return indo + namber2;
//                    } else {
//                        return row["PhoneNumber"];
//                    }
//                }
//            },
//            {
//                "data": "BirthDate"
//            },
//            {
//                "data": null,
//                "render": function (data, type, row) {
//                    let gender = row["Gender"];
//                    if (gender == 2) {
//                        return "Wanita";
//                    } else {
//                        return "Pria";
//                    }
//                }
//            },
//            {
//                "data": null,
//                "render": function (data, type, row) {
//                    return `<button type="button" class="btn btn-primary" data-toggle="modal" data-target=".bd-example-modal-lg">
//                                  Edit
//                            </button>
//                            <button type="button" class="btn btn-danger" data-toggle="modal" data-target=".bd-example-modal-lg">
//                                  Delete
//                            </button>
//                            `;
//                }
//            }
//        ],

//        "aoColumnDefs": [
//            { 'bSortable': false, 'aTargets': [10] }
//        ]
//    });

//    // buat reload
//    setInterval(function () {
//        table.ajax.reload();
//    }, 30000)
//});

// berhasil ini
let t = $('#table1').DataTable();
$.ajax({
    url: "https://localhost:44338/api/participant"
}).done((result) => {
    console.log(result);
    text = "";
    no = 1;
    $.each(result, function (key, val) {
        //text += "<li>" + val.name + "</li>";
        if (val.gender === 1) {
            var gg = "Pria";
        } else {
            var gg = "Wanita";
        }
        t.row.add([
            no,
            val.firstName+" "+val.lastName,
            val.email,
            gg,
            val.phoneNumber,
            val.birthDate,
            val.grade,
            val.status,//#exampleModal
            `<button class="btn btn-primary modalClass"  data-id="${val.url}" data-toggle="modal" data-target="">
                Detail
            </button>`
        ]).draw(false)
        no++;
    })
}).fail((error) => {
    console.log(error);
});


$(document).on("click", ".modalClass", function () {
    let pokemonURL = $(this).data('id');
    $.ajax({
        url: pokemonURL
    }).done((result) => {
        $("#img").html('<img class=" w-50" src="' + result.sprites.other.dream_world.front_default + '" alt="" />'); //menampilkan foto di API
        //$("#titleModelPokemon").html("Detail " + result.name); //judul di MODAL
        $("#namePokemon").html(result.name); //menampilkan dalam bentuk html untuk nama pokemon
        $("#heightPokemom").html(result.height + ' cm'); //menampilkan tinggi pokemon
        $("#weightPokemon").html(result.weight + ' Kg'); //menampilkan berat pokemon

        //=====================================================================================
        //untuk menampilkan ability
        abilityPokemon = "";
        $.each(result.abilities, function (key, val) {
            abilityPokemon += `<span>${val.ability.name}</span> `;
        })
        $("#abilitiesPokemon").html(abilityPokemon);

        //=====================================================================================
        //untuk menampilkan type
        typePokemon = "";
        $.each(result.types, function (key, val) {
            typePokemon += `<span>${val.type.name}</span><br> `;
        })
        $("#typePokemon").html(typePokemon);

    }).fail((error) => {
        console.log(error);
    });
});

function PostChangePassword(item) {
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44338/api/account/changepassword",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(item)
    }).done((result) => {
        alert('berhasil');
        window.location = "https://localhost:44320/Internal/Trainer";
    }).fail((error) => {
        alert('gagal');
    });
};

function ChangePassword() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.Email = $("#email-id").val();
    obj.OldPassword = $("#oldPassword").val();
    obj.NewPassword = $("#newPassword").val();

    console.log(obj.Email);

    // Regular Expression For Email
    emailReg = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    passReg = /^[0-9a-zA-Z]{8,}$/;

    if (obj.Email != '' && obj.OldPassword != '' && obj.NewPassword != '') {
        PostChangePassword(obj);
    } else {
        alert("Semua Harus Di Isi!!");
    }
};