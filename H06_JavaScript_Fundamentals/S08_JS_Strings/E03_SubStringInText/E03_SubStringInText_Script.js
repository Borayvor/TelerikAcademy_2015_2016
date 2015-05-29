var task = document.getElementById('task');
task.innerHTML = "3. Write a JavaScript function that finds how many times a " +
    "substring is contained in a given text (perform case insensitive search).";

var answer = document.getElementById("answer");

var text = "We are living in an yellow submarine. We don't have anything else. " +
    "Inside the submarine is very tight. So we are drinking all the day. We " +
    "will move out of it in 5 days";

answer.innerHTML = text;
var substring = "in";
answer.innerHTML += "<br />";
answer.innerHTML += "The substring is:  " + substring;

function checkForSubstring(textString, substring, isCaseSensitive) {

    var regEx = new RegExp(substring, "gi");
   
    return textString.match(regEx).length;
}

function onButtonClickPrintResult() {
    answer.innerHTML = text;
    answer.innerHTML += "<br />";

    answer.innerHTML += "The substring is:  " + substring;
    answer.innerHTML += "<br />";

    var matchSubstringInText = checkForSubstring(text, substring, true);

    answer.innerHTML += "The result is : " + matchSubstringInText;
}