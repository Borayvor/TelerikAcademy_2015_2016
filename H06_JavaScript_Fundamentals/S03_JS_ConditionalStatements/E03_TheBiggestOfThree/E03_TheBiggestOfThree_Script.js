var task = document.getElementById('task');
task.innerHTML = "3. Write a script that finds the biggest of three numbers. Use nested if statements.";

function onFindBiggestButtonClick() {
    var answer = document.getElementById("answer");
    var firstNumber = parseFloat(document.getElementById("first-number").value);
    var secondNumber = parseFloat(document.getElementById("second-number").value);
    var thirdNumber = parseFloat(document.getElementById("third-number").value);

    var biggestNumber = 0;

    if ((firstNumber == secondNumber) && (secondNumber == thirdNumber)) {
        answer.innerHTML = "All numbers are equal.";
    }
    else {
        if ((firstNumber >= secondNumber) && (firstNumber >= thirdNumber)) {
            biggestNumber = firstNumber;
        }
        if ((secondNumber >= firstNumber) && (secondNumber >= thirdNumber)) {
            biggestNumber = secondNumber;
        }
        if ((thirdNumber >= firstNumber) && (thirdNumber >= secondNumber)) {
            biggestNumber = thirdNumber;
        }
    }
    answer.innerHTML = "The biggest is: " + biggestNumber;
}