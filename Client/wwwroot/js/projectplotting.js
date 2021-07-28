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