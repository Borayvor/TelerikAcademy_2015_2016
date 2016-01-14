"use strict"

let forbiddenCharacters = [' ', '<', '>', '(', ')', ','];

function validateName(val) {

    let containsForbiddenChars = forbiddenCharacters.some(
        function (item) {
            return val.includes(item);
        }
        );

    return !containsForbiddenChars;
}

function validateEmail(val) {
    return true;
}

module.exports = {
    validateName,
    validateEmail
}