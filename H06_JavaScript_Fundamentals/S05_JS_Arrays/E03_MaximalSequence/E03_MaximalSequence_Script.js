var task = document.getElementById('task');
task.innerHTML = "3. Write a script that finds the maximal sequence of equal elements in an array.";

var answer = document.getElementById("answer");
var array = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1];
answer.innerHTML = "Array : " + array;

function onButtonClickPrintAnswer() {
    answer.innerHTML = "Array : " + array;
    var sequence = new Array();
    var count = 0;

    for (var value = 0; value < array.length - 1; value++) {

        var size = 0;

        for (var index = value; index < array.length; index++) {

            if (array[value] === (array[index])) {
                size++;
            }
            else {
                break;
            }
        }

        if ((count < size) && (array[value] === (array[value + 1]))) {

            count = size;
            sequence = [];

            for (var index = value, seqIndex = 0; index < (value + count) ; index++, seqIndex++) {
                sequence[seqIndex] = array[index];
            }
        }
        else if (count == size) {

            for (var index = value, seqIndex = 0; index < value + count; index++, seqIndex++) {
                sequence[seqIndex] = array[index];
            }
        }
    }

    answer.innerHTML += "<br />";

    answer.innerHTML += "| ";
    for (var index = 0; index < sequence.length; index++) {

        answer.innerHTML += sequence[index] + " | ";

        if ((index + 1) % count == 0) {

            answer.innerHTML += " - the maximal sequence of equal elements in the array.";
        }
    }

    answer.innerHTML += "<br />";
}