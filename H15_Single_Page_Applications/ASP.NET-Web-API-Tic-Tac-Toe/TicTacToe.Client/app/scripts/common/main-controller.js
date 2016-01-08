(function () {
    'use strict';

    function MainController($location, auth, identity) {
        var vm = this;
        // this is for initial load of the page
        waitForLogin();

        vm.logout = function () {
            vm.globallySetCurrentUser = undefined;
            auth.logout();
            waitForLogin(); // this is for second login
            $location.path('/');
        };

        function waitForLogin() {
            identity.getUser()
                .then(function (user) {
                    vm.globallySetCurrentUser = user;
                });
        }
    }

    angular.module('TicTacToeApp')
        .controller('MainController', ['$location', 'auth', 'identityService', MainController]);
}());