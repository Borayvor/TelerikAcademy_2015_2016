/* globals dataService templates $ Handlebars console */

const KEY_STORAGE_HOURLY_FORTUNE_COOKIE_TIME = "hourly-fortune-cookie-time";
const KEY_STORAGE_HOURLY_FORTUNE_COOKIE_ID = "hourly-fortune-cookie-id";
var handlebars = handlebars || Handlebars;

function _getRandomIntInclusive(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

let controllers = {
    get(dataService, templates) {
        return {
            home(params) {
                console.log(params);
                let cookies;
                dataService.cookies()
                    .then((cookiesResponse) => {
                        cookies = cookiesResponse;
                        cookies.result.sort((a, b) => {
                            return a.shareDate < b.shareDate;
                        });
                       
                        return templates.get("home");
                    })
                    .then((templateHtml) => {
                        let templateFunc = handlebars.compile(templateHtml);
                        let html = templateFunc(cookies);
                        $("#container").html(html);

                        $(".btn-like-dislike").on("click", function (ev) {
                            let type = $(this).attr("data-type");
                            let cookieId = $(this).parents("li").attr("data-id");

                            dataService.rateCookie(cookieId, type)
                                .then();
                        });
                    });
            },
            category(params) {
                console.log("Category");
                console.log(params);
                // dataService.cookies()
                //     .then((cookiesResponse) => {
                //         cookies = cookiesResponse;
                       
                //         return templates.get("home");
                //     });
            },
            myCookie() {
                let currentTimeHours = new Date().getHours();
                let lastTime = localStorage.getItem(KEY_STORAGE_HOURLY_FORTUNE_COOKIE_TIME);
                let lastCookieId = localStorage.getItem(KEY_STORAGE_HOURLY_FORTUNE_COOKIE_ID);
                let cookie;

                if (lastTime < currentTimeHours || lastTime === null) {
                    localStorage.setItem(KEY_STORAGE_HOURLY_FORTUNE_COOKIE_TIME, currentTimeHours);

                    dataService.cookies()
                        .then((cookiesResponse) => {
                            let cookies = cookiesResponse.result;
                            let randNumber = _getRandomIntInclusive(0, cookies.length);
                            
                            cookie = cookies[randNumber];
                            localStorage.setItem(KEY_STORAGE_HOURLY_FORTUNE_COOKIE_ID, cookie.id);

                            return templates.get("my-cookie")
                                .then((templateHtml) => {
                                    let templateFunc = handlebars.compile(templateHtml);
                                    let html = templateFunc(cookie);
                                    $("#container").html(html);
                                });
                        });                        
                } else {
                    dataService.cookies()
                        .then((cookiesResponse) => {
                            let cookies = cookiesResponse.result;
                            cookie = cookies.find((cookie) => {                               
                                return cookie.id === lastCookieId;
                            });

                            templates.get("my-cookie")
                                .then((templateHtml) => {
                                    let templateFunc = handlebars.compile(templateHtml);
                                    let html = templateFunc(cookie);
                                    $("#container").html(html);
                                });
                        });
                }
            },
            addCookie() {
                templates.get("cookie-add")
                    .then((templateHtml) => {
                        let templateFunc = handlebars.compile(templateHtml);
                        let html = templateFunc();

                        $("#container").html(html);

                        $("#btn-add").on("click", () => {
                            let cookie = {
                                text: $("#tb-text").val(),
                                img: $("#tb-img-url").val(),
                                category: $("#tb-category").val()
                            };

                            validator.validateFortuneCookieText(cookie.text);
                            validator.validateFortuneCookieCategory(cookie.category);
                            validator.validateFortuneCookieImgUrl(cookie.img);

                            if (cookie.img.length === 0) {
                                cookie.img = null;
                            }

                            dataService.addCookie(cookie)
                                .then(() => {
                                    window.location = "#/home";
                                });
                        });
                    });
            },
            login() {
                dataService.isLoggedIn()
                    .then(isLoggedIn => {
                        if (isLoggedIn) {
                            //redirect to
                            window.location = "#/home";
                            return;
                        }

                        templates.get("login")
                            .then((templateHtml) => {
                                let templateFunc = handlebars.compile(templateHtml);
                                let html = templateFunc();
                                $("#container").html(html);

                                $("#btn-login").on("click", (ev) => {
                                    let user = {
                                        username: $("#tb-username").val(),
                                        passHash: $("#tb-password").val()
                                    };

                                    validator.validateUserName(user.username);

                                    dataService.login(user)
                                        .then((respUser) => {
                                            //123456q
                                            $(document.body).addClass("logged-in");
                                            document.location = "#/home";
                                        });

                                    ev.preventDefault();
                                    return false;
                                });

                                $("#btn-register").on("click", (ev) => {
                                    let user = {
                                        username: $("#tb-username").val(),
                                        passHash: $("#tb-password").val()
                                    };

                                    dataService.register(user)
                                        .then((respUser) => {
                                            return dataService.login(user);
                                        })
                                        .then((respUser) => {
                                            //123456q
                                            $(document.body).addClass("logged-in");
                                            document.location = "#/home";
                                        });
                                    ev.preventDefault();
                                    return false;
                                });

                            });
                    });
            }
        };
    }
};