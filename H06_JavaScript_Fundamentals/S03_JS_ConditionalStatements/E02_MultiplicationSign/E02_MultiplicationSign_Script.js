var task = document.getElementById('task');
task.innerHTML = "2. Write a script that shows the sign (+ or -) of the product of three real numbers without" +
            " calculating it. Use a sequence of 'if' statements";

function onButtonClickFindSign() {
    var answer = document.getElementById("answer");
    var firstNumber = parseInt(document.getElementById("first-number").value);
    var secondNumber = parseInt(document.getElementById("second-number").value);
    var thirdNumber = parseInt(document.getElementById("third-number").value);
    var negativeCount = 0;

    if (firstNumber < 0) {
        negativeCount++;
    }

    if (secondNumber < 0) {
        negativeCount++;
    }

    if (thirdNumber < 0) {
        negativeCount++;
    }

    if (negativeCount % 2 === 0) {
        answer.innerHTML = "The product is positive !";
    }
    else {
        answer.innerHTML = "The product is negative !";
    }
}