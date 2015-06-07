var task = document.getElementById('task');
task.innerHTML = '11. Write a function that formats a string using placeholders. ' + 
    'The function should work with up to 30 placeholders and all types.';

var answer = document.getElementById("answer");

answer.innerHTML = '"Hello {0}, {1}, {2}, and {0} !", "Peter", "Gogo", "Ivan"';

function stringFormat(str) {
    var selfArguments = arguments;

    return str.replace(/{(\d+)}/g, function (match, placeholder) {
        answer.innerHTML += '{' + placeholder + '} ';
        answer.innerHTML += selfArguments[+ placeholder + 1] + ' ';
        answer.innerHTML += '<br />';

        return selfArguments[+ placeholder + 1];
    })
}

function onButtonClickPrintResult() {
    answer.innerHTML = '"Hello {0}, {1}, {2}, and {0} !", "Peter", "Gogo", "Ivan"';
    answer.innerHTML += '<br />';

    var text = stringFormat("Hello {0}, {1}, {2}, and {0} !", "Peter", "Gogo", "Ivan");

    answer.innerHTML += text;
}