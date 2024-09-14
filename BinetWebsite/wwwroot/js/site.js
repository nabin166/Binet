// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    console.log("Hiii")
    $('#loadmart').click(function () {
        $.ajax({
            url: '/Ongoingproject/nepalMart',
            type: 'GET',
            success: function (data) {
                $('#partialContainer').html(data);
            },
            error: function (xhr, status, error) {
                console.error("Error loading partial view:", error);
            }
        });
    });

    $('#loadfenegosida').click(function () {
        $.ajax({
            url: '/Ongoingproject/fenegosida',
            type: 'GET',
            success: function (data) {
                $('#partialContainerfen').html(data);
            },
            error: function (xhr, status, error) {
                console.error("Error loading partial view:", error);
            }
        });
    });

    $('#loadstock').click(function () {
        $.ajax({
            url: '/Ongoingproject/stockManagement',
            type: 'GET',
            success: function (data) {
                $('#partialContainerstock').html(data);
            },
            error: function (xhr, status, error) {
                console.error("Error loading partial view:", error);
            }
        });
    });
    $('#loadaccounting').click(function () {
        $.ajax({
            url: '/Ongoingproject/accountingSoftware',
            type: 'GET',
            success: function (data) {
                $('#partialContaineraccount').html(data);
            },
            error: function (xhr, status, error) {
                console.error("Error loading partial view:", error);
            }
        });
    });
    $('#loadAnynomous').click(function () {
        $.ajax({
            url: '/Ongoingproject/socialNetwork',
            type: 'GET',
            success: function (data) {
                $('#partialContainersocialnetwork').html(data);
            },
            error: function (xhr, status, error) {
                console.error("Error loading partial view:", error);
            }
        });
    });
    $('#loadnumerology').click(function () {
        $.ajax({
            url: '/Ongoingproject/numerologyApp',
            type: 'GET',
            success: function (data) {
                $('#partialContainernumerology').html(data);
            },
            error: function (xhr, status, error) {
                console.error("Error loading partial view:", error);
            }
        });
    });

});
