var task = document.getElementById('task');
task.innerHTML = '9. Write a function for extracting all email addresses ' + 
    'from given text. All sub-strings that match the format @… should ' + 
    'be recognized as emails. Return the emails as array of strings.';

var answer = document.getElementById("answer");

answer.innerHTML = 'Look at console !';
var str = "Static void Main() nakov@telerik.com. using System,nakov@gmail.com return";
console.log(str);

function onButtonClickPrintResult() {

    var regExEmail = new RegExp('\\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\\b', "g");

    var matchEmail = str.match(regExEmail);

    console.log(matchEmail);
}