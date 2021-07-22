$(document).ready(function () {
    var table = $("#example21").DataTable(
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

    setInterval(function () {
        table.ajax.reload();
    }, 30000)
});