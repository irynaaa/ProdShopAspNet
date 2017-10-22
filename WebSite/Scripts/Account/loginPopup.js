(function () {

    $(function () {
        var AccountManager = {};
        AccountManager.AjaxLogin = function () {
            var form = $("#form_login");
            $.ajax({
                url: "/Account/LoginPopup",
                type: "POST",
                data: form.serialize(),
                success: function (data) {
                    alert(data.rez + " " + data.message);
                }
            });
        }
        var aMgr = AccountManager;
        $("#btnLoginPopup").on("click", function () {
            aMgr.AjaxLogin();
        });
    });
})();