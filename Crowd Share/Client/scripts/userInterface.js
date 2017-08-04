define([], function(){
    var UI = (function(){
        function createMessageLI(message, fromSearch){
            //no time for smart DOM appending :(
            var div = "<div>" +
                "<span> Title: </span> <strong>"+message.title +
                "</strong><span> From: </span> <strong>"+message.user.username +
                "</strong> <span> Date: </span><strong>"+ message.postDate +
                " </strong><br><span> Body:</span><strong>"+ message.body +"</strong></div>";
            return $('<li />').html(div);
        }
        function createChatBox(JSONMessages, listSelector){
            //console.log(JSONMessages);
            //body: "sdfsdfs"
            /*id: 1
            postDate: "2014-07-29T16:16:49.469Z"
            title: "sadada"*/

            var i;

            var $MessageList;
            if(listSelector) $MessageList = $(listSelector);
            else $MessageList = $('#messagesList');
            $MessageList.html('');
            var allPosts = JSONMessages;
            //allPosts.length - 10
            for (var i = allPosts.length-1; i > allPosts.length-20; i--) {
                var message = allPosts[i];
                var post = createMessageLI(message);
                $MessageList.append(post);
            }
            return $MessageList;
        }

        return {
            createMessageLI: createMessageLI,
            createChatBox: createChatBox
        }
    }());

    return UI;
})


