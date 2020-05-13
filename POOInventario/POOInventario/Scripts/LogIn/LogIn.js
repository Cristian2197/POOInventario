$(document).ready(function () {
    $("#btnLogin").click(function () {
        var _url = '/Login/Login';
        $.ajax({
            type: "Get",
            url: _url,
            data: {},
            async: false,
            success: function (response) {
                $('#dvLogin').html(response);
            },
            error: function (response) {
                if (response.responseText != "") {
                    alert(response.responseText);
                }
            }
        });
    });
});
       