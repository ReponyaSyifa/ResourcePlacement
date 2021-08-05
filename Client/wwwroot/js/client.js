$(document).ready(function () {
    var table = $("#table1").DataTable(
        {
        'ajax': {
                url: "/client/AllChoosedParticipant/",
            dataType: "json",
            dataSrc: ""
        },

        "columns": [
            {
                "data": null,
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    let name = row["firstName"] + " " + row["lastName"]
                    return name;
                }
            },
            {
                "data": "email"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    let namber = row["phoneNumber"].substring(0, 2);
                    let namber2 = row["phoneNumber"].substring(1);
                    if (namber == "08") {
                        let indo = "+62 ";
                        return indo + namber2;
                    }
                    return row["phoneNumber"];
                }
            },
            {
                "data": "birthDate",
                "render": function (data, type, row) {
                    date = new Date(data);
                    return date.toLocaleDateString();
                }
                // toLocaleDateString();

            },
            {
                "data": "status"
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    if (row["gender"]== 1) {
                        return "Pria";
                    } else {
                        return "Wanita";
                    }
                }
            },
            {
                "data": "grade"
            },
            {
                "data": null,
                "render": function (data, type, row) { // wajib pakai bootstrap 5 untuk ini template
                    return `<button type="button" class="btn btn-success modalClass" data-id="${row["participantId"]}" data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-toggle="tooltip" data-bs-placement="top" title="Detail">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-zoom-in" viewBox="0 0 16 16">
                                    <path fill-rule="evenodd" d="M6.5 12a5.5 5.5 0 1 0 0-11 5.5 5.5 0 0 0 0 11zM13 6.5a6.5 6.5 0 1 1-13 0 6.5 6.5 0 0 1 13 0z"/>
                                    <path d="M10.344 11.742c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1 6.538 6.538 0 0 1-1.398 1.4z"/>
                                    <path fill-rule="evenodd" d="M6.5 3a.5.5 0 0 1 .5.5V6h2.5a.5.5 0 0 1 0 1H7v2.5a.5.5 0 0 1-1 0V7H3.5a.5.5 0 0 1 0-1H6V3.5a.5.5 0 0 1 .5-.5z"/>
                                </svg>
                            </button>`;
                },
                searchable: false,
                orderable: false
            }
            ],
            "order": [[1, 'asc']]
        }
    );
    table.on('order.dt search.dt', function () {
        table.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    var table2 = $("#table2").DataTable(
        {
            'ajax': {
                url: "/client/getall/",
                dataType: "json",
                dataSrc: ""
            },

            "columns": [
                {
                    "data": null,
                    "searchable": false,
                    "orderable": false,
                    "targets": 0
                },
                {
                    "data": "projectName"
                },
                {
                    "data": "projectDesc"
                },
                {
                    "data": null,
                    "render": function (data, type, row) { // wajib pakai bootstrap 5 untuk ini template
                        return `<button type="button" class="btn btn-primary modalClassProject" data-id="${row["projectId"]}" data-bs-toggle="modal" data-bs-target="#cobaModal" data-bs-toggle="tooltip" data-bs-placement="top" title="Detail">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-caret-down-fill" viewBox="0 0 16 16">
                                        <path d="M7.247 11.14 2.451 5.658C1.885 5.013 2.345 4 3.204 4h9.592a1 1 0 0 1 .753 1.659l-4.796 5.48a1 1 0 0 1-1.506 0z"/>
                                    </svg>
                                </button>`;
                    },
                    searchable: false,
                    orderable: false
                }
            ],
            "order": [[1, 'asc']]
        }
    );
    table2.on('order.dt search.dt', function () {
        table2.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();

    //setInterval(function () {
    //    table.ajax.reload();
    //    table2.ajax.reload();
    //}, 30000)
});

function PostProject(item) {
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "/client/AddProject/",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(item),
        success: function () {
            Swal.fire({
                icon: 'success',
                title: 'New Project Added!',
                showConfirmButton: false,
                timer: 1500
            })
        },
        error: function (err) {
            Swal.fire({
                icon: 'error',
                title: 'Oh Snap!',
                text: 'Add New Project Failed!'
            })
        }
    });
        /*}).done((result) => {
            alert('berhasil'),
                window.location = "https://localhost:44320/eksternal/dashboard"
        }).fail((error) => {
            alert('gagal')
        });*/
   
};
//tambah projek baru
function AddProjectJS() {
    var obj = new Object();

    var skills = [];
    for (var option of document.getElementById('skills').options) {
        if (option.selected) {
            var skillId = parseInt(option.value);
            skills.push(skillId);
        }
    }

    //var custName = "";
    //for (var option of document.getElementById('custName').options) {
    //    if (option.selected) {
    //        custName = option.value;
    //    }
    //}

    obj.ProjectName = $('#ProjectName').val();
    obj.ProjectDesc = $('#ProjectDesc').val();
    /*obj.CustomerUsersId = custName;*/
    obj.ListSkill = skills;

    //validasi
    if (obj.ProjectName != '' && obj.ProjectDesc != '' && /*obj.CustomerUsersId != '' &&*/ obj.ListSkill != '') {
        PostProject(obj);
    } else {
        alert("Semua Harus Di Isi!!");
    }
};

