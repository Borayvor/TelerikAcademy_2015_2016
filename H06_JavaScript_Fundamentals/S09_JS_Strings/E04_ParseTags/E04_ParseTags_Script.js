var task = document.getElementById('task');
task.innerHTML = "4. You are given a text. Write a function that changes the text in all regions:";
task.innerHTML += "<upcase>text</upcase> to uppercase.";
task.innerHTML += "<lowcase>text</lowcase> to lowercase";
task.innerHTML += "<mixcase>text</mixcase> to mix casing(random)";

var answer = document.getElementById("answer");

var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>." +
            " We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";

var textForView = "We are &lt;mixcase&gt;living&lt;/mixcase&gt; in a &lt;upcase&gt;yellow " +
    "submarine&lt;/upcase&gt;. We &lt;mixcase&gt;don't&lt;/mixcase&gt; " +
    "have &lt;lowcase&gt;anything&lt;/lowcase&gt; else.";

answer.innerHTML = textForView;

function doUpcase(text) {
    var pattern = "<upcase>";
    var indexStart = text.indexOf(pattern);

    while (indexStart > -1) {
        var substringText = text.substring(indexStart + pattern.length, 
            text.indexOf("</upcase>", indexStart))
        var upperText = substringText.toUpperCase();

        text = text.replace(substringText, upperText);
        indexStart = text.indexOf("<upcase>", indexStart + 1);
    }
    return text;
}

function doMixCase(text) {
    var pattern = "<mixcase>";
    var indexStart = text.indexOf(pattern);

    while (indexStart > -1) {
        var insedeText = text.substring(indexStart + pattern.length, 
            text.indexOf("</mixcase>", indexStart));
        var mixedText = new String(insedeText);

        for (var i = 0; i < mixedText.length ; i++) {
            var randomNumber = Math.floor((Math.random() * 100) + 1);

            if (randomNumber % 2 == 0) {
                mixedText = mixedText.replace(mixedText[i], mixedText[i].toUpperCase())
            }
            else {
                mixedText = mixedText.replace(mixedText[i], mixedText[i].toLowerCase())
            }
        }
        text = text.replace(insedeText, mixedText);
        indexStart = text.indexOf("<mixcase>", indexStart + 1);
    }
    return text;
}

function doLowCase(text) {
    var pattern = "<lowcase>";
    var indexStart = text.indexOf(pattern);

    while (indexStart > -1) {
        var insedeText = text.substring(indexStart + pattern.length, 
            text.indexOf("</lowcase>", indexStart));

        var lowerText = insedeText.toLowerCase();
        text = text.replace(insedeText, lowerText);
        indexStart = text.indexOf("<lowcase>", indexStart + 1);
    }
    return text;
}

function onButtonClickPrintResult() {
    answer.innerHTML = textForView;
    answer.innerHTML += "<br />";

    var newText = text;

    newText = doUpcase(newText);
    newText = doMixCase(newText);
    newText = doLowCase(newText);

    answer.innerHTML += newText;
}