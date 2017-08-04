(function(){
    'use strict';

    function commits(data) {
        var COMMITS_URL = 'api/commits';

        function getPublicCommits() {
            return data.get(COMMITS_URL);
        }

        function getCommitsByProject(projectId, filters) {
            return data.get(COMMITS_URL + '/byproject/' + projectId, filters);
        }

        function getCommitsDetails(commitId) {
            return data.get(COMMITS_URL + '/' + commitId);
        }

        function createCommit(commit) {
            return data.post(COMMITS_URL, commit);
        }

        return {
            getPublicCommits: getPublicCommits,
            createCommit: createCommit,
            getCommitsDetails: getCommitsDetails,
            getCommitsByProject: getCommitsByProject
        }
    }

    angular.module('myApp.services')
        .factory('commits', ['data', commits])
}());