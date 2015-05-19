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