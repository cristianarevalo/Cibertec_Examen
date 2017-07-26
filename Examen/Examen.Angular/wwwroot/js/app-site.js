(function () {
    'use strict'; //para que las variables sea declaradas

    angular.module('app', ['ui.router', 'LocalStorageModule', 'ui.bootstrap']);
})();
(function () {
    'use strict'; //Exijimos que valide las variables

    angular.module('app')
        .config(routeConfig); //configurando el modulo, setea la funcion routeConfig

    routeConfig.$inject = ['$stateProvider', '$urlRouterProvider'];
    
    function routeConfig($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("inicio", {
                url: "/inicio",
                templateUrl: 'app/inicio.html'
            })
            .state("corporacion", {
                url: "/corporacion",
                templateUrl: 'app/privado/corporacion/index.html'
            })
            .state("miembro", {
                url: "/miembro",
                templateUrl: 'app/privado/miembro/index.html'
            })
            .state("otherwise", {
                url: '*path',
                templateUrl: 'app/inicio.html'
            });
    }

})();
(function () {
    'use strict';

    angular.module('app').run();

})();
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