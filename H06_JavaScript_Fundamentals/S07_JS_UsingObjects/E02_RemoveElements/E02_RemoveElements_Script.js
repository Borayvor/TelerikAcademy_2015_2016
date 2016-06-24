var task = document.getElementById('task');
task.innerHTML = "2.  Write a function that removes all elements with a given value. " +
    "Attach it to the array type. Read about prototype and how to attach methods.";

var answer = document.getElementById("answer");

Array.prototype.remove = function (element) {

    var newArray = [];
    var length = this.length;

    for (var index = 0; index < length; index++) {

        if (this[index] !== element) {

            newArray.push(this[index]);
        }
    }
    return newArray;
};

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    var array = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];
    answer.innerHTML += "Array : " + array;
    answer.innerHTML += "<br />";

    var arrayAfterRemove = array.remove(1);
    answer.innerHTML += "Array after \"remove(1)\", remove all integers : " + arrayAfterRemove;
}

//// ============================================================================ ////

function solve(args) {
    Array.prototype.remove = function (element) {
        var newArray = [];
        var length = this.length;

        for (var index = 0; index < length; index++) {
            if (this[index] !== element) {
                newArray.push(this[index]);
            }
        }

        return newArray;
    };

    var result = args.remove(args[0]).join('\n');

    console.log(result);
}