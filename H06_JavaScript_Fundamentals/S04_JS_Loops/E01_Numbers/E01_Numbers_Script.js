var task = document.getElementById('task');
task.innerHTML = "1. Write a script that prints all the numbers from 1 to N.";

function onButtonClickGetN() {
    var answer = document.getElementById("answer");
    var nValue = parseInt(document.getElementById("N-value").value);

    answer.innerHTML = "";

    if (nValue > 0) {
        for (var index = 1; index <= nValue; index++) {
            answer.innerHTML += index + ", ";
        }
    }
    else {
        answer.innerHTML += "\"N\" must be larger than 0 !";
    }
}

function solve(args) {
    var number = parseInt(args);
    var result = '';    

    for (var index = 1; index <= number; index++) {
        if (index === number){
            result += index;
            break;
        }
        
        result += index + " ";
    }

    console.log(result);
}