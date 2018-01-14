(function () {
    'use strict';

    var serviceId = 'apiService';
    angular.module('app').factory(serviceId, ['$http', 'common', 'config', apiService]);

    function apiService($http, common, config) {

        var service = {
            getCompanies: getCompanies
        };

        return service;

        function getCompanies() {
            return $http.get("api/companies")
                .then(function (data) {
                        return data.data;
                    },
                    function () {
                        _queryFailed();
                    }
                );
        }

        //#region Internal Methods        
        function queryFailed(error) {
            var msg = config.appErrorPrefix + 'Error retreiving data.';
            //logError(msg, error);
            throw error;
        }
        //#endregion

    }

})();