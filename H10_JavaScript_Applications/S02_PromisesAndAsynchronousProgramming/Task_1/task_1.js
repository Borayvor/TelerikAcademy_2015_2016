(function () { 
    let locationElement = document.getElementById('myLocation');

    function getGeolocationPositionPromise() {
        return new Promise((resolve, reject) => { 
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    resolve(position);
                },
                (error) => {
                    reject(error);
                }
            );
        });
    }

    function parseLatAndLongCoords(geolocationPosition) {
        if (geolocationPosition.coords) {
            return { lat: geolocationPosition.coords.latitude, long: geolocationPosition.coords.longitude };
        } else {
            throw { message: "No coords element found", name: "UserException" };
        }
    }

    function createGeolocationImage(coords) {
        var imgElement = document.createElement("img"),
            imgSrc = "http://maps.googleapis.com/maps/api/staticmap?center=" +
                coords.lat +
                "," +
                coords.long +
                "&zoom=16&size=500x500&sensor=false";

        imgElement.setAttribute("src", imgSrc);

        locationElement.appendChild(imgElement);
    }

    getGeolocationPositionPromise()
        .then(parseLatAndLongCoords)
        .then(createGeolocationImage);
} ());