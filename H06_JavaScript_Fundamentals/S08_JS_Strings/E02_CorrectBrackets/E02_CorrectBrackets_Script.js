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

    return stack == 0;
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