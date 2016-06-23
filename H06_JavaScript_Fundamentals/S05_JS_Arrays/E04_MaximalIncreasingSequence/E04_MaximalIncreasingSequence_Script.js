var task = document.getElementById('task');
task.innerHTML = "4. Write a script that finds the maximal increasing sequence in an array.";

var answer = document.getElementById("answer");
var array = [3, 2, 3, 4, 2, 2, 4];
answer.innerHTML = "Array : " + array;

function onButtonClickPrintAnswer() {
    answer.innerHTML = "Array : " + array;

    var sequence = new Array();
    var count = 0;

    for (var value = 0; value < array.length - 1; value++) {
        var size = 0;

        for (var index = value; index < array.length; index++) {
            if (array[value] + size == (array[index])) {
                size++;
            }
            else {
                break;
            }
        }

        if ((count <= size) && (array[value + 1] - array[value] == 1) &&
            ((sequence[0] <= array[value]) || (sequence[0] == null))) {
            count = size;
            sequence = [];

            for (var index = value, seqIndex = 0; index < (value + count); index++ , seqIndex++) {
                sequence[seqIndex] = array[index];
            }
        }
    }

    answer.innerHTML += "<br />";
    answer.innerHTML += "| ";

    for (var index = 0; index < sequence.length; index++) {
        answer.innerHTML += sequence[index] + " | ";
    }

    answer.innerHTML += "- is the maximal increasing sequence in the array.";
}

function solve(args) {
    var array = args[0].split('\n').map(function(num){
        return parseInt(num, 10);
    });
    var arrLength = array.shift();
    
    var countIncreasingMembers = 0;
    var sequenceMaxLength = 0;    
    var index = 0;

    for (index = 1; index < arrLength; index += 1) {
        if (array[index] > array[index - 1]) {
            countIncreasingMembers++;

            if (sequenceMaxLength < countIncreasingMembers) {
                sequenceMaxLength = countIncreasingMembers;                
            }
        }
        else {            
            countIncreasingMembers = 0;
        }
    }

    if (sequenceMaxLength !== 0){
        console.log(sequenceMaxLength + 1);
    }    
    else {
        console.log(sequenceMaxLength);
    }
}