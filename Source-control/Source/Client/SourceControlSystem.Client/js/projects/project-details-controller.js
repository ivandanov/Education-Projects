(function () {
    'use strict';

    function ProjectDetailsController($routeParams, notifier, projects, commits, identity, collaborators) {
        var vm = this;
        var dbCommits;
        vm.identity = identity;
        vm.request = {
            Page: 1
        };

        vm.prevPage = function () {
            if (vm.request.Page == 1) {
                return;
            }

            vm.request.Page--;
            vm.filterCommits();
        }

        vm.nextPage = function () {
            if (!vm.commits || vm.commits.length == 0) {
                return;
            }
            debugger;
            vm.request.Page++;
            vm.filterCommits();
        }

        vm.filterCommits = function () {
            commits.getCommitsByProject($routeParams.id, vm.request)
                .then(function (filteredCommits) {
                    dbCommits = filteredCommits;
                    vm.commits = filteredCommits;
                });
        }
        
        vm.filterCommitsLocal = function () {
            vm.commits = _.filter(dbCommits, function (commit) {
                var date = new Date(commit.CreatedOn);
                var toDate = new Date(vm.request.ToDate);
                var fromDate = new Date(vm.request.FromDate);
                
                return date < fromDate 
                    && date > toDate 
            })

        }

        vm.addColaborator = function () {
            collaborators.addColaboratorToProject($routeParams.id, vm.newColaborator)
                .then(function (colaborators) {
                    notifier.success('Successfuly added!');
                }, function (err) {
                    notifier.error('Something wrong');
                });
        }

        collaborators.getProjectColaborators($routeParams.id, vm.request)
            .then(function (colaborators) {
                if (colaborators.indexOf(identity.getCurrentUser())) {
                    vm.showAddingControl = true;
                }
                vm.colaborators = colaborators;
            });

        projects.getProjectDetails($routeParams.id)
            .then(function (projectDetails) {
                vm.project = projectDetails;
            });

        commits.getCommitsByProject($routeParams.id)
            .then(function (commitsByProject) {
                vm.commits = commitsByProject;
            });
    }

    angular.module('myApp.controllers')
        .controller('ProjectDetailsController', ['$routeParams', 'notifier', 'projects', 'commits', 'identity', 'collaborators', ProjectDetailsController])
}());