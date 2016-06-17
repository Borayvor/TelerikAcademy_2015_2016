var task = document.getElementById('task');
task.innerHTML = "8. Write a script that converts a number in the range [0…999] to " +
    "words, corresponding to its English pronunciation.";

function onButtonClickConvertNumber() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    var numberName = [
        ["Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"],
        ["Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen"],
        ["Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"],
        ["Hundred"]
    ]

    var number = parseInt(document.getElementById("number").value);
    var firstDigit = parseInt(number / 100) % 10;
    var secondDigit = parseInt(number / 10) % 10;
    var thirdDigit = number % 10;

    if (number >= 100 && number <= 999) {
        if (secondDigit == 0 && thirdDigit != 0) {
            answer.innerHTML += numberName[0][firstDigit] + " " + numberName[3] + " and " +
                numberName[0][thirdDigit];
        }
        else if (secondDigit == 1) {
            answer.innerHTML += numberName[0][firstDigit] + " " + numberName[3] + " and " +
                numberName[1][thirdDigit];
        }
        else if (secondDigit > 1 && secondDigit <= 9) {
            answer.innerHTML += numberName[0][firstDigit] + " " + numberName[3] + " and " +
                numberName[2][secondDigit - 2] + " " + numberName[0][thirdDigit];
        }
        else {
            answer.innerHTML += numberName[0][firstDigit] + " " + numberName[3];
        }
    }
    else if (number >= 10 && number <= 99) {
        if (secondDigit == 1) {
            answer.innerHTML += numberName[1][thirdDigit];
        }
        else if (secondDigit > 1 && secondDigit <= 9) {
            answer.innerHTML += numberName[2][secondDigit - 2] + " " + numberName[0][thirdDigit];
        }
    }
    else if (number >= 0 && number <= 9) {
        answer.innerHTML += numberName[0][thirdDigit];
    }
    else {
        answer.innerHTML += "The number must be in the range [0...999] !";
    }
}

function solve(args) {
    var number = parseInt(args);

    var numberName = [
        ["Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"],
        ["Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
            "Seventeen", "Eighteen", "Nineteen"],
        ["Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"],
        ["Hundred"]
    ]

    var firstDigit = parseInt(number / 100) % 10;
    var secondDigit = parseInt(number / 10) % 10;
    var thirdDigit = number % 10;

    var numberAsString = '';

    if (number >= 100 && number <= 999) {
        if (secondDigit == 0 && thirdDigit != 0) {
            numberAsString = numberName[0][firstDigit] + " " + numberName[3][0].toLowerCase() + " and " +
                numberName[0][thirdDigit].toLowerCase();
        }
        else if (secondDigit == 1) {
            numberAsString = numberName[0][firstDigit] + " " + numberName[3][0].toLowerCase() + " and " +
                numberName[1][thirdDigit].toLowerCase();
        }
        else if (secondDigit > 1 && secondDigit <= 9 && thirdDigit > 0) {
            numberAsString = numberName[0][firstDigit] + " " + numberName[3][0].toLowerCase() + " and " +
                numberName[2][secondDigit - 2].toLowerCase() + " " + numberName[0][thirdDigit].toLowerCase();
        }
        else if (secondDigit > 1 && secondDigit <= 9 && thirdDigit === 0) {
            numberAsString = numberName[0][firstDigit] + " " + numberName[3][0].toLowerCase() + " and " +
                numberName[2][secondDigit - 2].toLowerCase();
        }
        else {
            numberAsString = numberName[0][firstDigit] + " " + numberName[3][0].toLowerCase();
        }
    }
    else if (number >= 10 && number <= 99) {
        if (secondDigit == 1) {
            numberAsString = numberName[1][thirdDigit];
        }
        else if (secondDigit > 1 && secondDigit <= 9 && thirdDigit > 0) {
            numberAsString = numberName[2][secondDigit - 2] + " " + numberName[0][thirdDigit].toLowerCase();
        }
        else {
            numberAsString = numberName[2][secondDigit - 2];
        }
    }
    else if (number >= 0 && number <= 9) {
        numberAsString = numberName[0][thirdDigit];
    }
    else {
        numberAsString = "The number must be in the range [0...999] !";
    }

    console.log(numberAsString);
}