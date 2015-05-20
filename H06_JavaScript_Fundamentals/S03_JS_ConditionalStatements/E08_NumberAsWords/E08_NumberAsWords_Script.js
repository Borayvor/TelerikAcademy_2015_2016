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
            answer.innerHTML += numberName[0][firstDigit] + " "+ numberName[3] + " and " +
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