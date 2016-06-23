var task = document.getElementById('task');
task.innerHTML = "7. Write a function that returns the index of the first " + 
    "element in array that is larger than its neighbours or -1, if there’s " + 
    "no such element. Use the function from the previous exercise.";

var answer = document.getElementById("answer");

function fillArray() {
    var array = new Array(10);

    for (var index = 0; index < array.length; index++) {
        array[index] = Math.floor((Math.random() * 9) + 1);
    }
    return array;
}

function checkElement(array) {
    for (var index = 1; index < array.length - 1; index++) {
        var neighborLeft = array[index - 1];
        var neighborRight = array[index + 1];
        var element = array[index];

        if (element > neighborLeft && element > neighborRight) {
            answer.innerHTML += "The first element bigger than its two neighbors :";
            answer.innerHTML += neighborLeft + " < " + element + " > " + neighborRight;

            return index;
        }
    }

    answer.innerHTML += "There’s no such element.";
    return -1;
}

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    var array = fillArray();
    answer.innerHTML += "Array : " + array;
    answer.innerHTML += "<br />";

    answer.innerHTML += "Check for element in the array, bigger than its neighbors.";
    answer.innerHTML += "<br />";
    answer.innerHTML += "Position : " + checkElement(array);
    answer.innerHTML += "<br />";
}


function solve(args) {
    var arr = args[0].split('\n');
    var arrLength = parseInt(arr.shift());
    var index = 0;

    arr = arr[0].split(" ").map(function (num) {
        return parseInt(num);
    });

    function checkElement(array, len, position) {
        var neighborLeft = 0;
        var neighborRight = 0;        

        neighborLeft = array[position - 1];
        neighborRight = array[position + 1];

        if (array[position] > neighborLeft && array[position] > neighborRight) {
            return position;
        }

        return -1;
    }

    for (var i = 0; i < arrLength; i += 1) {

        index = checkElement(arr, arrLength, i);

        if (index > -1){
            return index;
        }
    }

    return index;
}