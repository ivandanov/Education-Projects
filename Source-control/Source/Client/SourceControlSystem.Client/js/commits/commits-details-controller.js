(function () {
    'use strict';

    function CommitsDetailsController($routeParams, commits) {
        var vm = this;

        commits.getCommitsDetails($routeParams.id)
            .then(function (commitDetails) {
                vm.commit = commitDetails;
            });


    }

    angular.module('myApp.controllers')
        .controller('CommitsDetailsController', ['$routeParams', 'commits', CommitsDetailsController])
}());