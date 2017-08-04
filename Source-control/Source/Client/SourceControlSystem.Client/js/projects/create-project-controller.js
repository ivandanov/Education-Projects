﻿(function () {
    'use strict';

    function CreateProjectController($location, licenses, projects) {
        var vm = this;

        licenses.getLicenses()
            .then(function (allLicenses) {
                vm.licenses = allLicenses;
            });

        vm.createProject = function (newProject) {
            projects.createProject(newProject)
                .then(function (projectId) {
                    $location.path('/projects/' + projectId);
                });
        }
    }

    angular.module('myApp.controllers')
        .controller('CreateProjectController', ['$location', 'licenses', 'projects', CreateProjectController]);
}());