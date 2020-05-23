$(document).ready(function () {
    $("#btnLoginCli").click(function () {
        var _url = '/Login/LoginCli';
        $.ajax({
            type: "Get",
            url: _url,
            data: {},
            async: false,
            success: function (response) {
                $('#dvLoginCli').html(response);
            },
            error: function (response) {
                if (response.responseText != "") {
                    alert(response.responseText);
                }
            }
        });
    });
});