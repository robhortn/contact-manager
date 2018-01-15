(function () {
    'use strict';
    var controllerId = 'about';
    angular.module('app').controller(controllerId, ['common', about]);

    function about(common) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;

        vm.titles = {
            main: 'About',
            mainsub: ''
        };

        activate();

        function activate() {
            common.activateController([], controllerId)
                .then(function () { log('Activated About View'); });
        }
    }
})();