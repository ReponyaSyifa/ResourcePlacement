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
                    "data": "grade"
                },
                {
                    "data": "status"
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
                height: '350px'
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
                height: '350px'
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