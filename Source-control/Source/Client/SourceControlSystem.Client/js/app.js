(function () {
    'use strict';

    function config($routeProvider) {

        var PARTIALS_PREFIX = 'views/partials/';
        var CONTROLLER_AS_VIEW_MODEL = 'vm';

        $routeProvider
            .when('/', {
                templateUrl: PARTIALS_PREFIX + 'home/home.html',
                controller: 'HomeController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/unauthorized', {
                template: '<h1 class="text-center">YOU ARE NOT AUTHORIZED!</h1>'
            })
            .when('/projects', {
                templateUrl: PARTIALS_PREFIX + 'projects/all-projects.html',
                controller: 'ProjectsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/projects/add', {
                templateUrl: PARTIALS_PREFIX + 'projects/create-project.html',
                controller: 'CreateProjectController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/projects/:id', {
                templateUrl: PARTIALS_PREFIX + 'projects/project-details.html',
                controller: 'ProjectDetailsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/commits/:id', {
                templateUrl: PARTIALS_PREFIX + 'commits/commit-details.html',
                controller: 'CommitsDetailsController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/projects/:id/addcommits', {
                templateUrl: PARTIALS_PREFIX + 'commits/create-commit.html',
                controller: 'CreateCommitController',
                controllerAs: CONTROLLER_AS_VIEW_MODEL
            })
            .when('/register', {
                templateUrl: PARTIALS_PREFIX + 'identity/register.html',
                controller: 'SignUpCtrl'
            })
            .otherwise({ redirectTo: '/' });
    }

    angular.module('myApp.services', []);
    angular.module('myApp.directives', []);
    angular.module('myApp.filters', []);
    angular.module('myApp.controllers', ['myApp.services']);
    angular.module('myApp', ['ngRoute', 'ngCookies', 'kendo.directives', 'myApp.controllers', 'myApp.directives', 'myApp.filters']).
        config(['$routeProvider', config])
        .value('toastr', toastr)
        .constant('baseServiceUrl', 'http://localhost:42252');
}());