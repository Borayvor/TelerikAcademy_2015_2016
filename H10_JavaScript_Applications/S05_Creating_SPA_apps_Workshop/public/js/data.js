/* globals requester localStorage */

const HTTP_HEADER_KEY = "x-auth-key",
    KEY_STORAGE_USERNAME = "username",
    KEY_STORAGE_AUTH_KEY = "authKey";

var dataService = {
    cookies() {
        return requester.getJSON("/api/cookies");
    },
    addCookie(cookie) {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };

        return requester.postJSON("/api/cookies", cookie, options);
    },
    rateCookie(cookieId, type) {
        let options = {
            headers: {
                [HTTP_HEADER_KEY]: localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        };

        return requester.putJSON("/api/cookies/" + cookieId, { type }, options);

    },
    category() {
        return requester.getJSON("/api/categories");
    },
    login(user) {
        return requester.putJSON("/api/auth", user)
            .then(respUser => {
                localStorage.setItem(KEY_STORAGE_USERNAME, respUser.result.username);
                localStorage.setItem(KEY_STORAGE_AUTH_KEY, respUser.result.authKey);
            });
    },
    register(user) {
        return requester.postJSON("/api/users", user);
    },
    logout() {
        return Promise.resolve()
            .then(() => {
                localStorage.removeItem(KEY_STORAGE_USERNAME);
                localStorage.removeItem(KEY_STORAGE_AUTH_KEY);
            });
    },
    isLoggedIn() {
        return Promise.resolve()
            .then(() => {
                return !!localStorage.getItem(KEY_STORAGE_USERNAME);
            });
    }
};