var task = document.getElementById('task');
task.innerHTML = "5. Write a script that asks for a digit (0-9), and depending on the input, " +
    "shows the digit as a word (in English).  Print “not a digit” in case of invalid input. " +
    "Use a switch statement.";

function onButtonClickNameOfDigit() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    var value = parseInt(document.getElementById("digit").value);

    answer.innerHTML += ("The name (in English) of digit is :  ");
    switch (value) {
        case 0: answer.innerHTML += "zero"; break;
        case 1: answer.innerHTML += "one"; break;
        case 2: answer.innerHTML += "two"; break;
        case 3: answer.innerHTML += "three"; break;
        case 4: answer.innerHTML += "four"; break;
        case 5: answer.innerHTML += "five"; break;
        case 6: answer.innerHTML += "six"; break;
        case 7: answer.innerHTML += "seven"; break;
        case 8: answer.innerHTML += "eight"; break;
        case 9: answer.innerHTML += "nine"; break;
        case 10: answer.innerHTML += "ten"; break;
        default: {
            answer.innerHTML += "<br />";
            answer.innerHTML += "not a digit !"; break;
        }
    }
}

function solve(args) {
    var number = parseFloat(args);
    var numberAsString = '';

   switch (number) {
        case 0: numberAsString = "zero"; break;
        case 1: numberAsString = "one"; break;
        case 2: numberAsString = "two"; break;
        case 3: numberAsString = "three"; break;
        case 4: numberAsString = "four"; break;
        case 5: numberAsString = "five"; break;
        case 6: numberAsString = "six"; break;
        case 7: numberAsString = "seven"; break;
        case 8: numberAsString = "eight"; break;
        case 9: numberAsString = "nine"; break;
        default: {
            numberAsString = "not a digit"; break;
        }
    }

    console.log(numberAsString);    
}