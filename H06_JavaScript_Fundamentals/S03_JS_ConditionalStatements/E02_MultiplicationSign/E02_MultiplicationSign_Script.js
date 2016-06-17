var task = document.getElementById('task');
task.innerHTML = "2. Write a script that shows the sign (+ or -) of the product of three real numbers without" +
    " calculating it. Use a sequence of 'if' statements";

function onButtonClickFindSign() {
    var answer = document.getElementById("answer");
    var firstNumber = parseInt(document.getElementById("first-number").value);
    var secondNumber = parseInt(document.getElementById("second-number").value);
    var thirdNumber = parseInt(document.getElementById("third-number").value);

    if (firstNumber != 0 && secondNumber != 0 && thirdNumber != 0) {
        if (firstNumber < 0 && secondNumber < 0 && thirdNumber < 0) {
            canswer.innerHTML = "The product is negative !";
        }
        else if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) {
            answer.innerHTML = "The product is positive !";
        }
        else if ((firstNumber < 0 && secondNumber < 0 && thirdNumber > 0)
            || (firstNumber < 0 && thirdNumber < 0 && secondNumber > 0)
            || (secondNumber < 0 && thirdNumber < 0 && firstNumber > 0)) {
            answer.innerHTML = "The product is positive !";
        }
        else {
            answer.innerHTML = "The product is negative !";
        }
    }
    else {
        answer.innerHTML = "The product is zero !";
    }
}

function solve(args) {
    var firstNumber = parseFloat(args[0]);
    var secondNumber = parseFloat(args[1]);
    var thirdNumber = parseFloat(args[2]);

    if (firstNumber != 0 && secondNumber != 0 && thirdNumber != 0) {
        if (firstNumber < 0 && secondNumber < 0 && thirdNumber < 0) {
            console.log('-');
        }
        else if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) {
            console.log('+');
        }
        else if ((firstNumber < 0 && secondNumber < 0 && thirdNumber > 0)
            || (firstNumber < 0 && thirdNumber < 0 && secondNumber > 0)
            || (secondNumber < 0 && thirdNumber < 0 && firstNumber > 0)) {
            console.log('+');
        }
        else {
            console.log('-');
        }
    }
    else {
        console.log('0');
    }
}