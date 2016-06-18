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

function solve(args) {
    var numersAsFloatarray = [];
    var numbersCount = args.length;

    for (var i = 0; i < numbersCount; i += 1) {
        numersAsFloatarray[i] = parseFloat(args[i]);
    }

    var min = numersAsFloatarray[0];
    var max = numersAsFloatarray[0];
    var sum = numersAsFloatarray[0];

    for (var index = 1; index < numbersCount; index++) {

        sum += numersAsFloatarray[index];

        if (min > numersAsFloatarray[index]) {
            min = numersAsFloatarray[index];
        }

        if (max < numersAsFloatarray[index]) {
            max = numersAsFloatarray[index];
        }
    }
   
    var avg = sum / numbersCount;

    console.log('min=' + min.toFixed(2));
    console.log('max=' + max.toFixed(2));
    console.log('sum=' + sum.toFixed(2));
    console.log('avg=' + avg.toFixed(2));
}