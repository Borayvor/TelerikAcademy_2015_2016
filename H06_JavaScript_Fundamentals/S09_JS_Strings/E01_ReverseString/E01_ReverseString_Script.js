var task = document.getElementById('task');
task.innerHTML = "1. Write a JavaScript function that reverses a string and returns it.";

var answer = document.getElementById("answer");

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    var originalString = document.getElementById('string-value').value;
    var reversedString = '';

    for (var index = originalString.length - 1; index >= 0 ; index--) {

        reversedString += originalString[index];
    }

    answer.innerHTML += "Original string :  " + originalString;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Reversed string :  " + reversedString;
}

function solve(args) {    
    var reversedString = '',
        len = args[0].length;

    for (var index = len - 1; index >= 0 ; index--) {

        reversedString += args[0][index];
    }

    return reversedString;
}