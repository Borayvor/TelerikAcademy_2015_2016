var task = document.getElementById('task');
task.innerHTML = "2. Write a script that prints all the numbers from 1 to N, that " +
    "are not divisible by 3 and 7 at the same time.";

function onButtonClickGetN() {
    var answer = document.getElementById("answer");
    var nValue = parseInt(document.getElementById("N-value").value);

    answer.innerHTML = "";

    if (nValue > 0) {
        for (var index = 1; index <= nValue; index++) {
            if (index % 21 !== 0) {
                answer.innerHTML += index + ", ";
            }

            if(index % 20 === 0){
                answer.innerHTML += "<br />";
            }
        }
    }
    else {
        answer.innerHTML += "\"N\" must be larger than 0!";
    }
}