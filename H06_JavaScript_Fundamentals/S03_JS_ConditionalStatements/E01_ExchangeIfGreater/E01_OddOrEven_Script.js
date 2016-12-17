var task = document.getElementById('task');
task.innerHTML = "1. Write an \"if\" statement that examines two integer variables and" +
    " exchanges their values if the first one is greater than the second one.";

function onButtonClickExchangeValue() {
    var firstNumber = parseInt(document.getElementById("first-number").value);
    var secondNumber = parseInt(document.getElementById("second-number").value);
    var answer = document.getElementById("answer");

    if (firstNumber > secondNumber) {
        var exchangeValue = secondNumber;
        secondNumber = firstNumber;
        firstNumber = exchangeValue;
    }

    answer.innerHTML += "First number : " + firstNumber;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Second number : " + secondNumber;
}

function solve(args) {
    var firstNumber = parseFloat(args[0]);
    var secondNumber = parseFloat(args[1]);

    if (firstNumber > secondNumber) {
        var exchangeValue = secondNumber;
        secondNumber = firstNumber;
        firstNumber = exchangeValue;
    }

    console.log(firstNumber + ' ' + secondNumber);
}