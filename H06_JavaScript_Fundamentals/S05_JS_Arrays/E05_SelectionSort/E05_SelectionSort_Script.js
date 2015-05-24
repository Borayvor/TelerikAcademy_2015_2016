var task = document.getElementById('task');
task.innerHTML = "5. Sorting an array means to arrange its elements in increasing order. " + 
    "Write a script to sort an array. Use the selection sort algorithm: Find " + 
    "the smallest element, move it at the first position, find the smallest " + 
    "from the rest, move it at the second position, etc.";

var answer = document.getElementById("answer");
var array = [7, 1, 1, 5, 2, 3, 4, 4, 1, 2, 4, 9, 3, 8];
answer.innerHTML = "Array : " + array;

function onButtonClickPrintAnswer() {
    answer.innerHTML = "Array : " + array;

    var sequence = new Array();
    var count = 0;
    var minValue;

    for (var index = 0; index < array.length - 1; index++) {
        minValue = index;

        for (var jdex = index + 1; jdex < array.length; jdex++) {
            if (array[jdex] < array[minValue]) {
                minValue = jdex;
            }
        }

        if (minValue != index) {
            var temp = array[index];
            array[index] = array[minValue];
            array[minValue] = temp;
        }
    }

    answer.innerHTML += "<br />";
    answer.innerHTML += "Sorted array :  ";

    for (var index = 0; index < array.length; index++) {
        answer.innerHTML += array[index];
        answer.innerHTML += ", "
    }
}