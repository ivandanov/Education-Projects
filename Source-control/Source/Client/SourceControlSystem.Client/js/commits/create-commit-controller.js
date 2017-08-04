(function () {
    'use strict';

    function CreateCommitController($routeParams, $location, licenses, commits) {
        var vm = this;
        vm.id = $routeParams.id;

        licenses.getLicenses()
            .then(function (allLicenses) {
                vm.licenses = allLicenses;
            });

        vm.createCommit = function (newCommit) {
            newCommit.projectId = vm.id;
            commits.createCommit(newCommit)
                .then(function (projectId) {
                    $location.path('/projects/' + $routeParams.id);
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateCommitController', ['$routeParams', '$location', 'licenses', 'commits', CreateCommitController]);
}());