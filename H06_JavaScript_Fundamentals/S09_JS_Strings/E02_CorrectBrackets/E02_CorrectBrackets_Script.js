var task = document.getElementById('task');
task.innerHTML = "2. Write a JavaScript function to check if in a given " +
    "expression the brackets are put correctly.";

var answer = document.getElementById("answer");

function CheckBrackets(string) {
    var stack = 0;

    for (var index = 0; index < string.length && stack >= 0; index++) {
        if (string[index] == '(') stack++;
        if (string[index] == ')') stack--;
    }

    return stack === 0;
}

function onButtonClickPrintResult() {
    answer.innerHTML = "";
    answer.innerHTML += "((a + b) / 5 - d)  ==> " + CheckBrackets("((a + b) / 5 - d)");
    answer.innerHTML += "<br />";
    answer.innerHTML += "))(a+b)  ==> " + CheckBrackets("))(a+b)");
    answer.innerHTML += "<br />";
    answer.innerHTML += "(a+b))(  ==> " + CheckBrackets("(a+b))(");
    answer.innerHTML += "<br />";
    answer.innerHTML += "(a+b)((  ==> " + CheckBrackets("(a+b)((");
}

function solve(args) {
    function checkBrackets(str) {
        var stack = 0,
            len = str.length;

        for (var index = 0; index < len && stack >= 0; index++) {
            if (str[index] == '(') stack++;
            if (str[index] == ')') stack--;
        }

        return stack === 0;
    }

    var result = checkBrackets(args[0]) === true ? "Correct" : "Incorrect";

    return result;
}