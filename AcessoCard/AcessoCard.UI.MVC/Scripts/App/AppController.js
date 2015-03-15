var Contato = angular.module("spaAngular", []);

Contato.controller('ContatoController', function ($scope, $http) {
    $scope.inicializar = function () {
        listar();
    };

    var listar = function () {
        $http.get("http://localhost:4129/api/listar").success(function (resposta) {
            $scope.listarContatos = resposta;
        });
    };

    $scope.Cadastrar = function () {
        var valid = $("form").valid();
        if (valid) {
            $http.post("http://localhost:4129/api/Cadastrar", $scope.Contato)
              .success(function (mensagem) {
                  listar();
                  alert(mensagem);
              })
              .error(function (mensagem) {
                  if (mensagem != null) {
                      alert(mensagem);
                  }
                  
              });  
        } 
    };

    $scope.Excluir = function (idTela) {
        var result = confirm("Deseja Excluir? ");
        if (result) {
            $http.delete("http://localhost:4129/api/Deletar", { params: { id: idTela } })
                .success(function (mensagem) {
                    listar();
                    alert(mensagem);
                })
                .error(function (mensagem) {
                    if (mensagem != null) {
                        alert(mensagem);
                    }
                });
        }

    };

    $scope.Selecionar = function (index) {
        $scope.Contato = $scope.listarContatos[index];
    };

    $scope.Atualizar = function () {
        var valid = $("form").valid();
        if (valid) {
            $http.put("http://localhost:4129/api/Atualizar", $scope.Contato)
             .success(function (mensagem) {
                 listar();
                 alert(mensagem);
                 $scope.Contato = {};
             })
             .error(function (mensagem) {
                 if (mensagem != null) {
                     alert(mensagem);
                 }
             });
        }
        
    };
});