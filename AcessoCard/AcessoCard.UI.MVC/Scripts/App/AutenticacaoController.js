var Autenticacao = angular.module("login", []);

Autenticacao.controller("AutenticacaoController", function ($scope, $http) {

    $scope.logar = function (evento) { 
        var formularioValido = $scope.formularioLogin.$valid;
        var form = $('form').valid();
        
        if (form) {

            var btn = $(evento.currentTarget);
            btn.button('Carregando...');

            var email = $scope.User.email;
            var senha = $scope.User.senha;
            var token = email.concat(":", senha);

            $http({
                method: 'GET',
                url: 'http://localhost:4129/api/Login',
                headers: { 'Authorization': 'Basic '.concat(btoa(token)) }
            })
                .success(function (data) {
                    $scope.mensagem = data;

                })
                .error(function (data) {
                    $scope.mensagem = data.Message;
                });
            btn.button('reset');

        }

    };


});

