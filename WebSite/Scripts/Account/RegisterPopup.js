(function () {

    $(function () {
        var AccountManager = {};
        AccountManager.AjaxRegister = function () {
            var form = $("#form_register");
            $.ajax({
                url: "/Account/RegisterPopup",
                type: "POST",
                data: form.serialize(),
                success: function (data) {
                    alert(data.rez + " " + data.message);
                }
            });
        }
        var aMgr = AccountManager;
        $("#btnRegisterPopup").on("click", function () {
            aMgr.AjaxRegister();
        });
    });
})();