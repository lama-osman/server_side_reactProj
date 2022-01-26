$(document).ready(function () {


    $("#formid").submit(function () {
        if ($("#Category").val() == "select") {
            postErrorCB();
        }
        else {
            item = {
                Name: $("#name").val(),
                Description: $("#description").val(),
                Image: $("#image1").val(),
                Price: $("#price").val(),
                Category: $("#Category").val()
            }


            let api = "../api/Item";
            ajaxCall("Post", api, JSON.stringify(item), postSuccessCB, postErrorCB)
            return false;
        }
        
    });
});

function postErrorCB(err) {
    if (err == null) { alert("Select Category") }
    else alert("try to add the item later");
}

function postSuccessCB() {
    alert("success");
}