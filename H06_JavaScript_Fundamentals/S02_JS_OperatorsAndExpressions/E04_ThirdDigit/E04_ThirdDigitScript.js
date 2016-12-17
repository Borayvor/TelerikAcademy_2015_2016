var task = document.getElementById('task');
task.innerHTML = "4. Write an expression that checks for given integer if its third digit" +
    " (right-to-left) is 7. E. g. 1732  true.";

function onButtonClick() {
    var number = parseInt(document.getElementById("input-data").value);
    var answer = document.getElementById("answer");

    if (number < 0) {
        number *= -1;
    }

    var thirdDigit = ((number % 1000) / 100) - 7;

    if (thirdDigit >= 0 && thirdDigit < 1) {
        answer.innerHTML = "The third digit (right-to-left) is 7.";
    }
    else {
        answer.innerHTML = "The third digit (right-to-left) is not 7.";
    }
}

function solve(args) {
    var number = parseInt(args);

    if (number < 0) {
        number *= -1;
    }

    var thirddigit = Math.floor((number % 1000) / 100);

    console.log(thirddigit === 7 ? 'true' : ('false ' + thirddigit));
}