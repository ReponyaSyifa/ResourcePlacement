$.ajax({
    url: "https://localhost:44338/API/skill"
}).done((result) => {
    text = ``;
    $.each(result, function (key, value) {
        text += `<option value="${value.skillId}">${value.skillName}</option>`;
        //text += `<option>${value.customerUserId}`+ `</option>`;
        console.log(value.skillName);
    });
    console.log(text);
    $("#skills").html(text);
}).fail((err) => {
    console.log(err);
});