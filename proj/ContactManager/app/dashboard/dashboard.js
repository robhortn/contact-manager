(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', 'apiService', 'lookupService', dashboard]);

    function dashboard(common, datacontext, apiService, lookupService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        vm.companyListing = [
            { id: 1, name: 'Naomi', address: '1600 Amphitheatre' },
            { id: 2, name: 'Igor', address: '123 Somewhere' },
            { id: 3, name: 'company 3', address: '123 Somewhere' },
            { id: 4, name: 'company 4', address: '123 Somewhere' },
            { id: 5, name: 'company 5', address: '123 Somewhere' },
            { id: 6, name: 'company 6', address: '123 Somewhere' },
            { id: 7, name: 'company 7', address: '123 Somewhere' },
            { id: 8, name: 'company 8', address: '123 Somewhere' },
            { id: 9, name: 'company 9', address: '123 Somewhere' },
            { id: 10, name: 'company 10', address: '123 Somewhere' },
            { id: 11, name: 'company 11', address: '123 Somewhere' },
            { id: 12, name: 'company 12', address: '123 Somewhere' }
        ];

        vm.naomi = { name: 'Naomi', address: '1600 Amphitheatre' };
        vm.igor = { name: 'Igor', address: '123 Somewhere' };

        vm.filtered = false;

        vm.titles = {
            main: 'Dashboard',
            mainsub: '',
            companyList: 'Company List' + (vm.filtered == true ? ' (Filtered)' : ' (All)')
        };

        vm.title = 'Dashboard';
        vm.companyCount = 0;
        vm.companies = [];

        vm.categories = [
            { id: 1, name: 'Super Amazing Awesome (local)' },
            { id: 2, name: 'Very Cool (local)' },
            { id: 3, name: 'Secret Lair (local)' }
        ];

        vm.category = '';

        activate();

        function activate() {
            var promises = [getCompanies(), getMessageCount(), getPeople()];
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
            }).then(function (data) {
                vm.companyCount = vm.companies.length;
            });
        }
    }
})();