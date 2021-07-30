//$(document).ready(function () {
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
            val.status//#exampleModal
            //,`<button class="btn btn-primary modalClass"  data-id="${val.participantId}" data-toggle="modal" data-target="#exampleModal">
            //    Detail
            //</button>`
        ]).draw(false)
        no++;
    })
}).fail((error) => {
    console.log(error);
});

//detail participant
$(document).on("click", ".modalClass", function () { // untuk ambil data-id wajib menggunakan class yang ada di button
    var nik = $(this).data('id');
    //console.log(nik)
    $.ajax({
        url: "https://localhost:44338/api/participant/ShowSkillParticipant/" + nik
    }).done((result) => {

        console.log(result.skillName);
        //=====================================================================================

        //untuk menampilkan ability
        abilityPokemon = "";
        $.each(result, function (key, val) {
            abilityPokemon += `<span>${val.skillName}</span> `;
        })
        $("#abilitiesPokemon").html(abilityPokemon);

        //=====================================================================================


    }).fail((error) => {
        console.log(error);
    });
});

////detail participant
//$(document).on("click", ".modalAddParticipant", function () {
//    $.ajax({
//        url: "https://localhost:44338/api/skill"
//    }).done((result) => {
//        //=====================================================================================
//        //untuk menampilkan type
//        skills = "";
//        $.each(result, function (key, val) {
//            skills += `<option value="${val.skillId}">${val.skillName}</option>`;
//        })
//        atas = '<label for="skills">Skills</label>';
//        atas2 = '<select class="choices form-select multiple-remove" multiple = "multiple" id = "skills" >';
//        atas3 = '<optgroup label="Skills">';
//        bawah = '</optgroup></select >'
//        $("#blabla").html(atas+atas2+atas3+skills+bawah);

//    }).fail((error) => {
//        console.log(error);
//    });
//});

// change password
function PostChangePassword(item) {
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44338/api/account/changepassword",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function () {
            Swal.fire({
                icon: 'success',
                title: 'Change Password Succeed!',
                showConfirmButton: false,
                timer: 1500
            })
        },
        error: function (err) {
            Swal.fire({
                icon: 'error',
                title: 'Oh Snap!',
                text: 'Change Password Failed!'
            })
        }
    });
};
//change password
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

function PostParticipant(item) {
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44338/api/participant/add",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function () {
            Swal.fire({
                icon: 'success',
                title: 'New Participant Added!',
                showConfirmButton: false,
                timer: 1500
            })
        },
        error: function (err) {
            Swal.fire({
                icon: 'error',
                title: 'Oh Snap!',
                text: 'Add New Participant Failed!'
            })
        }
    });
};

/*jQuery(function () {
    jQuery("#skills").change(function () {
        var ids = $(this).val();
        console.log(ids);
        jQuery.ajax({
            url: "https://localhost:44338/API/Skill",
            type: "GET",
            data: {
                "ids": "skillId"
            },
            dataType: "html",
            success: function (data) {
                jQuery('#skills').html(data);
            }
        });
    });
});*/

//add participant
function AddParticipant() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya

    var skills = [];
    for (var option of document.getElementById('skills').options) {
        if (option.selected) {
            var skillId = parseInt(option.value);
            skills.push(skillId);
        }
    }

    var grade = "";
    for (var option of document.getElementById('grade').options) {
        if (option.selected) {
            grade = option.value;
        }
    }

    var gender = "";
    for (var option of document.getElementById('gender').options) {
        if (option.selected) {
            var gg = parseInt(option.value);
            gender = gg;
        }
    }
    obj.FirstName = $("#fname").val();
    obj.LastName = $("#lname").val();
    obj.Email = $("#email").val();
    obj.Gender = gender;
    obj.PhoneNumber = $("#phone").val(); 
    obj.BirthDate = $('#birthdate').val();
    obj.Grade = grade;
    obj.ListSkill = skills;

    // Regular Expression For Email
    emailReg = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    passReg = /^[0-9a-zA-Z]{8,}$/;

    if (obj.FirstName != '' && obj.LastName != '' && obj.PhoneNumber != ''
        && obj.BrithDate != '' && obj.Email != '' && obj.Gender != '' && obj.Grade != ''
        && obj.ListSkill != '') {
        PostParticipant(obj);
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Hmm!?',
            text: 'Every Column Need To Be Fill!',
            showConfirmButton: true
        });
    }
};