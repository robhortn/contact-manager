(function () {
    'use strict';

    var serviceId = 'apiService';
    angular.module('app').factory(serviceId, ['$http', 'common', 'config', apiService]);

    function apiService($http, common, config) {

        var service = {
            getCompanies: getCompanies,
            saveCompany: saveCompany
        };

        return service;

        function getCompanies() {
            return $http.get("api/companies")
                .then(function (data) {
                        return data.data;
                    },
                    function () {
                        queryFailed();
                    }
                );
        }

        function saveCompany(obj) {
            return $http.post("api/company/companysave", obj)
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