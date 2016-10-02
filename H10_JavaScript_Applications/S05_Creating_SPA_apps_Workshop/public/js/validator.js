let validator = {
    validateIsString(value, objName) {
        if (typeof value !== "string") {
            throw new Error(objName + " must be a string !");
        }
    },
    validateStringLength(value, objName, min = 6, max = 30) {
        if (value.length < min || max < value.length) {
            throw new Error(objName + " must be between " + min + " and " + max + " symbols !");
        }
    },
    validateStringCharacters(value, objName) {
        if (/[^a-z^A-Z^0-9^\_^\.]/.test(value)) {
            throw new Error(objName + " can contain only Latin letters, digits and the characters '_' and '.' !");
        }
    },
    validateUrl(value, objName) {
        if (value.length > 0) {
            // let regEx = new RegExp("_^(?:(?:https?|ftp)://)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])" + 
            // "(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5]))" + "{2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\0x{00a1}-\0x{ffff}0-9]+-?)*[a-z\0x{00a1}-\0x{ffff}0-9]+)(?:\.(?:[a-z\0x{00a1}-\0x{ffff}0-9]+-?)*[a-z\0x{00a1}-\0x{ffff}0-9]+)*(?:\.(?:[a-z\0x{00a1}-\0x{ffff}]{2,})))" +
            // "(?::\d{2,5})?(?:/[^\s]*)?$_iuS");
            let regEx = /https?:\/\//;
            let res = value.match(regEx);
            if (res === null) {
                throw new Error(objName + " must be a valid url address !");
            }
        }
    },
    validateUserName(value) {
        validator.validateIsString(value, "User name");
        validator.validateStringLength(value, "User name");
        validator.validateStringCharacters(value, "User name");
    },
    validateFortuneCookieText(value) {
        validator.validateIsString(value, "Fortune Cookie Text");
        validator.validateStringLength(value, "Fortune Cookie Text");
    },
    validateFortuneCookieCategory(value) {
        validator.validateIsString(value, "Fortune Cookie Category");
        validator.validateStringLength(value, "Fortune Cookie Category");
    },
    validateFortuneCookieImgUrl(value) {
        validator.validateIsString(value, "Fortune Cookie Img Url");
        validator.validateUrl(value, "Fortune Cookie Img Url");
    }
};