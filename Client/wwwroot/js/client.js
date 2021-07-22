$(document).ready(function () {
    var table = $("#table1").DataTable(
        {
        'ajax': {
            url: "/participant/getall/",
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
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" data-toggle="modal" data-target="">
                                  Edit
                            </button>
                            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="">
                                  Delete
                            </button>
                            `;
                }
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
                },
                {
                    "data": null,
                    "render": function (data, type, row) {
                        return `<button type="button" class="btn btn-primary" data-toggle="modal" data-target="">
                                  Edit
                            </button>
                            <button type="button" class="btn btn-danger" data-toggle="modal" data-target="">
                                  Delete
                            </button>
                            `;
                    }
                }
            ]
        }
    );

    setInterval(function () {
        table.ajax.reload();
        table2.ajax.reload();
    }, 30000)
});

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
    if (obj.ProjectName != '' && obj.ProjectDesc != '' && obj.CustomerUsersId != '' && obj.ListSkill != '') {
        PostProject(obj);
    } else {
        alert("Semua Harus Di Isi!!");
    }
};