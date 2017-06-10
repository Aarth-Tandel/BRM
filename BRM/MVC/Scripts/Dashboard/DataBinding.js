/// <reference path="../angular.js" />

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
            if ($scope.Application)
                $http.post("/Dashboard/GetRelease/" + $scope.Application.ID, JSON.stringify({ ID: $scope.Application })).then(function (response) {
                    $scope.release = response.data;
                });
        }

        $scope.GetChange = function () {
            $http.get("/Dashboard/GetChanges").then(function (response) {
                $scope.change = response.data;
            });
        }

        $scope.GetEnvironment = function () {
            if ($scope.Release)
                $http.post("/Dashboard/GetEnvironment/" + $scope.Release.ID, JSON.stringify({ ID: $scope.Release })).then(function (response) {
                    $scope.environment = response.data;
                });
        }

        $scope.GetServer = function () {
            if ($scope.Environment)
                $http.post("/Dashboard/GetServer/" + $scope.Environment.ID, JSON.stringify({ ID: $scope.Environment })).then(function (response) {
                    $scope.server = response.data;
                });
        }


        $scope.SaveDetails = function () {
            var UserID = $('#HdnUserID').val();

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
            else
            {
                $('.tooltipped').tooltip({ delay: 50 });
                Materialize.toast('Please select all the menu fields', 4000)
            }
        }
    }]);
