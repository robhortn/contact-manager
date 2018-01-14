(function () {
    'use strict';

    var serviceId = 'lookupService';
    angular.module('app').factory(serviceId, ['$http', 'common', 'config', lookupService]);

    // Functions to hit lookup tables as in the case of state codes or other static lookup data.
    function lookupService($http, common, config) {

        var service = {
            getCategories: getCategories,
            getStateProvinces: getStateProvinces
        };

        return service;

        function getCategories() {
            return $http.get("api/lookup/getCategories")
                .then(function (data) {
                    return data.data;
                },
                function (data) {
                    queryFailed(data);
                }
                );
        }

        function getStateProvinces() {
            return $http.get("api/lookup/getStateProvinces")
                .then(function (data) {
                    return data.data;
                },
                function (data) {
                    queryFailed(data);
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