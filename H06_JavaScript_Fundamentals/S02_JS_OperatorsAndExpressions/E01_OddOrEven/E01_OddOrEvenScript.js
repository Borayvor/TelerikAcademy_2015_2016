var task = document.getElementById('task');
task.innerHTML = "1. Write an expression that checks if given integer is odd or even.";

function onButtonClick() {
    var number = parseInt(document.getElementById("input-data").value);
    var answer = document.getElementById("answer");    

    if (number % 2 === 0) {
        answer.innerHTML = "The number " + number + " is even.";        
    }
    else {
        answer.innerHTML = "The number " + number + " is odd.";        
    }
}

function solve(args) {
    var number = parseInt(args);

    if (number % 2 === 0) {
        console.log('even ' + number);
    }
    else {
        console.log('odd ' + number);
    }
}