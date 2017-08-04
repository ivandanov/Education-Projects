(function () {
    'use strict';

    function collaborators($http, data) {
        var COLLABORATORS_URL = 'api/projects';

        function getProjectColaborators(projectId) {
            return data.get(COLLABORATORS_URL + '/collaborators/' + projectId);
        }

        function addColaboratorToProject(projectId, newColaborator) {
            return data.put(COLLABORATORS_URL + '/' + projectId, "\"" + newColaborator +'\"');
        } 

        return {
            addColaboratorToProject: addColaboratorToProject,
            getProjectColaborators: getProjectColaborators,
        }
    }

    angular.module('myApp.services')
        .factory('collaborators', ['$http', 'data', collaborators])
}());