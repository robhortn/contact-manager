(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', 'apiService', 'lookupService', dashboard]);

    function dashboard(common, datacontext, apiService, lookupService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        vm.filtered = false;

        vm.titles = {
            main: 'Dashboard',
            mainsub: '',
            companyList: 'Company List' + (vm.filtered == true ? ' (Filtered)' : ' (All)')
        };

        vm.title = 'Dashboard';
        vm.companyCount = 0;
        vm.companies = [];

        vm.companyModel = {
            Id: 0,
            CompanyName: '',
            Address1: '',
            Address2: '',
            City: '',
            StateCode: '',
            StatedId: '',
            PostalCode: '',
            CategoryId: 0,
            CategoryName: '',
            CompanyPhone: '',
            CompanyFax: '',
            IsActive: 0
    };

        vm.categories = [
            { id: 1, name: 'Super Amazing Awesome (local)' },
            { id: 2, name: 'Very Cool (local)' },
            { id: 3, name: 'Secret Lair (local)' }
        ];

        vm.category = '';

        // Functions
        vm.selectCompany = selectCompany;

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

        function setCurrentCompany(obj) {
            if (obj != null) {
                vm.companyModel.Id = obj.Id;
                vm.companyModel.CompanyName = obj.CompanyName;
            }
        }

        function selectCompany(id) {
            
            var result = vm.companies.find(x => x.Id === id);
            if (result !== undefined) {
                setCurrentCompany(result);
            } else {
                console.log('selectCompany() in dashboard.js cannot find id: ' + id);
            }
        }
    }
})();