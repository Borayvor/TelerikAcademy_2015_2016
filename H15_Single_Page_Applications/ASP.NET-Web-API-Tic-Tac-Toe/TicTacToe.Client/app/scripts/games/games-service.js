(function () {
    'use strict';

    function gamesService($q, $http, baseUrl, data) {

        function listGames() {
            return data.get('api/games/listGames');
        }

        function create() {
            return data.post('api/games/create');
        }

        function join(gameId) {
            return data.post('api/games/join/' + gameId);
        }

        function status(gameId) {
            return data.get('api/games/status/' + gameId);
        }

        function play(gameDetails) {
            return data.post('api/games/play', gameDetails);
        }

        return {
            listGames: listGames,
            create: create,
            join: join,
            status: status,
            play: play
        }
    }

    angular.module('TicTacToeApp.services')
        .factory('gamesService', ['$q', '$http', 'baseUrl', 'data', gamesService]);
}());