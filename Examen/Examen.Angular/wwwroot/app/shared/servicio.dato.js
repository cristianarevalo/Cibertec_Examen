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