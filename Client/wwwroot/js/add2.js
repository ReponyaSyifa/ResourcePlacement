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

function LabelsPlacement() {
    let labels = [];
    $.ajax({
        async: true,
        type: "GET",
        url: "https://localhost:44338/api/participant/GetListParticipant/",
        contentType: "application/json",
        success: "gg",
            /*function (result) {*/
        //    //for (var i = 0; i < result.length; i++) {
        //    //    if (labels == null) {
        //    //        labels[i] = result.companyName;
        //    //        var j = 1;
        //    //    }
        //    //    else {
        //    //        for (var y = 0; y < labels.length; y++) {
        //    //            if (labels[y] != result.companyName) {
        //    //                labels[j] = result.companyName;
        //    //                j++;
        //    //            }
        //    //        }
        //    //    };
                
        //    //}

        //    $.each(result, function (key, val) {
        //        if (labels == null) {
        //            labels[0] = val.companyName;
        //            var j = 1;
        //        }
        //        else {
        //            for (var y = 0; y < labels.length; y++) {
        //                if (labels[y] != val.companyName) {
        //                    labels[j] = val.companyName;
        //                    j++;
        //                }
        //            }
        //        };
        //        //if (val.name == name) {
        //        //    ++count;
        //        //}
        //    });
        //},
        async: false
    });
    return labels;
}

var labes = LabelsPlacement();
console.log(LabelsPlacement());
//labes[0] = "Male";
//labes[1] = "Female";

let optionsVisitorsProfile = {
    series: [70, 30],
    labels: ['Grade A', 'Grade B'],
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

var chartGrading = new ApexCharts(document.getElementById('grading'), optionsVisitorsProfile);
chartGrading.render();

let optionsVisitorsProfileB = {
    series: [60, 25, 15],
    labels: ['PT. ABC', 'PT. DEF', 'PT. GHI'],
    colors: ['#435ebe', '#55c6e8', '#9ae6fc'],
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

var chartPlacement = new ApexCharts(document.getElementById('placement'), optionsVisitorsProfileB);
chartPlacement.render();
