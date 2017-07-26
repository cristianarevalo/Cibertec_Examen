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