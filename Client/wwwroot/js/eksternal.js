// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("tezz zatu dua");

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
        /*}).done((result) => {
            alert('berhasil'),
                window.location = "https://localhost:44320/eksternal/dashboard"
        }).fail((error) => {
            alert('gagal')
        });*/
    });
};

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

    var custName = "";
    for (var option of document.getElementById('custName').options) {
        if (option.selected) {
            custName = option.value;
        }
    }

    obj.ProjectName = $('#ProjectName').val();
    obj.ProjectDesc = $('#ProjectDesc').val();
    obj.CustomerUsersId = custName;
    obj.ListSkill = skills;

    //validasi
    if (obj.ProjectName != '' && obj.ProjectDesc != '' && obj.CustomerUsersId != '' && obj.ListSkill != '')
    {
        PostProject(obj);
    } else {
        alert("Semua Harus Di Isi!!");
    }
};

