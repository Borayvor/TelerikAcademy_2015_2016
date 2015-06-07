var task = document.getElementById('task');
task.innerHTML = 'Look at console.';

// Write a function that puts the value of an object into the 
// content/attributes of HTML tags.
// Add the function to the String.prototype

String.prototype.bind = function (result, parameters) {
    var regContent,
        regHref,
        regClass,
        prop,
        result = this;

    for (prop in parameters) {
        regContent = new RegExp('(<.*?data-bind-content="' + prop + '".*?>)(.*?)(<\\s*/.*?>)', 'gi');
        regHref = new RegExp('(<.*?data-bind-href="' + prop + '".*?)>', 'gi');
        regClass = new RegExp('(<.*?data-bind-class="(' + prop + ')".*?)>', 'gi');

        result = result.replace(regContent, function (none, opening, content, closing) {
            content = parameters[prop];
            return opening + content + closing;
        })
           .replace(regHref, function (none, contentBeforeClosing) {
               return contentBeforeClosing + ' href="' + parameters[prop] + '">';
           })
            .replace(regClass, function (none, contentBeforeClosing) {
                return contentBeforeClosing + ' class="' + parameters[prop] + '">';
            });
    }

    return result;
};

var str = '<div data-bind-content="name"></div>';
console.log(str);
var newStr = str.bind(str, { name: 'Steven' });
console.log(newStr);
console.log('====================================================');
var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>';
console.log(bindingString);
var newBindingString = bindingString.bind(bindingString, { name: 'Elena', link: 'http://telerikacademy.com' });
console.log(newBindingString);
