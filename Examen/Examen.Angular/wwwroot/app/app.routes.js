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