var User = angular.module("recuperarSenha", []);

User.controller("UserController", function ($scope, $http) {
    $scope.recuperarSenha = function (evento) {

        var validar = $('form').valid();
        if (validar) {
            var btn = $(evento.currentTarget);
            $(btn).text('Carregando...');

            var userEmail = $scope.User.email;
            $http.post('http://localhost:4129/api/recuperar?email=' + userEmail)
                .success(function (data) {
                    $(btn).text('Enviar');
                    $scope.mensagem = "Sua Senha é: " + data;

                })
                .error(function (data) {
                    $(btn).text('Enviar');
                    $scope.mensagem = data.Message;
                });
            //$(btn).text('Enviar');

        }

    };
    $scope.alterarSenhaInit = function () {
        var user = localStorage["user"];
        if (user == undefined) {
            location.href = "/users/Login";
        }
    };

    $scope.alterarSenha = function (evento) {
        var senha = $("#Senha").val();
        var confirmar = $("#ConfirmarSenha").val();
        if (senha != confirmar) {
            $scope.mensagem = "Repita a Senha corretamente";
            return;
        }
        var validar = $('form').valid();
        if (validar) {
            
            var btn = $(evento.currentTarget);
            $(btn).text('Carregando...');
            $scope.User.email = localStorage['user'];
            var params =
                "email=" + $scope.User.email +
                "&novaSenha=" + $scope.User.senha +
                "&senhaAntiga=" + $scope.Senha.antiga;
            var url = "http://localhost:4129/api/alterarSenha?" + params;
            $http.post(url)
                .success(function (data) {
                    $scope.mensagem = data;
                    $(btn).text('Enviar');

                })
                .error(function (data) {
                    $scope.mensagem = data.Message;
                    $(btn).text('Enviar');

                }); 

        }
        $scope.mensagem = "Todos os campos são obrigatorios!";

    };
});
