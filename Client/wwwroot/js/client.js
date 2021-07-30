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
                    return `<button type="button" class="btn btn-primary modalClass" data-id="${row["participantId"]}" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                  Detail
                            </button>`;
                },
                searchable: false,
                orderable: false
            }
        ]
        }
    );

    var table2 = $("#table2").DataTable(
        {
            'ajax': {
                url: "/client/getall/",
                dataType: "json",
                dataSrc: ""
            },

            "columns": [
                {
                    "data": "projectName"
                },
                {
                    "data": "projectDesc"
                }
                //,{
                //    "data": null,
                //    "render": function (data, type, row) {
                //        return `<button type="button" class="btn btn-primary" data-toggle="modal" data-target="">
                //                  Edit
                //            </button>
                //            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="">
                //                  Delete
                //            </button>
                //            `;
                //    }
                //}
            ]
        }
    );

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
        swal("Nice!", "Password Changed!", "success");
        /*alert('berhasil');
        window.location = "https://localhost:44320/Client";*/
    }).fail((error) => {
        swal("Nice!", "Cahnge Password Failed!", "error");
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