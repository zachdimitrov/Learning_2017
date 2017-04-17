var data = (function() {
    const USERNAME_STOGAGE_KEY = "user-key",
        AUTH_KEY_STOGAGE_KEY = "auth-key-key";

    function userLogin(user) {
        var promise = new Promise(function(resolve, reject) {
            console.log('<< PUT request for login started >>');
            console.log('<< POST request for register started >>');
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            }
            console.log(reqUser);
            var userString = JSON.stringify(reqUser);
            $.ajax({
                url: "api/auth",
                method: "PUT",
                data: userString,
                contentType: "application/json",
                success: function(user) {
                    localStorage.setItem(USERNAME_STOGAGE_KEY, user.username);
                    localStorage.setItem(AUTH_KEY_STOGAGE_KEY, user.authKey);
                    console.log(`${userString} is logged in \n<< END of PUT request >>`);
                    resolve(user);
                }
            });
        });
        return promise;
    }

    function userRegister(user) {
        var promise = new Promise(function(resolve, reject) {
            console.log('<< POST request for register started >>');
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            }
            console.log(reqUser);
            userString = JSON.stringify(reqUser);
            $.ajax({
                url: "api/users",
                method: "POST",
                data: userString,
                contentType: "application/json",
                success: function(user) {
                    localStorage.setItem(USERNAME_STOGAGE_KEY, user.username);
                    localStorage.setItem(AUTH_KEY_STOGAGE_KEY, user.authKey);
                    console.log(`${userString} is registered \n<< END of POST request >>`);
                    resolve(user);
                }
            });
        });
        return promise;
    }

    function getCurrentUser() {
        var username = localStorage.getItem(USERNAME_STOGAGE_KEY);
        if (!username) {
            return null;
        }
        return {
            username
        };
    }

    function userLogout() {
        var promise = new Promise(function(resolve, reject) {
            localStorage.removeItem(AUTH_KEY_STOGAGE_KEY);
            localStorage.removeItem(USERNAME_STOGAGE_KEY);
            resolve();
        });
        return promise;
    }

    function userFind() {

    }

    function threadsAdd(title) {
        var promise = new Promise(function(resolve, reject) {
            $.ajax({
                url: "api/threads",
                data: JSON.stringify({ title: title }),
                method: "POST",
                headers: {
                    "x-authKey": localStorage.getItem(AUTH_KEY_STOGAGE_KEY)
                },
                contentType: "application/json",
                success: function(res) {
                    resolve(res);
                }
            });
        });
        return promise;
    }

    function threadsGet() {
        var promise = new Promise(function(resolve, reject) {
            $.getJSON("/api/threads", function(threads) {
                resolve(threads);
            });
        });
        return promise;
    }

    function threadById(id) {
        var promise = new Promise(function(resolve, reject) {
            $.getJSON(`api/threads/${id}`, function(res) {
                resolve(res);
            });
        });
        return promise;
    }

    function threadAddMessage(threadId, message) {
        var promise = new Promise(function(resolve, reject) {
            $.ajax({
                url: `/api/threads/${threadId}/messages`,
                method: "POST",
                data: JSON.stringify(message),
                contentType: "application/json",
                headers: {
                    "x-authKey": localStorage.getItem(AUTH_KEY_STOGAGE_KEY)
                },
                success: function(res) {
                    console.log(res);
                    resolve(res);
                }
            });
        });
        return promise;
    }

    return {
        users: {
            login: userLogin,
            register: userRegister,
            logout: userLogout,
            find: userFind,
            current: getCurrentUser
        },
        threads: {
            get: threadsGet,
            add: threadsAdd,
            byId: threadById,
            addMessage: threadAddMessage
        }
    }
}());