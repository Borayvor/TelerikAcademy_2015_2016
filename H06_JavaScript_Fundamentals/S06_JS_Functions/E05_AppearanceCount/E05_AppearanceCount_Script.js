var task = document.getElementById('task');
task.innerHTML = "5. Write a function that counts how many times given number " + 
    "appears in given array. Write a test function to check if the function " + 
    "is working correctly.";

function countNumber(array, number) {
    var count = 0;

    for (var index = 0; index < array.length; index++) {
        if (array[index] === number) {
            count++;
        }
    }
    return count;
}

function fillArray() {
    var length = parseInt(document.getElementById("array-length-value").value);

    if (isNaN(length) === true) {
        length = 0;
    }

    var array = new Array(length);

    for (var index = 0; index < array.length; index++) {
        array[index] = Math.floor((Math.random() * 9) + 1);
    }

    return array;
}

function onButtonClickPrintResult() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    var array = fillArray();
    answer.innerHTML += "Array : " + array;
    answer.innerHTML += "<br />";

    var selectedNumber = parseInt(document.getElementById("number-value").value);

    if (selectedNumber > 0 && selectedNumber < 10) {
        var count = countNumber(array, selectedNumber);

        answer.innerHTML += "The number " + selectedNumber + " appears " + count + " times.";
        answer.innerHTML += "<br />";
    }
    else {
        answer.innerHTML += "The number must be in the range [1..9] !";
    }
}