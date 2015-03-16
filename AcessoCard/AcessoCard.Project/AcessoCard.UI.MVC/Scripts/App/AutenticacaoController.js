var Autenticacao = angular.module("login", []);

Autenticacao.controller("AutenticacaoController", function ($scope, $http) {
    $scope.inicializar = function () {
       localStorage.removeItem("user");
    };
    $scope.logar = function (evento) {
        var validar = $('form').valid();
        if (validar) {
            var btn = $(evento.currentTarget);
            $(btn).text('Carregando...');

            var email = $scope.User.email;
            var senha = $scope.User.senha;
            var token = email.concat(":", senha);

            $http({
                method: 'POST',
                url: 'http://localhost:4129/api/Login',
                headers: { 'Authorization': 'Basic '.concat(btoa(token)) }
            })
                .success(function (data) {
                    localStorage['user'] = email; 
                    location.href = data;
                   
                })
                .error(function (data) {
                    $scope.mensagem = data.Message;
                    $(btn).text('Enviar');
                });
             

        }

    };


});

