(function(){
    require.config({
        paths: {
            jquery: "scripts/jquery-2.0.2",
            Q: "scripts/q",
            UI: "scripts/userInterface",
            CrowdController: "scripts/crowdController",
            sammy: "scripts/sammy",
            sha1: "scripts/sha1",
            HTTP: "scripts/httpRequester"
        }

    });

    require(['CrowdController','jquery', 'Q', 'UI'], function(CrowdController, $, Q, UI){
       // var serverUrl = 'http://localhost:3000/';

        $(document).ready(function () {
            var server = 'http://localhost:3000/'
            var Controller = new CrowdController(server);
            Controller.start();
        });
    });


}());