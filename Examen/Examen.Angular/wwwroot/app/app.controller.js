(function () {
    'use strict';

    angular.module('app')
        .controller('aplicacionController', aplicacionController);

    aplicacionController.$inject = ['$scope', 'configuracionServicio', 'autenticacionServicio', 'localStorageService']

    function aplicacionController($scope, configuracionServicio, autenticacionServicio, localStorageService) {

        var vm = this; //vm: view model
        vm.validate = validate;
        vm.logout = logout;

        $scope.init = function (url) {
            configuracionServicio.setApiUrl(url);
        }

        function validate() {
            return configuracionServicio.getLogin();
        }

        function logout() {
            autenticacionServicio.logout();
        }

    }
})();