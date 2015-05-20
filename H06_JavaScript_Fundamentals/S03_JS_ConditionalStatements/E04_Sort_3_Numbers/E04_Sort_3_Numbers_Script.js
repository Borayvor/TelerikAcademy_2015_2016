var task = document.getElementById('task');
task.innerHTML = "4. Sort 3 real values in descending order using nested if statements.";

function onButtonClickSortDescending() {
    var answer = document.getElementById("answer");

    var firstNumber = parseFloat(document.getElementById("first-number").value);
    var secondNumber = parseFloat(document.getElementById("second-number").value);
    var thirdNumber = parseFloat(document.getElementById("third-number").value);

    if (firstNumber < secondNumber) {
        var variable = firstNumber;
        firstNumber = secondNumber;
        secondNumber = variable;

        if (secondNumber < thirdNumber) {
            variable = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = variable;

            if (firstNumber < secondNumber) {
                variable = firstNumber;
                firstNumber = secondNumber;
                secondNumber = variable;
            }
        }
    }
    else {
        if (secondNumber < thirdNumber) {
            var variable = secondNumber;
            secondNumber = thirdNumber;
            thirdNumber = variable;

            if (firstNumber < secondNumber) {
                variable = firstNumber;
                firstNumber = secondNumber;
                secondNumber = variable;
            }
        }
    }

    answer.innerHTML = "";
    answer.innerHTML += "First variable : " + firstNumber;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Second variable : " + secondNumber;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Thrid variable : " + thirdNumber;
}