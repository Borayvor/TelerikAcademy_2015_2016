// var task = document.getElementById('task');
// task.innerHTML = "4. You are given a text. Write a function that changes the text in all regions:";
// task.innerHTML += "<upcase>text</upcase> to uppercase.";
// task.innerHTML += "<lowcase>text</lowcase> to lowercase";
// task.innerHTML += "<mixcase>text</mixcase> to mix casing(random)";

// var answer = document.getElementById("answer");

// var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>." +
//     " We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";

// var textForView = "We are &lt;mixcase&gt;living&lt;/mixcase&gt; in a &lt;upcase&gt;yellow " +
//     "submarine&lt;/upcase&gt;. We &lt;mixcase&gt;don't&lt;/mixcase&gt; " +
//     "have &lt;lowcase&gt;anything&lt;/lowcase&gt; else.";

// answer.innerHTML = textForView;

// function doUpcase(text) {
//     var pattern = "<upcase>";
//     var indexStart = text.indexOf(pattern);

//     while (indexStart > -1) {
//         var substringText = text.substring(indexStart + pattern.length,
//             text.indexOf("</upcase>", indexStart))
//         var upperText = substringText.toUpperCase();

//         text = text.replace(substringText, upperText);
//         indexStart = text.indexOf("<upcase>", indexStart + 1);
//     }
//     return text;
// }

// function doMixCase(text) {
//     var pattern = "<mixcase>";
//     var indexStart = text.indexOf(pattern);

//     while (indexStart > -1) {
//         var insedeText = text.substring(indexStart + pattern.length,
//             text.indexOf("</mixcase>", indexStart));
//         var mixedText = new String(insedeText);

//         for (var i = 0; i < mixedText.length; i++) {
//             var randomNumber = Math.floor((Math.random() * 100) + 1);

//             if (randomNumber % 2 === 0) {
//                 mixedText = mixedText.replace(mixedText[i], mixedText[i].toUpperCase())
//             }
//             else {
//                 mixedText = mixedText.replace(mixedText[i], mixedText[i].toLowerCase())
//             }
//         }
//         text = text.replace(insedeText, mixedText);
//         indexStart = text.indexOf("<mixcase>", indexStart + 1);
//     }
//     return text;
// }

// function doLowCase(text) {
//     var pattern = "<lowcase>";
//     var indexStart = text.indexOf(pattern);

//     while (indexStart > -1) {
//         var insedeText = text.substring(indexStart + pattern.length,
//             text.indexOf("</lowcase>", indexStart));

//         var lowerText = insedeText.toLowerCase();
//         text = text.replace(insedeText, lowerText);
//         indexStart = text.indexOf("<lowcase>", indexStart + 1);
//     }
//     return text;
// }

// function onButtonClickPrintResult() {
//     answer.innerHTML = textForView;
//     answer.innerHTML += "<br />";

//     var newText = text;

//     newText = doUpcase(newText);
//     newText = doMixCase(newText);
//     newText = doLowCase(newText);

//     answer.innerHTML += newText;
// }

//// ========================================================================= ////




// function solve(args) {
//     var text = args[0],
//         inTag = false,
//         currentTag = '',
//         tags = [],
//         result = [];

//     for (var i = 0; i < text.length; i++) {
//         if (text[i] === '<') {
//             inTag = true;
//         } else if (text[i] === '>' && inTag) {
//             inTag = false;
//             currentTag += text[i];
//             tags.push(currentTag);
//             currentTag = '';
//         } else if (!inTag) {
//             if (tags.length === 0) {
//                 result.push(text[i]);
//             } else if (tags[tags.length - 1].indexOf('upcase') !== -1) {
//                 result.push(text[i].toUpperCase());
//             } else if (tags[tags.length - 1].indexOf('lowcase') !== -1) {
//                 result.push(text[i].toLowerCase());
//             } else {
//                 result.push(text[i]);
//             }
//         }

//         if (inTag || text[i] === '>') {
//             currentTag += text[i];
//         }

//         if (tags.length !== 0 && tags[tags.length - 1].indexOf('</') !== -1) {
//             tags.pop();
//             tags.pop();
//         }
//     }

//     console.log(result.join(''));
// }










function solve(args) {

    function doNotChange(text) {
        var tagOpen = "<orgcase>",
            tagClose = "</orgcase>";

        var tagRegExOpen = new RegExp(tagOpen, "gi"),
            tagRegExClose = new RegExp(tagClose, "gi");

        text = text.replace(tagRegExOpen, '');
        text = text.replace(tagRegExClose, '');

        return text;
    }

    function doUpcase(text) {
        var tagOpen = "<upcase>",
            tagClose = "</upcase>",
            tagOpenLength = tagOpen.length,
            tagCloseLength = tagClose.length;

        var tagRegExOpen = new RegExp(tagOpen, "gi"),
            tagRegExClose = new RegExp(tagClose, "gi");

        var indexStart = text.indexOf(tagOpen);

        while (indexStart > -1) {
            var substringText = text.substring(indexStart,
                text.indexOf(tagClose, indexStart));
            var upperText = substringText.toUpperCase();

            text = text.replace(substringText, upperText);
            indexStart = text.indexOf(tagOpen, indexStart + 1);
        }

        text = text.replace(tagRegExOpen, '');
        text = text.replace(tagRegExClose, '');

        return text;
    }

    function doLowCase(text) {
        var tagOpen = "<lowcase>",
            tagClose = "</lowcase>",
            tagOpenLength = tagOpen.length,
            tagCloseLength = tagClose.length;

        var tagRegExOpen = new RegExp(tagOpen, "gi"),
            tagRegExClose = new RegExp(tagClose, "gi");

        var indexStart = text.indexOf(tagOpen);        

        while (indexStart > -1) {
            var substringText = text.substring(indexStart,
                text.indexOf(tagClose, indexStart));
            var lowerText = substringText.toLowerCase();

            text = text.replace(substringText, lowerText);
            indexStart = text.indexOf(tagOpen, indexStart + 1);
        }

        text = text.replace(tagRegExOpen, '');
        text = text.replace(tagRegExClose, '');

        return text;
    }

    var newText = args[0];

    newText = doNotChange(newText);
    newText = doUpcase(newText);
    newText = doLowCase(newText);

    return newText;
}


solve(['We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t <upcase>anything <lowcase>yellow <upcase>yellow submarine</upcase> submarine</lowcase> </upcase> </orgcase> have <lowcase>anything <orgcase>liViNg<upcase>yellow submarine</upcase></orgcase></lowcase> else.']);

