(function () {
    let siteSrc = 'https://telerikacademy.com/';

    function redirectToUrl() {
        return new Promise((resolve, reject) => {
            alert('Click "OK".');

            setTimeout(function () {
                resolve(window.location.href = siteSrc);
            }, 2000);
        });
    }

    redirectToUrl();
} ());