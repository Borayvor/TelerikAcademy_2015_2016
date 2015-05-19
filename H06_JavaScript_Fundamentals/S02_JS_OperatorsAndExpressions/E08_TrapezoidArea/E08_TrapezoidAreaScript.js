var task = document.getElementById('task');
task.innerHTML = "8. Write an expression that calculates trapezoid's area by given sides a and b and height h.";

function onButtonClick() {    
    var answer = document.getElementById("answer");

    var sideA = parseInt(document.getElementById("input-a").value);
    var sideB = parseInt(document.getElementById("input-b").value);
    var height = parseInt(document.getElementById("input-h").value);

    var result = (((sideA + sideB) * height) / 2);

    if ((sideA > 0) && (sideB > 0) && (height > 0)) {
        answer.innerHTML = "The trapezoid's area is: " + result;
    }
    else {
        answer.innerHTML = "The side A or B or 'height' can't be less or equal than 0 !";
    }
}