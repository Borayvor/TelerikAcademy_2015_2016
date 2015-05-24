var task = document.getElementById('task');
task.innerHTML = "7. Write a script that finds the index of given element in " +
    "a sorted array of integers by using the binary search algorithm.";

var answer = document.getElementById("answer");
var array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
answer.innerHTML = "Array : [" + array + "]";

function binarySearch(array, value, left, right) {

    if (left > right) // Когато са обходени елементите на масива и търсения елемент не е намерен.
    {                 //  В този случай може да заключим, че търсеният елемент го няма в масива.
        return -1;
    }

    var middle = (left + right) / 2;

    if (array[middle] === value) // Взима средния елемент на масива.
    {                            // Ако средният елемент е търсената стойност, алгоритъма завършва.
        return middle;
    }
    else if (array[middle] > value) // Търсената стойност е по-малка от средният елемент. 
    {                               // В този случай стъпка 1 се повтаря с частта от масива преди средният елемент.
        return binarySearch(array, value, left, middle - 1);
    }
    else // Търсената стойност е по-голяма от средният елемент. 
    {    // В този случай стъпка 1 се повтаря с частта от масива след средният елемент.
        return binarySearch(array, value, middle + 1, right);
    }
}

function onButtonClickPrintAnswer() {
    answer.innerHTML = "Array : [" + array + "]";
    answer.innerHTML += "<br />";

    var element = parseInt(document.getElementById("element-value").value);

    var position = binarySearch(array, element, 0, array.length - 1);

    if (position == -1) {
        answer.innerHTML += "Searched value is absent.";
    }
    else {
        answer.innerHTML += "Searched value is on position: " + position;
    }
}