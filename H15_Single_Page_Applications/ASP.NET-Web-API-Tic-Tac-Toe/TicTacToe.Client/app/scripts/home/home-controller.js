(function () {
    'use strict';

    function HomeController() {
        var vm = this;

        vm.hi = 'Hi !';
    }

    angular.module('TicTacToeApp.controllers')
        .controller('HomeController', [HomeController]);
}());