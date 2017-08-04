(function () {
    'use strict';

    function licenses(data) {
        function getLicenses() {
            return data.get('api/licenses');
        }

        return {
            getLicenses: getLicenses
        }
    }

    angular.module('myApp.services')
        .factory('licenses', ['data', licenses])
}());