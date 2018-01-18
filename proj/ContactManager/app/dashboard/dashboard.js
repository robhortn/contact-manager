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
        vm.category = '';
        vm.stateId = '';
        vm.filterCategory = '';
        vm.filterPhone = '';

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
        vm.companyModel = {
            Id: 0,
            CompanyName: '',
            Address1: '',
            Address2: '',
            City: '',
            StateProvinceName: '',
            StateId: null,
            PostalCode: '',
            CategoryId: null,
            CategoryName: '',
            CompanyPhone: '',
            CompanyFax: '',
            IsActive: 0
        };

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
                vm.companyModel.Id = obj.Id;
                vm.companyModel.CompanyName = obj.CompanyName;
                vm.companyModel.Address1 = obj.Address1;
                vm.companyModel.Address2 = obj.Address2;
                vm.companyModel.City = obj.City;
                vm.companyModel.StateProvinceName = obj.StateProvinceName;
                vm.companyModel.StateId = obj.StateId;
                vm.companyModel.PostalCode = obj.PostalCode;
                vm.companyModel.CategoryId = obj.CategoryId;
                vm.companyModel.CategoryName = obj.CategoryName;
                vm.companyModel.CompanyPhone = obj.CompanyPhone;
                vm.companyModel.CompanyFax = obj.CompanyFax;
                vm.companyModel.IsActive = obj.IsActive;
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

            return apiService.saveCompany(vm.companyModel).then(function () {
                log('Saved Company successfully.');
            });
        }
    }
})();