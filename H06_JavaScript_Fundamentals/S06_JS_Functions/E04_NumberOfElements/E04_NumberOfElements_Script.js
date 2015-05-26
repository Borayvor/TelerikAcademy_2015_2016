var task = document.getElementById('task');
task.innerHTML = "4. Write a function to count the number of div elements on the web page.";

function onButtonClickPrintResult() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    var count = document.getElementsByTagName("div").length;

    answer.innerHTML += 'The number of "div" in this page is : ' + count;
}