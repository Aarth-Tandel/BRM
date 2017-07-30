﻿/// <reference path="../angular.js" />
$(document).ready(function () {
    $('select').material_select();
    $.ajax({
        url: '/Dashboard/RefreshGrid',
        type: 'GET',
        success: function (result) {
            isSuccess = 1;
        }
    }).done(function (data) {
        if (isSuccess) {
            $('#divProduct').replaceWith(data);
        }
    });

});

var myApp = angular.module('myApp', ['ngRoute']);

myApp.controller("myCtrl", ['$scope', '$http', '$route',
    function ($scope, $http, $route) {

        $http.get("/Dashboard/GetApplication").then(function (responses) {
            $scope.names = responses.data;
        });

        $scope.GetRelease = function () {
            $("#ddlRelease").empty();
            if ($scope.Application) {
                $http.post("/Dashboard/GetRelease/" + $scope.Application.ID, JSON.stringify({ ID: $scope.Application })).then(function (response) {
                    $scope.release = response.data;
                });
            }
        }

        $scope.GetChange = function () {
            $("#ddlChanges").empty();
            $http.get("/Dashboard/GetChanges").then(function (response) {
                $scope.change = response.data;
            });
        }

        $scope.GetEnvironment = function () {
            $("#ddlEnvironment").empty();
            if ($scope.Release)
                $http.post("/Dashboard/GetEnvironment/" + $scope.Release.ID, JSON.stringify({ ID: $scope.Release })).then(function (response) {
                    $scope.environment = response.data;
                });
        }

        $scope.GetServer = function () {
            $("#ddlServer").empty();
            if ($scope.Environment)
                $http.post("/Dashboard/GetServer/" + $scope.Environment.ID, JSON.stringify({ ID: $scope.Environment })).then(function (response) {
                    $scope.server = response.data;
                });
        }

        $scope.SaveDetails = function () {
            var UserID = $('#HdnUserID').val();
            var appText = $("#ddlapplication").val();
            var relText = $("#ddlRelease").val();
            var chagText = $("#ddlChanges").val();
            var envText = $("#ddlEnvironment").val();
            var sevText = $("#ddlServer").val();
            debugger;
            var ID = $('#logTable tr').length;
            if ($scope.Application && $scope.Release && $scope.Change && $scope.Environment && $scope.Server)
                $http({
                    method: 'POST',
                    url: '/Dashboard/SaveDetails/',
                    data: { Application_ID: $scope.Application.ID, Release_ID: $scope.Release.ID, Change_ID: $scope.Change.ID, Environment_ID: $scope.Environment.ID, Server_ID: $scope.Server.ID, User_ID: UserID },
                }).then(function () {
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
                            Materialize.toast('Data Saved!', 4000)
                        }
                    });
                });
            else if (UserID && appText && relText && chagText && envText && sevText) {
                $http({
                    method: 'POST',
                    url: '/Dashboard/SaveDetails/',
                    data: { Application_ID: 1, Release_ID: relText, Change_ID: chagText, Environment_ID: envText, Server_ID: sevText, User_ID: UserID },
                }).then(function () {
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
                            Materialize.toast('Data Saved!', 4000)
                        }
                    });
                });
            }
            else {
                $('.tooltipped').tooltip({ delay: 50 });
                Materialize.toast('Please select all the menu fields', 4000)
            }
            $.ajax({
                url: "http://localhost:8080/job/BRM%20Tool/buildWithParameters?token=aarthbrm&JobID=" + ID + "&Chg=" + chagText + "&Env=" + envText,
                type: 'GET',
                success: function (result) {
                    alert(result);
                }
            }).done(function (data) {
                alert(data);
            });
        }
    }]);
