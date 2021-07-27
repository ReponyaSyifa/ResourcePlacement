function Insert(item) {
    //isi dari object kalian buat sesuai dengan bentuk object yang akan di post
    $.ajax({
        url: "https://localhost:44338/api/employee/RegisterRepoWithAdmin",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(item)
    }).done((result) => {
        Swal.fire({
            icon: 'success',
            title: 'New Registration Succeed!',
            showConfirmButton: true
            //,timer: 1500
        }),
        $('#largeModal').modal('hide');
        //alert('berhasil'),
        //window.location = "https://localhost:44320/" //https://localhost:44320/Login/Index
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Registrasi Failed, Something Went Wrong!',
            showConfirmButton: true
            //,timer: 1800
        }),
        $('#largeModal').modal('hide');
        /*alert('gagal'),*/
        //window.location = "https://localhost:44320/" /*https://localhost:44320/Login/Index*/
    });
};

function Testsd() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.NIK = $("#firstName").val();
    alert(obj.NIK);
}

function ValidationEmployee() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.NIK = $("#nik").val();
    obj.FirstName = $("#firstName").val();
    obj.LastName = $("#lastName").val();
    obj.Email = $("#emailem").val();
    obj.Password = $("#password").val();

    console.log(obj.NIK);

    // Regular Expression For Email
    emailReg = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    passReg = /^[0-9a-zA-Z]{8,}$/;

    if (obj.FirstName != '' && obj.LastName != '' && obj.NIK != ''
        && obj.Email != '' && obj.Password != '' ) {
        Insert(obj);
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Oops...',
            text: 'Semua Harus Di Isi!!',
            showConfirmButton: false,
            timer: 1800
        })
        //alert("Semua Harus Di Isi!!");
    }
};

function ValidationClient() {
    var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
    //ini ngambil value dari tiap inputan di form nya
    obj.PicName = $("#fNameClient").val() + " " + $("#lNameClient").val();
    obj.CompanyName = $("#CName").val();
    obj.Email = $("#email").val();
    obj.Password = $("#pwd").val();

    //console.log(obj.NIK);

    // Regular Expression For Email
    emailReg = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    passReg = /^[0-9a-zA-Z]{8,}$/;

    if (obj.PicName != '' && obj.CompanyName != ''
        && obj.Email != '' && obj.Password != '') {
        Insert(obj);
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Oops...',
            text: 'Semua Harus Di Isi!!',
            showConfirmButton: false,
            timer: 1800
        })
        //alert("Semua Harus Di Isi!!");
    }
}