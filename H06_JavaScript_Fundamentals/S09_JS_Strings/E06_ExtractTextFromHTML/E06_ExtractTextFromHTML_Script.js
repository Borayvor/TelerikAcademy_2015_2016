var task = document.getElementById('task');
task.innerHTML = "6. Write a function that extracts the content of a html page " + 
    "given as text. The function should return anything that is in a tag, " + 
    "without the tags.";

var answer = document.getElementById("answer");

var testText = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";
answer.innerHTML = 'Look at console.';
console.log(testText);

function extractHtmlContent(text) {

    var newText = '';

    for (var index = 0; index < text.length; index++) {

        if (text[index] == '>') {

            index++;

            while (text[index] != '<' && index < text.length) {

                newText += text[index];
                index++;
            }
        }
    }
    return newText;
}

function onButtonClickPrintResult() {

    console.log(extractHtmlContent(testText));
}

//// =================================================================== ////

function solve(args) {
    var newText = '';
    var len = args.length;
    var matchTags = /<.*?>/ig;

    for (var i = 0; i < len; i += 1) {
        newText += args[i].replace(matchTags, '').trim();
    }

    console.log(newText);
}
