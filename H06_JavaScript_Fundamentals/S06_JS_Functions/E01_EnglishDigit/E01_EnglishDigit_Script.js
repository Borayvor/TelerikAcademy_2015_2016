var task = document.getElementById('task');
task.innerHTML = "1. Write a function that returns the last digit of given " +
    "integer as an English word.";

function lastDigit(value) {
    var digit = null;
    var lastDigitValue = parseInt(value % 10);

    switch (lastDigitValue) {
        case 0:
            digit = "Zero";
            break;
        case 1:
            digit = "One";
            break;
        case 2:
            digit = "Two";
            break;
        case 3:
            digit = "Three";
            break;
        case 4:
            digit = "Four";
            break;
        case 5:
            digit = "Five";
            break;
        case 6:
            digit = "Six";
            break;
        case 7:
            digit = "Seven";
            break;
        case 8:
            digit = "Eight";
            break;
        case 9:
            digit = "Nine";
            break;
        default:
            digit = "NaN";
            break;
    }
    return digit;
}

function onButtonClickPrintResult() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    var number = parseInt(document.getElementById("number-value").value);

    answer.innerHTML += "The last digit of number is :  " + lastDigit(number);
}

function solve(args) { 
    switch (args[0][args[0].length - 1]) {
        case '0':
            return "zero";
        case '1':
            return "one"; 
        case '2':
            return "two";
        case '3':
            return "three";
        case '4':
            return "four";
        case '5':
            return "five";
        case '6':
            return "six";
        case '7':
            return "seven";
        case '8':
            return "eight";
        case '9':
            return "nine";
        default:
            return "NaN";
    }
}