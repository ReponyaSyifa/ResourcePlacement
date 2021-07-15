$.ajax({
    url: "https://localhost:44338/api/participant",
    dataSrc: ""
}).done((result) => {
    console.log(result);
}).fail((error) => {
    console.log(error);
});