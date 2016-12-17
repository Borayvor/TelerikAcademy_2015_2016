var task = document.getElementById('task');
task.innerHTML = "2. Write a script that compares two char arrays " +
    "lexicographically (letter by letter).";

function compareTwoArrays(firstArray, secondArray) {

    var areArraysEqual = true;

    if (firstArray.length == secondArray.length) {
        for (var index = 0; index < firstArray.length; index++) {
            if (firstArray[index] !== secondArray[index]) {
                areArraysEqual = false;
                break;
            }
        }
    }
    else {
        areArraysEqual = false;
    }

    answer.innerHTML += "Is array [" + firstArray + "] equal to array [" +
        secondArray + "] ? ---> " + areArraysEqual;
    answer.innerHTML += "<br />";
}

function onButtonClickPrintAnswer() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    compareTwoArrays(["Y", "B", "S", "S"], ["Y", "B", "S", "S"]);
    compareTwoArrays(["Y", "B", "S", "S"], ["Y", "B"]);
    compareTwoArrays(["Y", "B", "S", "S"], ["y", "b", "s", "s"]);
    compareTwoArrays(["Y", "B", "S", "S"], [5, 7, 89, -34]);
}

function solve(args) {
    var arr = args[0].split('\n');
    var arr1 = arr[0];
    var arr2 = arr[1];

    function compareTwoArrays(firstArray, secondArray) {
        // var result = firstArray.localeCompare(secondArray);

        // if (result > 0) {
        //     console.log('>');
        // }
        // else if (result < 0) {
        //     console.log('<');
        // }
        // else {
        //     console.log('=');
        // }

        if (firstArray > secondArray) {
            console.log('>');
        } else if (firstArray < secondArray) {
            console.log('<');
        } else {
            console.log('=');
        }
    }

    compareTwoArrays(arr1, arr2);
}