var task = document.getElementById('task');
task.innerHTML = '8. Write a JavaScript function that replaces in a HTML ' +
    'document given as string all the tags &lt;a href="…"&gt;…&lt;/a&gt; ' +
    'with corresponding tags [URL=…]…/URL].';

var answer = document.getElementById("answer");

var htmlFragment = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to' +
            ' choose a training course. Also visit <a href="www.devbg.org">our ' +
            'forum</a> to discuss the courses.</p>';
answer.innerHTML = "Look at console !";
console.log(htmlFragment);
console.log();

function onButtonClickPrintResult() {

    var regExFirstPart = new RegExp('<a href=\"', "g");
    var regExSecondPart = new RegExp('\">', "g");
    var regExThirdPart = new RegExp('</a>', "g");

    var newText = htmlFragment;
    newText = newText.replace(regExFirstPart, '[URL=');
    newText = newText.replace(regExSecondPart, ']');
    newText = newText.replace(regExThirdPart, '[/URL]');

    console.log(newText);
}