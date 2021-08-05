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
                    "data": "grade"
                },
                {
                    "data": "status"
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
});

$(document).ready(function () {
    var table2 = $("#table2").DataTable(
        {
            'ajax': {
                url: "/add2/ShowDetailProject/",
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
                    "data": "projectPlace"
                },
                {
                    "data": "projectClient"
                },
                {
                    "data": null,
                    "render": function (data, type, row) { // wajib pakai bootstrap 5 untuk ini template
                        return `<button type="button" class="btn btn-primary modalClass" data-id="${row["projectId"]}" data-bs-toggle="modal" data-bs-target="#cobaModal" data-bs-toggle="tooltip" data-bs-placement="top" title="Detail">
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

$(document).on("click", ".modalClass", function () { // untuk ambil data-id wajib menggunakan class yang ada di button
    
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

function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}


LabelsGrade();
function LabelsGrade() {
    var gradeA = 0;
    var gradeB = 0;

    $.ajax({
        url: "/participant/getall/",
        contentType: "application/json"
    }).done((result) => {
        var gradeA = 0;
        var gradeB = 0;
        $.each(result, function (key, val) {
            if (val.grade == "A") {
                gradeA++;
                
            } else {
                gradeB++;
                
            }
        })
        /*console.log(gradeA);
       console.log(gradeB);*/
        var optionsGrading = {
            series: [gradeA, gradeB],
            labels: ['Grade A', 'Grade B'],
            chart: {
                type: 'donut',
                 width: '100%',
                height: '350px',
                toolbar: {
                    show: true,
                    offsetX: 0,
                    offsetY: 0,
                    tools: {
                        download: true,
                        selection: true,
                        zoom: true,
                        zoomin: true,
                        zoomout: true,
                        pan: true,
                        reset: true | '<img src="/static/icons/reset.png" width="20">',
                        customIcons: []
                    },
                    export: {
                        csv: {
                            filename: 'Participant Grade Chart',
                            columnDelimiter: ',',
                            headerCategory: 'category',
                            headerValue: 'value',
                            dateFormatter(timestamp) {
                                return new Date(timestamp).toDateString()
                            }
                        },
                        svg: {
                            filename: 'Participant Grade Chart',
                        },
                        png: {
                            filename: 'Participant Grade Chart',
                        }
                    },
                    autoSelected: 'zoom'
                }
            },
            colors: ['#2b4070', '#a1d9f5'],
            legend: {
                position: 'left'
            },
            plotOptions: {
                pie: {
                    donut: {
                        size: '30%'
                    }
                }
            }
        };
        var chartGrading = new ApexCharts(document.getElementById('grading'), optionsGrading);
        chartGrading.render();
    })    
}


LabelsStatus();
function LabelsStatus() {
    var Idle = 0;
    var Project = 0;

    $.ajax({
        url: "/participant/getall/",
        contentType: "application/json"
    }).done((result) => {
        var Idle = 0;
        var Project = 0;
        $.each(result, function (key, val) {
            if (val.status == "Idle") {
                Idle++;

            } else {
                Project++;

            }
        })
        /*console.log(gradeA);
       console.log(gradeB);*/
        var optionsStatus = {
            series: [Idle, Project],
            labels: ['Idle', 'On Project'],
            chart: {
                type: 'pie',
                width: '100%',
                height: '350px',
                toolbar: {
                    show: true,
                    offsetX: 0,
                    offsetY: 0,
                    tools: {
                        download: true,
                        selection: true,
                        zoom: true,
                        zoomin: true,
                        zoomout: true,
                        pan: true,
                        reset: true | '<img src="/static/icons/reset.png" width="20">',
                        customIcons: []
                    },
                    export: {
                        csv: {
                            filename: 'Pariticant Status Chart',
                            columnDelimiter: ',',
                            headerCategory: 'category',
                            headerValue: 'value',
                            dateFormatter(timestamp) {
                                return new Date(timestamp).toDateString()
                            }
                        },
                        svg: {
                            filename: 'Pariticant Status Chart',
                        },
                        png: {
                            filename: 'Pariticant Status Chart',
                        }
                    },
                    autoSelected: 'zoom'
                }
            },
            colors: ['#2b4070', '#a1d9f5'],
            legend: {
                position: 'left'
            },
            plotOptions: {
                pie: {
                    donut: {
                        size: '30%'
                    }
                }
            }
        };
        var chartGrading = new ApexCharts(document.getElementById('placement'), optionsStatus);
        chartGrading.render();
    })
}

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