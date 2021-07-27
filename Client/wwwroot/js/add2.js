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
                    "data": "status"
                },
                {
                    "data": "grade"
                }
            ]
        }
    );

    var table2 = $("#table2").DataTable(
        {
            'ajax': {
                url: "/add2/ShowDetailProject/",
                dataType: "json",
                dataSrc: ""
            },

            "columns": [
                {
                    "data": "projectName"
                },
                {
                    "data": "projectPlace"
                },
                {
                    "data": "projectClient"
                }
            ]
        }
    );

    //setInterval(function () {
    //    table.ajax.reload();
    //    table2.ajax.reload();
    //}, 30000)
});


let optionsVisitorsProfile = {
    series: [70, 30],
    labels: ['Male', 'Female'],
    colors: ['#435ebe', '#55c6e8'],
    chart: {
        type: 'donut',
        width: '100%',
        height: '350px'
    },
    legend: {
        position: 'bottom'
    },
    plotOptions: {
        pie: {
            donut: {
                size: '30%'
            }
        }
    }
};

var chartVisitorsProfile = new ApexCharts(document.getElementById('chart-visitors-profile'), optionsVisitorsProfile);
chartVisitorsProfile.render();