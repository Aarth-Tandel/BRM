$(document).ready(function () {
    $(document).on("click", "#BtnDelete", function (e) {
        var tr = $(this).parents('tr:first');
        var ID = tr.find("#ID").val();
        var data = { "id": ID };
        var isSuccess = false;

        $.ajax({
            url: '/Dashboard/DeleteRecord/',
            type: 'POST',
            data: { 'ID': data },
            success: function (result) {
                isSuccess = result;
            }
        }).done(function () {
            if (isSuccess) {
                $.ajax({
                    url: '/Dashboard/RefreshGrid',
                    type: 'GET',
                    success: function (result) {
                        isSuccess = 1;
                    }
                }).done(function (data) {
                    if (isSuccess) {
                        $('#LogGrid').replaceWith(data);
                        $('.tooltipped').tooltip({ delay: 50 });
                        Materialize.toast('Data Deleted!', 4000)
                    }
                });
            }
        });
    });

    $(document).on("click", "#BtnUpdate", function (e) {
        debugger;
        var tr = $(this).parents('tr:first');
        var applText = tr.find("span#Application").text().trim();
        var relText = tr.find("span#Release").text().trim();
        var chagText = tr.find("span#Changes").text().trim();
        var envText = tr.find("span#Environment").text().trim();
        var sevText = tr.find("span#Server").text().trim();

        $('#ddlapplication option:contains(' + applText + ')').prop('selected', true);
        $('#ddlRelease option:contains(' + relText + ')').prop('selected', true);
        $('#ddlChanges option:contains(' + chagText + ')').prop('selected', true);
        $('#ddlEnvironment option:contains(' + envText + ')').prop('selected', true);
        $('#ddlServer option:contains(' + sevText + ')').prop('selected', true);
    });
});