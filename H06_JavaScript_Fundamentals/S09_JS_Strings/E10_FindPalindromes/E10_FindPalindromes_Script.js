var task = document.getElementById('task');
task.innerHTML = '10. Write a program that extracts from a given text ' +
    'all palindromes, e.g. "ABBA", "lamal", "exe".';

var answer = document.getElementById("answer");

var text = "Static void Main() ABBA, using System lamal, exe.";
answer.innerHTML = text;

function isPalindrome(text) {
    for (var index = 0; index < text.length / 2; index++) {
        if (text[index] != text[text.length - 1 - index]) {
            return false;
        }
    }
    return true;
}

function onButtonClickPrintResult() {
    answer.innerHTML = text;
    answer.innerHTML += '<br />';

    var regEx = new RegExp('\\w+', "g");
    var textMatch = text.match(regEx);

    for (var item in textMatch) {
        if (isPalindrome(textMatch[item])) {
            answer.innerHTML += 'Palindrome : ' + textMatch[item];
            answer.innerHTML += '<br />';
        }
    }
}