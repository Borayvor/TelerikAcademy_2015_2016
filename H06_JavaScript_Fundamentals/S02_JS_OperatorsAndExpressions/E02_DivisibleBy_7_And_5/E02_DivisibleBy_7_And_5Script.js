var task = document.getElementById('task');
task.innerHTML = "2. Write a boolean expression that checks for given integer if it can" +
            "be divided (without remainder) by 7 and 5 in the same time.";

function onButtonClick() {
    var number = parseInt(document.getElementById("input-data").value);
    var answer = document.getElementById("answer");
    answer.style.color = "white";

    if (number % 35 === 0) {
        answer.innerHTML = "The number " + number +
            " can be divided (without remainder) by 7 and 5 in the same time.";
        answer.style.backgroundColor = "green";
    }
    else {
        answer.innerHTML = "The number " + number +
            " can't be divided (without remainder) by 7 and 5 in the same time.";
        answer.style.backgroundColor = "red";
    }
}