// change password
function PostChangePassword(item) {
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44338/api/account/changepassword",
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(item)
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'Nice!',
            text: 'Change Password Succeed',
            showConfirmButton: true
        }).then(function (result) {
            if (true) {
                window.location = "https://localhost:44320/Client/";
            }
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oh Snap!',
            text: 'Change Password Failed!'
        })
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

//detail participant
$(document).on("click", ".modalClass", function () { // untuk ambil data-id wajib menggunakan class yang ada di button
    var nik = $(this).data('id');
    console.log(nik);
    $.ajax({
        url: "/Client/AllSkillParticipant/" + nik
    }).done((result) => {


        //for (var i = 0; i < result.length; i++) {
        //    console.log(result[i].skillName);
        //}
        //=====================================================================================
        //untuk menampilkan ability
        abilityPokemon = "";
        $.each(result, function (key, val) {
            console.log(val.sKillName);
            abilityPokemon += `<span class="badge bg-info">${val.sKillName}</span> `;
        })
        $(".skill").html(abilityPokemon);

        //=====================================================================================


    }).fail((error) => {
        console.log(error);
    });
});

// choose participant gak dipakai
function RejectParticipant() {
    var obj = new Object();

    obj.Status = $("#statusReject").val();
    $.ajax({
        url: "/client/ChooseParticipant/",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(obj),
        success: function () {
            Swal.fire({
                icon: 'success',
                title: 'Rejected Participant!!',
                showConfirmButton: false,
                timer: 1500
            })
        },
        error: function (err) {
            Swal.fire({
                icon: 'error',
                title: 'Oh Snap!',
                text: 'Add New Project Failed!'
            })
        }
        //}).done((result) => {
        //    console.log(result);
        //}).fail((error) => {
        //    alert('gagal')
    });
};

//$.ajax({
//    url: "https://localhost:44338/API/skill"
//}).done((result) => {
//    text = `<optgroup label="Skills">`;
//    $.each(result, function (key, value) {
//        text += `<option value="${value.skillId}">${value.skillName}</option>`;
//        //text += `<option>${value.customerUserId}`+ `</option>`;
//        console.log(value.skillName);
//    });
//    text += `</optgroup>`;
//    console.log(text);
//    $("#skills").html(text);
//}).fail((err) => {
//    console.log(err);
//});

//skill project
$(document).on("click", ".modalClassProject", function () { // untuk ambil data-id wajib menggunakan class yang ada di button

    var id = $(this).data('id');
    console.log(id);
    $.ajax({
        url: "/add2/AllSkillProject/" + id
    }).done((result) => {
        //=====================================================================================
        skillPokemon = "";
        $.each(result, function (key, val) {
            console.log(val.sKillName);
            skillPokemon += `<span class="badge bg-info">${val.sKillName}</span> `;
        })
        $(".skill").html(skillPokemon);
        //=====================================================================================


    }).fail((error) => {
        console.log(error);
    });
});