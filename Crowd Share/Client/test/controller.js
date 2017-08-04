(function (scope) {
    scope.Controller = (function () {
        var server;
        var Controller = function (serverUrl) {
            server = serverUrl;
        }

        function addLoginFormHandler() {
            var $password = $('#loginInputPassword');

            $password.keypress(function (event) {
                if (event.which == 13) {
                    var $username = $('#loginInput').val();
                    var $pass = $password.val();
                    login($username, $pass);
                }
            })
        }

        function addChatHandler() {
            var $sendMessage = $('#message');
            $sendMessage.keypress(function (event) {
                if (event.which == 13) {
                    var title = $('#title').val();
                    var message = $('#message').val();
                    sendMessage(message, title);

                }
            })

            $('#searchButton').on('click', function () {
                var author = $('#searchAuthor').val();
                var text = $('#searchText').val();
                //console.log("aaaa");
                search(author, text);
            });


        }

        function addRegisterHandler() {
            var $registerUserInput = $('#registerName');
            var $passwordInput = $('#loginInputPassword');

            $passwordInput.keypress(function (event) {
                if (event.which == 13) {
                    var username = $passwordInput.val();
                    var password = $passwordInput.val();
                    registerUser(username, password);
                    //window.location = '#/chat';
                }
            })
        }

        function registerUser(username, password) {
            //console.log(SHA("benfranklinsecret"));
            //to do name password lenght rpoverka
            if (username.length >= 40 || username.length <= 6) {
                alert("Името трябва да е мейду 6 и 40 символа!");
                return;
            }
            var objectToSend = {
                username: username,
                authCode: "" + SHA(username + password)
            };
            /*var data2 = {
             username: "obiwan",
             authCode: "9aab5aedfa56b93dd9e035ff2ecd2215a148e3d9"
             };*/
            http.postJSON(server + 'user/', null, objectToSend)
                .then(function (response) {
                    if (response) {
                        alert("Успешна регистрация!");
                        window.location = '#/login';
                    }
                });

        }

        function loadLogin() {
            $('#main').load('pages/loginForm.html', addLoginFormHandler);
        }

        function login($username, $pass) {
            var objectToSend = {
                username: $username,
                authCode: "" + SHA($username + $pass)
            }
            http.postJSON(server + 'auth', null, objectToSend)
                .then(function (response) {
                    setNameKey(response);
                    window.location = '#/chat';
                }, function (error) {
                    alert(error.responseJSON.message);
                }).then(function () {
                }, function () {
                });
        };
        function logOut() {
            $.ajax({
                type: 'PUT',
                url: server + 'user',
                headers: {
                    "X-SessionKey": getUserKey()
                },
                data: true
            }).done(function () {
                localStorage.clear();
                window.location = '#/login';
            });
        }

        function loadRegistrationForm() {
            $('#main').load('pages/registerForm.html', addRegisterHandler);
        }

        function getUsername() {
            return localStorage.getItem('username');
        };
        function getUserKey() {
            return localStorage.getItem('sessionKey');
        };
        function setNameKey(response) {
            var name = response.username;
            var key = response.sessionKey;
            localStorage.setItem('username', name);
            localStorage.setItem('sessionKey', key);
            //console.log(name+ '   ' + key);
        };
        function isLoggedIn() {
            //console.log(localStorage.getItem('sessionKey'));
            return localStorage.getItem('sessionKey') != null;
        };

        function sendMessage(message, title) {
            $.ajax({
                type: 'POST',
                url: server + 'post',
                "Content-Disposition": "form-data",
                headers: {
                    "X-SessionKey": getUserKey(),
                },
                data: {
                    "title": message,
                    "body": title
                }
            }).done(function (response) {
                $('#title').val('');
                $('#message').val('');
            });

            /*http.postJSON(server+'user', headers, messageToSend2)
             .then(function (posts) {
             console.log(posts);
             */
            /* $('#message').val('');
             var messageHtml = UI.createMessageLI({
             by: getUsername(),
             text: message
             });
             $('#messagesList').prepend(messageHtml);*/
            /*
             });*/
        };
        function search(author, text) {
            var serverUrl = server + "post";
            if (author && text) serverUrl += "?pattern=" + text + "&user=" + author;
            else if (author) serverUrl += "?user=" + author;
            else if (text) serverUrl += "?pattern=" + text;

            http.getJSON(serverUrl)
                .then(function (response) {
                    if (response.length > 0) {
                        $('#searchMessagesList').html('');
                        $('#searchMessagesList').show();
                        var searchResults = UI.createChatBox(response, "#searchMessagesList");
                        $('.searchMessages').html(searchResults);
                    } else {
                        alert("Няма намерени!");
                    }
                }, function (error) {
                    alert(error.responseJSON.message);
                });

            //var messages = getMessagesWithOptions(author, text);


        }

        function loadMessages() {
            var postServerUrl = server + 'post';
            http.getJSON(postServerUrl)
                .then(function (posts) {
                    //console.log(posts);

                    var chatBox = UI.createChatBox(posts);
                    $('.messages').html(chatBox);
                });
        }

        function loadChat() {
            $.get('pages/chat.html', function (chat) {
                $('#main').html(chat);
                $('#user-username').html(getUsername());
                $('#logout-button').on('click', function () {
                    var exit = confirm("Are you sure you want to end the session?");
                    if (exit === true) {
                        logOut();
                    }
                });

                loadMessages();
                setInterval(function () {
                    loadMessages();
                }, 1500);

                addChatHandler();
            });

        };
        function start() {
            var app = Sammy('#main', function () {
                this.get('#/login', function () {
                    if (isLoggedIn()) {
                        window.location = '#/chat';
                    } else {
                        loadLogin();
                    }
                });
                this.get('#/registration', function () {
                    loadRegistrationForm()
                    /*if (isLoggedIn()) {
                     window.location = '#/chat';
                     } else {
                     loadLogin();
                     }*/
                });

                this.get('#/chat', function () {
                    if (isLoggedIn()) {
                        loadChat();
                    } else {
                        loadLogin();
                    }
                });
            });

            app.run('#/login');
        }


        Controller.prototype = {
            start: function () {
                return start();
            },
            registerUser: function () {
                return registerUser()
            },

            isLoggedIn: function () {
                return isLoggedIn()
            },
            getUserKey: function () {
                return getUserKey()
            },
            getUsername: function () {
                return getUsername()
            },
            //only for tests
            sum: function (numbers) {
                var numbersSum, i, number, len;
                numbersSum = 0;
                for (i = 0, len = numbers.length; i < len; i++) {
                    number = numbers[i];
                    numbersSum += number;
                }
                return numbersSum;
            }
        };

        return Controller;
    }());

    //return Controller;
}(window));