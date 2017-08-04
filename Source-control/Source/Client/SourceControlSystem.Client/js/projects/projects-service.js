(function(){
    'use strict';

    function projects(data) {
        var PROJECTS_URL = 'api/projects';

        function getPublicProjects() {
            return data.get(PROJECTS_URL);
        }

        function filterProjects(filters) {
            return data.get(PROJECTS_URL + '/all', filters);
        }

        function createProject(project) {
            return data.post(PROJECTS_URL, project);
        }

        function getProjectDetails(projectId) {
            return data.get(PROJECTS_URL + '/' + projectId);
        }

        return {
            getPublicProjects: getPublicProjects,
            createProject: createProject,
            filterProjects: filterProjects,
            getProjectDetails: getProjectDetails
        }
    }

    angular.module('myApp.services')
        .factory('projects', ['data', projects])
}());