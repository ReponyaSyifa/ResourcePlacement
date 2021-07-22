// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("tezz zatu dua");

//fungsi post project baru
function PostProject(item) {
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44338/API/Project/AddProject",
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
};


//get list company
$.ajax({
    url: "https://localhost:44338/API/CustomerUser"
}).done((result) => {
    text = `<option selected >View Company Name</option>`;
    $.each(result, function (key, value) {
        text += `<option value="${value.customerUserId}` + `">` + `${value.companyName}</option>`;
        //text += `<option>${value.customerUserId}`+ `</option>`;
    });
    $("#custName").html(text)
}).fail((err) => {
    console.log(err);
});

//get list skills
/*$.ajax({
    url: "https://localhost:44338/API/Skill"
}).done((result) => {
    $.each(result, function (key, val) {
        text += `<option value="${val.skillId}">` + `${val.skillName}</option>`;
    });
    $("#skills").html(text)
}).fail((err) => {
    console.log(err);
});*/


//tambah projek baru
function AddProject() {
    var obj = new Object();

    var skills = [];
    for (var option of document.getElementById('skills').options) {
        if (option.selected) {
            var skillId = parseInt(option.value);
            skills.push(skillId);
        }
    }

    obj.ProjectName = $('#ProjectName').val();
    obj.ProjectDesc = $('#ProjectDesc').val();
    obj.CustomerUsersId = $('#custName').val();
    obj.ListSkill = skills;    

    //validasi
    if (obj.ProjectName != '' && obj.ProjectDesc != '' && obj.CustomerUsersId != '' && obj.ListSkill != '')
    {
        PostProject(obj);
    } else {
        alert("Semua Harus Di Isi!!");
    }
};

//ganti password
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

/*$(document).ready(function () {
    $('#submitNew').click(function () {
        var obj = {};
        obj.ProjectName = $('#ProjectName').val();
        obj.ProjectDesc = $('#ProjectDesc').val();
        obj.CustomerUsersId = parseInt($('#custName').val());

        var skills = [];
        for (var option of document.getElementById('skills').options) {
            if (option.selected) {
                var skillId = parseInt(option.value);
                skills.push(skillId);
            }
        }
        obj.ListSkill = parseInt(skills);

        $.ajax({
            url: "https://localhost:44338/API/Project/AddProject",
            type: "POST",
            data: JSON.stringify(obj),
            contentType: "application/json",
            success: function () {
                Swal.fire({
                    icon: 'success',
                    title: 'New Register Submitted!',
                    showConfirmButton: false,
                    timer: 1500
                })
            },
            error: function (err) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oh Snap!',
                    text: 'Something went wrong!',
                    footer: "Segera Hubungi Helpdesk, hehe"
                })
            }
        });

    })
});*/