$(function () {
    var user = localStorage['user'];
    if (user == undefined) {
        location.href = "/users/Login";
    }
})