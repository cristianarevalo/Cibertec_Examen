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