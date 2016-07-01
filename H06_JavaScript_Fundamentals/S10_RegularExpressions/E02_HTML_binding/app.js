// var task = document.getElementById('task');
// task.innerHTML = 'Look at console.';

// // Write a function that puts the value of an object into the 
// // content/attributes of HTML tags.
// // Add the function to the String.prototype

// String.prototype.bind = function (result, parameters) {
//     var regContent,
//         regHref,
//         regClass,
//         prop,
//         result = this;

//     for (prop in parameters) {
//         regContent = new RegExp('(<.*?data-bind-content="' + prop + '".*?>)(.*?)(<\\s*/.*?>)', 'gi');
//         regHref = new RegExp('(<.*?data-bind-href="' + prop + '".*?)>', 'gi');
//         regClass = new RegExp('(<.*?data-bind-class="(' + prop + ')".*?)>', 'gi');

//         result = result.replace(regContent, function (none, opening, content, closing) {
//             content = parameters[prop];
//             return opening + content + closing;
//         })
//            .replace(regHref, function (none, contentBeforeClosing) {
//                return contentBeforeClosing + ' href="' + parameters[prop] + '">';
//            })
//             .replace(regClass, function (none, contentBeforeClosing) {
//                 return contentBeforeClosing + ' class="' + parameters[prop] + '">';
//             });
//     }

//     return result;
// };

// var str = '<div data-bind-content="name"></div>';
// console.log(str);
// var newStr = str.bind(str, { name: 'Steven' });
// console.log(newStr);
// console.log('====================================================');
// var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>';
// console.log(bindingString);
// var newBindingString = bindingString.bind(bindingString, { name: 'Elena', link: 'http://telerikacademy.com' });
// console.log(newBindingString);


//// ===================================================== ////

function solve(args) {
    var options = JSON.parse(args[0]);
    var inputStr = args[1];

    String.prototype.bind = function (parameters) {
        var regExContent,
            regExAttrs = [],
            prop,
            result = this,
            contentBefore = result.split('>')[0],
            testRegEx = new RegExp('.*?data-bind-(.*?)=.*?', 'gi'),
            dataBinds = contentBefore.split('<')[1].split(' '),
            tempContent = '';

        dataBinds.shift();

        var matches, dataBindNames = [];
        while (matches = testRegEx.exec(contentBefore)) {
            dataBindNames.push(matches[1]);
        }

        for (prop in parameters) {
            regExContent = new RegExp('(<.*?data-bind-content="' + prop + '".*?>)(.*?)(</.*?>)', 'g');

            result = result
                .replace(regExContent, function (none, opening, content, closing) {
                    content = parameters[prop];
                    var res = opening + content + closing;
                    return res;
                });

            for (var i = 0; i < dataBindNames.length; i += 1) {
                regExAttrs[i] = new RegExp('(<.*?(data-bind-' + dataBindNames[i] + '="' + prop + '").*?)>', 'g');

                result = result
                    .replace(regExAttrs[i], function (none, test, currentDataBind) {
                        var res = none;

                        for (var j =  0; j < dataBinds.length; j += 1) {
                            if (dataBinds[j] === currentDataBind &&
                                dataBinds[j] !== 'data-bind-content="name"') {
                                contentBefore += ' ' + dataBindNames[i] + '="' + parameters[prop] + '"';
                                res = contentBefore + '>';
                            }
                        }

                        return res;
                    });
            }
        }

        return result;
    };

    return inputStr.bind(options);
}

solve([
    '{ "name": "Elena", "link": "http://telerikacademy.com" }',
    '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>'
]);
