var task = document.getElementById('task');
task.innerHTML = "5. Write a function that replaces non breaking white-spaces " + 
    "in a text with '& nbsp;'";

var answer = document.getElementById("answer");

var testText = "Write a function that extracts the content of a html page given as text. The" +
            " function should return anything that is in a tag, without the tags.";

answer.innerHTML = testText;

function replaceWhiteSpaces(text, simbol) {

    var newText = '';
    var matchSpace = new RegExp("\\s", "g");

    newText = text.replace(matchSpace, simbol);

    return newText;
}

function onButtonClickPrintResult() {
    answer.innerHTML = testText;
    answer.innerHTML += "<br />";

    var replacedText = replaceWhiteSpaces(testText, "&nbsp;");

    answer.innerHTML += "Look at console !";
    console.log(replacedText);
}