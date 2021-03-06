﻿

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

    $(document).on("click", "#BtnRedeploy", function (e) {
        var tr = $(this).parents('tr:first');
        var applText = tr.find("span#Application").text().trim();
        var relText = tr.find("span#Release").text().trim();
        var chagText = tr.find("span#Changes").text().trim();
        var envText = tr.find("span#Environment").text().trim();
        var sevText = tr.find("span#Server").text().trim();
        
        
        $('#ddlapplication option:contains(' + applText + ')').prop('selected', true);
        isSuccess = 0;
        if ($("#ddlRelease option[value=" + relText + "]").length == 0) {
            $.ajax({
                url: '/Dashboard/GetRelease/',
                type: 'POST',
                data: { ID: 0, Text: relText },
                success: function (result) {
                    isSuccess = 1;
                }
            }).done(function (data) {
                if (isSuccess) {
                    $("#ddlRelease").empty();
                    //$("#ddlRelease").html("<option value=>" + "--Select Release--" + "</option>");
                    for (var i = 0; i < data.length; i++) {
                        $("#ddlRelease").append("<option value=" + data[i].ID + " label=" + data[i].release + ">" +
                            data[i].release + "</option>");
                    }
                    $('#ddlRelease option:contains(' + relText + ')').prop('selected', true);
                }
            });
        }

        if ($("#ddlChanges option[value=" + chagText + "]").length == 0) {
            $.get("/Dashboard/GetChanges", function (data) {
                $("#ddlChanges").empty();
                //$("#ddlChanges").html("<option value=>" + "--Select Change--" + "</option>");
                for (var i = 0; i < data.length; i++) {
                    $("#ddlChanges").append("<option value=" + data[i].ID + " label=" + data[i].changes + ">" +
                        data[i].changes + "</option>");
                }
                $('#ddlChanges option:contains(' + chagText + ')').prop('selected', true);
            });
        }

        if ($("#ddlEnvironment option[value=" + envText + "]").length == 0) {
            isSuccess = 0;
            $.ajax({
                url: '/Dashboard/GetEnvironment/',
                type: 'POST',
                data: { ID: 0, Text: envText },
                success: function (result) {
                    isSuccess = 1;
                }
            }).done(function (data) {
                if (isSuccess) {
                    $("#ddlEnvironment").empty();
                    //$("#ddlEnvironment").html("<option value=>" + "--Select Environment--" + "</option>");
                    for (var i = 0; i < data.length; i++) {
                        $("#ddlEnvironment").append("<option value=" + data[i].ID + " label=" + data[i].Environment + ">" +
                            data[i].Environment + "</option>");
                    }
                    $('#ddlEnvironment option:contains(' + envText + ')').prop('selected', true);
                }
            });
        }
        if ($("#ddlServer option[value=" + sevText + "]").length == 0) {
            isSuccess = 0;
            $.ajax({
                url: '/Dashboard/GetServer/',
                type: 'POST',
                data: { ID: 0, Text: sevText },
                success: function (result) {
                    isSuccess = 1;
                }
            }).done(function (data) {
                if (isSuccess) {
                    $("#ddlServer").empty();
                    //$("#ddlServer").append("<option value=>" + "--Select Environment--" + "</option>");
                    for (var i = 0; i < data.length; i++) {
                        $("#ddlServer").append("<option value=" + data[i].ID + " label=" + data[i].server + ">" +
                            data[i].server + "</option>");
                    }
                    $('#ddlServer option:contains(' + sevText + ')').prop('selected', true);
                }
            });
        }
    });
});

$(document).on("click", "#Status", function (e) {
    var tr = $(this).parents('tr:first');
    var logs = tr.find("#URL").val();
    window.open(logs, '_blank');
});
