(function () {
    'use strict';

    function PlayGameController($location, $interval, $routeParams, notifier, games) {
        var vm = this;

        vm.gameId = $routeParams.gameId;

        function status() {
            // Check whether the user has changed the route in order to stop refreshing the status of the current game
            if (!vm.gameId || $location.path() != '/games/' + vm.gameId) {
                return;
            }            

            games.status(vm.gameId)
                .then(function (gameInfo) {
                    vm.game = gameInfo;
                }, function (error) {
                    notifier.error(error.Message);
                });
        }

        $interval(status, 1000);

        vm.play = function play(row, index) {
            var col = (index % 3) + 1;

            games.play({
                GameId: vm.gameId,
                Row: row,
                Col: col
            })
                .then(function (response) {
                    notifier.success('Successful turn.');
                }, function (error) {
                    notifier.error(error.Message);
                });
        }
    }

    angular.module('TicTacToeApp.controllers')
        .controller('PlayGameController',
        ['$location', '$interval', '$routeParams', 'notifier', 'gamesService', PlayGameController]);
}());