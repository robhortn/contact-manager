(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', 'apiService', 'lookupService', dashboard]);

    function dashboard(common, datacontext, apiService, lookupService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        // Value tracking 
        vm.companyCount = 0;
        vm.filtered = false;
        vm.filterValue = 'Blue';
        vm.category = '';
        vm.stateId = '';

        // Messages and titles
        vm.titles = {
            main: 'Dashboard',
            mainsub: '',
            companyList: 'Company List' + (vm.filtered === true ? ' (Filtered)' : ' (All)')
        };

        // Lists
        vm.companies = [];
        vm.states = [];
        vm.categories = [];

        // Models
        vm.companyModel = {};

        // Functions
        vm.selectCompany = selectCompany;
        vm.save = save;

        activate();

        function activate() {
            var promises = [loadLookupStateProvinces(), loadLookupCategories(), getCompanies()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function loadLookupCategories() {
            return lookupService.getCategories().then(function (data) {
                vm.categories = data;
            });
        }

        function loadLookupStateProvinces() {
            return lookupService.getStateProvinces().then(function (data) {
                vm.states = data;
            });
        }

        function getCompanies() {
            return apiService.getCompanies().then(function (data) {
                return vm.companies = data;
            }).then(function (data) {
                selectCompany(data[0].Id);
            });
        }

        function setCurrentCompany(obj) {
            if (obj !== null) {
                vm.companyModel = obj;
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

        function save() {
            //console.log('category says: ' + vm.companyModel.CategoryId + ' and stateId says: ' + vm.companyModel.StateId);
            //console.log('filterCategory says: ' + vm.filterCategory);

            //console.log('phone and fax say: ' + vm.companyModel.CompanyPhone + ', ' + vm.companyModel.CompanyFax);

            return apiService.saveCompany(vm.companyModel).then(function (data) {
                vm.companyModel = data;
                log('Saved Company successfully.');
            });
        }
    }
})();