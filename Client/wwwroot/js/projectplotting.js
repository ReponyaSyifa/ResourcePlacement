$(document).ready(function () {
    var table = $("#table1").DataTable(
        {
            'ajax': {
                url: "https://localhost:44338/api/participant/GetListParticipantAdd2",
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
                    "data": "status"
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

    //setInterval(function () {
    //    table.ajax.reload();
    //    table2.ajax.reload();
    //}, 30000)
});

$(document).on("click", ".modalClass", function () { // untuk ambil data-id wajib menggunakan class yang ada di button
    var nik = $(this).data('id');
    console.log(nik);
    $.ajax({
        url: "/add2/GetParticipantId/" + nik
    }).done((result) => {
        //text = `<option selected >Project Name</option>`;
        //$.each(result, function (key, value) {
        //    text += `<option value="${value.projectId}` + `">` + `${value.projectName}</option>`;
        //    //text += `<option>${value.customerUserId}`+ `</option>`;
        //});
        //$("#project").html(text)
        console.log("berhasil");
    }).fail((error) => {
        console.log(error);
    });
});

$.ajax({
    url: "https://localhost:44338/API/project"
}).done((result) => {
    text = `<option selected >Project Name</option>`;
    $.each(result, function (key, value) {
        text += `<option value="${value.projectId}` + `">` + `${value.projectName}</option>`;
        //text += `<option>${value.customerUserId}`+ `</option>`;
    });
    $("#project").html(text)
}).fail((err) => {
    console.log(err);
});

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