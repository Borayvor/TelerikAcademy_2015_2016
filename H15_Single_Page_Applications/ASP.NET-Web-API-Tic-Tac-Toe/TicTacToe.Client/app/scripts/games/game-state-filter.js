(function () {
    'use strict';

    function gameState() {
        return function (input) {

            switch (input) {                
                case 1:
                    return 'First player turn !';
                case 2:
                    return 'Second player turn !';
                case 3:
                    return 'Won by first player !';
                case 4:
                    return 'Won by second player !';
                case 5:
                    return 'Draw !';

                default:
                    return 'Waiting for second player to join !';
            }
        }
    }

    angular.module('TicTacToeApp.filters')
        .filter('gameState', [gameState]);
}());