var task = document.getElementById('task');
task.innerHTML = "7. Write a script that finds the greatest of given 5 variables. " +
    " Use nested if statements.";

function getGreatest(first, second) {
    var greatest = 0;

    if (first > second) {
        greatest = first;
    }
    else {
        greatest = second;
    }
    return greatest;
}

function onButtonClickFindGreatest() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    var firstVariable = parseFloat(document.getElementById("first-variable").value);
    var secondVariable = parseFloat(document.getElementById("second-variable").value);
    var thirdVariable = parseFloat(document.getElementById("third-variable").value);
    var fourthVariable = parseFloat(document.getElementById("fourth-variable").value);
    var fifthVariable = parseFloat(document.getElementById("fifth-variable").value);

    var greatest = firstVariable;
    greatest = getGreatest(greatest, secondVariable);
    greatest = getGreatest(greatest, thirdVariable);
    greatest = getGreatest(greatest, fourthVariable);
    greatest = getGreatest(greatest, fifthVariable);

    answer.innerHTML += "The greatest of given five variables is : " + greatest;
}

function solve(args) {
    var firstVariable = parseFloat(args[0]);
    var secondVariable = parseFloat(args[1]);
    var thirdVariable = parseFloat(args[2]);
    var fourthVariable = parseFloat(args[3]);
    var fifthVariable = parseFloat(args[4]);

    function getGreatest(first, second) {
        var greatest = 0;

        if (first > second) {
            greatest = first;
        }
        else {
            greatest = second;
        }
        return greatest;
    }

    var greatest = firstVariable;
    greatest = getGreatest(greatest, secondVariable);
    greatest = getGreatest(greatest, thirdVariable);
    greatest = getGreatest(greatest, fourthVariable);
    greatest = getGreatest(greatest, fifthVariable);

    console.log(greatest);
}