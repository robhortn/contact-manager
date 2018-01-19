(function () {
    'use strict';
    var controllerId = 'contacts';
    angular.module('app').controller(controllerId, ['common', 'apiService', contacts]);

    function contacts(common, apiService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        // Messages and titles
        vm.titles = {
            main: 'Contacts',
            contactList: 'Listing'
        };

        // Lists
        vm.contacts = [];

        // Models
        vm.contactModel = {};

        // Functions
        vm.selectContact = selectContact;

        activate();

        function activate() {
            var promises = [getContacts()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Contacts View'); });
        }

        function getContacts() {
            return apiService.getContacts().then(function (data) {
                return vm.contacts = data;
            }).then(function (data) {
                selectContact(data[0].Id);
            });
        }

        function setCurrentContact(obj) {
            if (obj !== null) {
                vm.contactModel = obj;
            }
        }

        function selectContact(id) {
            var result = vm.contacts.find(x => x.Id === id);
            if (result !== undefined) {
                setCurrentContact(result);
            } else {
                console.log('selectContact() in contacts.js cannot find id: ' + id);
            }
        }
    }
})();