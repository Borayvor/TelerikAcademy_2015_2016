var task = document.getElementById('task');
task.innerHTML = "6. Write an expression that checks if given print (x,  y) is within a circle K(O, 5).";

function onButtonClick() {
    var answer = document.getElementById("answer");

    var x = parseInt(document.getElementById("input-x").value);
    var y = parseInt(document.getElementById("input-y").value);

    if (((x * x) + (y * y)) <= 25) {
        answer.innerHTML = "The point is within the circle K(0, 5).";
        answer.style.backgroundColor = "green";
    }
    else {
        answer.innerHTML = "The point is out of the circle K(0, 5).";
        answer.style.backgroundColor = "red";
    }
}

function solve(args) {
    var x = parseFloat(args[0]);
    var y = parseFloat(args[1]);

    var distance = Math.sqrt((x * x) + (y * y));

    if (distance <= 25) {
        console.log('yes ' + distance.toFixed(2));
    }
    else {
        console.log('no ' + distance.toFixed(2));
    }
}