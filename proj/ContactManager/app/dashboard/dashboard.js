(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', 'apiService', 'lookupService', dashboard]);

    function dashboard(common, datacontext, apiService, lookupService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'FlexCorp Contact Management',
            description: 'Versatile management of your companies and contacts'
        };
        vm.messageCount = 0;
        vm.people = [];
        vm.companies = [];
        vm.title = 'Dashboard';

        activate();

        function activate() {
            var promises = [getMessageCount(), getPeople(), getCompanies()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function getMessageCount() {
            return datacontext.getMessageCount().then(function (data) {
                return vm.messageCount = data;
            });
        }

        function getPeople() {
            return datacontext.getPeople().then(function (data) {
                return vm.people = data;
            });
        }

        function getCompanies() {
            return apiService.getCompanies().then(function (data) {
                return vm.companies = data;
            });
        }
    }
})();