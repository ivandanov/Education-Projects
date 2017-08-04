(function () {
    'use strict';

    function projectDetails() {
        return {
            restrict: 'A',
            templateUrl: 'views/directives/project-details-directive.html'
        }
    }

    angular.module('myApp.directives')
        .directive('projectDetails', [projectDetails]);
}());