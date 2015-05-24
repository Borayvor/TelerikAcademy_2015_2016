var task = document.getElementById('task');
task.innerHTML = "6. Write a script that finds the most frequent number in an array.";

var answer = document.getElementById("answer");
var array = [7, 1, 1, 5, 2, 3, 4, 4, 1, 2, 4, 9, 3, 8];
answer.innerHTML = "Array : " + array;

function onButtonClickPrintAnswer() {
    answer.innerHTML = "Array : " + array;

    var mostFrequent = new Array();
    var count = 0;
    var mostFreqIndex = 0;

    for (var index = 0; index < array.length - 1; index++) {
        var tempCount = 0;

        for (var position = index; position < array.length; position++) {
            if (array[index] === array[position]) {
                tempCount++;
            }
        }

        if (count <= tempCount) {
            mostFrequent[mostFreqIndex] = array[index];
            mostFreqIndex++;
            count = tempCount;
        }
        else {
            mostFreqIndex = 0;
        }
    }
    
    for (var index = 0; index < mostFrequent.length; index++) {
        answer.innerHTML += "<br />";
        answer.innerHTML += mostFrequent[index] + " - " + count + " times";        
    }
}