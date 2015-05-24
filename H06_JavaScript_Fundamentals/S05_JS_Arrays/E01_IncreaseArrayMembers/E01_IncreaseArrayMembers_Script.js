var task = document.getElementById('task');
task.innerHTML = "1. Write a script that allocates array of 20 integers and " + 
    "initializes each element by its index multiplied by 5. " + 
    "Print the obtained array on the console.";

function onButtonClickPrintArray() {
    var answer = document.getElementById("answer");
    var array = new Array(20);

    answer.innerHTML = "";

    for (var index = 0; index < array.length; index++) {
        array[index] = index * 5;
        answer.innerHTML += "array[" + index + "] = " + array[index];
        answer.innerHTML += "<br />";
    }
}