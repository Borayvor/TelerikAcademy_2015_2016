var task = document.getElementById('task');
task.innerHTML = "6. Write a function that checks if the element at given " +
    "position in given array of integers is bigger than its two " + 
    "neighbours (when such exist).";

var answer = document.getElementById("answer");

function fillArray() {
    var length = parseInt(document.getElementById("array-length-value").value);

    var array = new Array(length);

    for (var index = 0; index < array.length; index++) {
        array[index] = Math.floor((Math.random() * 9) + 1);
    }

    return array;
}

function checkElement(array, position) {
    if (position > 0 && position < (array.length - 1)) {
        var neighborLeft = array[position - 1];
        var neighborRight = array[position + 1];
        var leftSign = "";
        var rightSign = "";

        if (array[position] > neighborLeft && array[position] > neighborRight) {
            answer.innerHTML += "The element at position " + position + 
                " is bigger than its two neighbors:  ";
            answer.innerHTML += neighborLeft + " < " + array[position] + 
                " > " + neighborRight;
        }
        else {
            answer.innerHTML += "There is no such element !";
        }
    }
    else {
        answer.innerHTML += "One of neighbors does not exist !";
    }
}

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    var array = fillArray();
    answer.innerHTML += "Array : " + array;
    answer.innerHTML += "<br />";

    var position = parseInt(document.getElementById("position-value").value);

    if (position >= 0 && position < array.length) {

        checkElement(array, position);
        answer.innerHTML += "<br />";
    }
    else {
        answer.innerHTML += "The value of position must be in the range [0.." + 
            (array.length - 1) + "] !";
    }
}