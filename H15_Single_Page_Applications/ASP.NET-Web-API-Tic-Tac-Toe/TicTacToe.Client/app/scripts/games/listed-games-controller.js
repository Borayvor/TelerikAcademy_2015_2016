(function () {
    'use strict';

    function listedGamesController($location, notifier, games, identity) {
        var vm = this;

        vm.isAuthenticated = function checklogin() {
            return identity.isAuthenticated();
        }

        games.listGames()
            .then(function (listedGames) {
                vm.games = listedGames;
            });

        vm.createGame = function createGame() {
            games.create()
                .then(function (response) {
                    notifier.success('Game successfully created.');
                    vm.gameId = response;
                    $location.path('/games/' + vm.gameId);
                }, function (err) {
                    notifier.error(err.Message);
                });
        }

        vm.joinGame = function joinGame(gameId) {
            games.join(gameId)
                .then(function (response) {
                    notifier.success('Game successfully joined.');
                    vm.gameId = response;
                    $location.path('/games/' + vm.gameId);
                }, function (err) {
                    notifier.error(err.Message);
                });
        }
    }

    angular.module('TicTacToeApp.controllers')
        .controller('listedGamesController',
        ['$location', 'notifier', 'gamesService', 'identityService', listedGamesController]);
}());