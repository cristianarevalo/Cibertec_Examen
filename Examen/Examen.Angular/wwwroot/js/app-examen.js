(function () {
    angular
        .module('app')
        .factory('autenticacionServicio', autenticacionServicio);

    autenticacionServicio.$inject = ['$http', '$state', 'localStorageService', 'configuracionServicio','$q'];

    function autenticacionServicio($http, $state, localStorageService, configuracionServicio, $q)
    {
        var servicio = {};
        servicio.login = login;
        servicio.logout = logout;

        return servicio;

        function login(usuario) {
            var defer = $q.defer();
            var url = configuracionServicio.getApiUrl() + '/Token';
            var data = "username=" + usuario.userName + "&password=" + usuario.password;

            $http.post(url,
                data,
                {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .then(function (result) {
                    $http.defaults.headers.common.Authorization = 'Bearer ' + result.data.access_token;

                    localStorageService.set('userToken',
                        {
                            token: result.data.access_token,
                            userName: usuario.userName
                        });
                    configuracionServicio.setLogin(true);
                    $state.go('inicio');
                    defer.reject(true);
                },
                function error() {
                    defer.reject(false);
                });

            return defer.promise;
        }

        function logout() {
            $http.defaults.headers.common.Authorization = '';
            localStorageService.remove('userToken');
            configuracionServicio.setLogin(false);
        }
    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('configuracionServicio', configuracionServicio);

    function configuracionServicio() {
        var servicio = {};
        var apiUrl = undefined;
        var isLogged = false;
        servicio.setLogin = setLogin;
        servicio.getLogin = getLogin;
        servicio.setApiUrl = setApiUrl;
        servicio.getApiUrl = getApiUrl;

        return servicio;

        function setLogin(state) {
            isLogged = state;
        }

        function getLogin() {
            return isLogged;
        }

        function getApiUrl() {
            return apiUrl;
        }

        function setApiUrl(url) {
            apiUrl = url;
        }
    }
})();
(function () {
    angular
        .module('app')
        .factory('servicioDatos', servicioDatos);

    servicioDatos.$inject = ['$http'];

    function servicioDatos($http) {
        var servicio = {};
        servicio.getData = getData;
        servicio.postData = postData;
        servicio.putData = putData;
        servicio.deleteData = deleteData;

        return servicio;

        function getData(url) {
            return $http.get(url);
        }

        function postData(url, data) {
            return $http.post(url, data);
        }

        function putData(url, data) {
            return $http.put(url, data);
        }

        function deleteData(url) {
            return $http.delete(url);
        }

    }
})();