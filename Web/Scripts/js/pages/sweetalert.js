
$(document).ready(function() {
    $('#btn1').on('click',function(){
        swal("Here's your text message in the sweet alert!");
    });
    $('#btn2').on('click',function() {
        swal("Here's your text message in the sweet alert!");
    });
    $('#btn3').on('click',function(){
        swal("Good job!", "You clicked the button!", "success")
    });
    $('#btn4').on('click',function(){
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55  ",
            confirmButtonText: "Yes, delete it!",
            closeOnConfirm: false
        }, function () {
            swal("Deleted!", "Your imaginary file has been deleted.", "success");
        });
    });
    $('#btn5').on('click',function(){
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55  ",
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel plx!",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm) {
                swal("Deleted!", "Your imaginary file has been deleted.", "success");
            } else {
                swal("Cancelled", "Your imaginary file is safe :)", "error");
            }
        });
    });
    $('#btn6').on('click',function(){
        swal({   title: "Sweet!",   text: "Here's a custom image.",   imageUrl: "img/authors/avatar.jpg" });
    });

    $('#btn7').on('click',function(){
        swal({   title: "Sweet!",   text: "Here's a custom image.",   imageUrl: "img/authors/avatar1.jpg" });
    });
    $('#btn8').on('click',function(){
        swal({   title: "Auto close alert!",
            text: "I will close in 2 seconds.",
            timer: 2000,  showConfirmButton: false
        });
    });
    $('#HandleRequestBtn').on('click',function(){
        swal({
            title: "Add This Resource to this request",
            text: "are you sure",
            type: "info",
            showCancelButton: true,
            closeOnConfirm: false,
            showLoaderOnConfirm: true
        }, function () {
            setTimeout(function () {
                swal({ title:  "Add Resource finished!" }, function () { window.location.href = $("#page").val(); });
                var xk = $(".myliste").children().children()[0].value
                var p = new Object();
                p.id = xk;
                var resources = new Array(p);
                var a = new Object();
                a.id = $("#reqId").val();
                var sug  = {

                    request : a,
                    resources : resources
                };
                $.ajax({
                    type: "POST",
                    url: '/Mandate/addSuggestion',
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(sug),
                    success: function (data) {

                    },

                });
            }, 3000);
         
        });
     
    });

});

