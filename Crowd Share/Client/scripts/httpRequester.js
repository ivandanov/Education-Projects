define(['Q', 'jquery'], function (Q, $) {
    var HttpRequester = (function () {
        function ajaxRequest(url, type, headers, data) {
            var deffered = Q.defer();
            //console.log(data);
            if (data) {
                data = JSON.stringify(data);
            }

            $.ajax({
                url: url,
                type: type,
                contentType: 'application/json',
                data: data,
                headers: headers || {},
                success: function (responseData) {
                    deffered.resolve(responseData);
                },
                error: function (err) {
                    deffered.reject(err);
                }
            });

            return deffered.promise;
        }

        function getJSON(url, headers) {
            return ajaxRequest(url, 'GET', headers);
        }

        function postJSON(url, headers, data) {
            return ajaxRequest(url, 'POST', headers, data);
        }

        function putJSON(url, headers, data) {
            return ajaxRequest(url, 'PUT', headers, data);
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            putJSON: putJSON
        }
    }());

    return HttpRequester;
    /*var HTTPRequest = (function () {
        function getHttpRequest() {
            var xmlHttpFactories;
            xmlHttpFactories = [
                function () {
                    return new XMLHttpRequest();
                },
                function () {
                    return new ActiveXObject("Msxml3.XMLHTTP");
                },
                function () {
                    return new ActiveXObject("Msxml2.XMLHTTP.6.0");
                },
                function () {
                    return new ActiveXObject("Msxml2.XMLHTTP.3.0");
                },
                function () {
                    return new ActiveXObject("Msxml2.XMLHTTP");
                },
                function () {
                    return new ActiveXObject("Microsoft.XMLHTTP");
                }
            ];

            var xmlFactory, _i, _len;
            for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                xmlFactory = xmlHttpFactories[_i];
                try {
                    return xmlFactory();
                } catch (error) {
                }
            }
            return null;
        };

        function makeRequest(httpRequest, options) {
            var defered = Q.defer();
            options = options || {};
            var requestUrl = options.url;
            var type = options.type || 'GET';
            var contentType = options.contentType || '';
            var accept = options.accept || '';
            var data = options.data || null;

            httpRequest.onreadystatechange = function () {
                if (httpRequest.readyState === 4) {
                    switch (Math.floor(httpRequest.status / 100)) {
                        case 2:
                            defered.resolve(httpRequest.responseText);
                            break;
                        default:
                            defered.reject(httpRequest.responseText);
                            break;
                    }
                }
            };
            httpRequest.open(type, requestUrl, true);
            httpRequest.setRequestHeader('Content-Type', contentType);
            httpRequest.setRequestHeader('Accept', accept);
            httpRequest.send(data);
            return defered.promise;
        };


        function getJSON(url) {
            var httpRequest, options;
            httpRequest = getHttpRequest();
            options = {
                url: url,
                type: 'GET',
                contentType: 'application/json',
                accept: 'application/json'
            };
            return makeRequest(httpRequest, options);
        }

        function postJSON(url, data) {
            var httpRequest, options;
            httpRequest = getHttpRequest();
            options = {
                url: url,
                type: 'POST',
                contentType: 'application/json',
                accept: 'application/json',
                data: data
            };
            return makeRequest(httpRequest, options);
        }

        return {
            getJSON: getJSON,
            postJSON: postJSON
        };
    });
    return new HTTPRequest;*/
});
