var task = document.getElementById('task');
task.innerHTML = "3. Write a function that finds all the occurrences of word in a text. " + 
    "The search can be case sensitive or case insensitive. " + 
    "Use function overloading.";

var answer = document.getElementById("answer");
var text = "We are living in an yellow submarine. In the sky there are no clouds. So we" +
            " are drinking all the day. We'll move out of it in 5 days.";

var word = "we";

answer.innerHTML += "Text : " + text;
answer.innerHTML += "<br />";
answer.innerHTML += "Word : " + word;
answer.innerHTML += "<br />";

function SearchWordInText(text, word, isCaseSensitive) {    

    if (isCaseSensitive === true) {
        regEx = new RegExp('\\b' + word + '\\b', "g");
    }
    else {
        var regEx = new RegExp('\\b' + word + '\\b', "gi");
    }
    return text.match(regEx);
}

function onButtonClickPrintResult() {
    answer.innerHTML = "Text : " + text;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Word : " + word;
    answer.innerHTML += "<br />";

    var matchWordCaseSensitive = SearchWordInText(text, word, true);
    answer.innerHTML += "Case sensitive : " + matchWordCaseSensitive;

    answer.innerHTML += "<br />";

    var matchWordCaseInsensitive = SearchWordInText(text, word);
    answer.innerHTML += "Case insensitive : " + matchWordCaseInsensitive;
}