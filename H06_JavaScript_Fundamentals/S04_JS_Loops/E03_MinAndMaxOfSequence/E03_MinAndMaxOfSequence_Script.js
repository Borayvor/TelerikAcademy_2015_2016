var task = document.getElementById('task');
task.innerHTML = "3. Write a script that finds the max and min number from a sequence of numbersAsString.";

function onButtonClickGetSequence() {
    var answer = document.getElementById("answer");
    var sequence = document.getElementById("sequence-value").value;
    var numbersAsString = sequence.split(" ");
    var numersAsFloat = [];

    for (var i = 0; i < numbersAsString.length; i++) {
        numersAsFloat[i] = parseFloat(numbersAsString[i]);
    }
    
    var minNumber = numersAsFloat[0];
    var maxNumber = numersAsFloat[0];
    var numbersCount = numersAsFloat.length;

    answer.innerHTML = "";

    if (numbersCount > 0) {
        for (var index = 1; index < numbersCount; index++) {

            if (minNumber > numersAsFloat[index]) {
                minNumber = numersAsFloat[index];
            }

            if (maxNumber < numersAsFloat[index]) {
                maxNumber = numersAsFloat[index];
            }
        }
    }
    else {
        answer.innerHTML += "The sequence length must be larger than 0 !";
    }

    answer.innerHTML += "Minmal number is : " + minNumber;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Maximal number is : " + maxNumber;
}