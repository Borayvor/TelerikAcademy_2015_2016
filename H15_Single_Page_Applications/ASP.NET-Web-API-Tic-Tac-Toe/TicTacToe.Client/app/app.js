/// <reference path="partials/games/listed-games.html" />
/// <reference path="partials/games/listed-games.html" />
(function() {
    'use strict';

    function config($routeProvider, $locationProvider) { 
        
        var CONTROLLER_VIEW_MODEL_NAME = 'vm';

        $locationProvider.html5Mode(true);

                       
        var routeResolvers = {
            authenticationRequired: {
                authenticate: ['$q', 'auth', function routeResolvers($q, auth) {
                    if (auth.isAuthenticated()) {
                        return true;
                    }

                    return $q.reject('not authorized');
                }]
            }          
        }
        
        $routeProvider
            .when('/', {
                templateUrl: 'app/partials/home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/identity/register', {
                templateUrl: 'app/partials/identity/register.html',
                controller: 'RegisterController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/identity/login', {
                templateUrl: 'app/partials/identity/login.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/games', {

                templateUrl: 'app/partials/games/listed-games.html',
                controller: 'listedGamesController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
            })
            .when('/games/:gameId', {
                templateUrl: 'app/partials/games/play-game.html',
                controller: 'PlayGameController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeResolvers.authenticationRequired

            })
            .otherwise({ redirectTo: '/' });
    };
    
    function run($http, $cookies, $rootScope, $location, auth) {
        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
            if (rejection === 'not authorized') {
                $location.path('/');
            }
        });

        if (auth.isAuthenticated()) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + $cookies.get('authentication');
            auth.getIdentity();
        }
    };
        
    angular.module('TicTacToeApp.filters', []);
    angular.module('TicTacToeApp.services', []);
    angular.module('TicTacToeApp.directives', []);
    angular.module('TicTacToeApp.controllers', ['TicTacToeApp.services']);
        
    angular.module('TicTacToeApp', ['ngRoute', 'ngCookies', 'TicTacToeApp.controllers', 'TicTacToeApp.directives', 'TicTacToeApp.filters'])
        .config(['$routeProvider', '$locationProvider', config])
        .run(['$http', '$cookies', '$rootScope', '$location', 'auth', run])
        .value('toastr', toastr)
        .constant('baseUrl', 'http://localhost:33257/');
}())