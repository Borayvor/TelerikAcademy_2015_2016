var task = document.getElementById('task');
task.innerHTML = "2. Write a function that reverseDigitss the digits of given decimal number.";

function reverseDigits(value) {
    var result = 0;

    while (value !== 0) {
        // измества получената цифра в ляво и прибавя следващата
        result = (result * 10) + (parseInt(value % 10));
        value = parseInt(value / 10);
    }
    return result;
}

function onButtonClickPrintResult() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    var decimalNumber = parseInt(document.getElementById("number-value").value);

    if (isNaN(decimalNumber) === false) {
        var reverseDigitsNumber = reverseDigits(decimalNumber);
    }

    answer.innerHTML += "The reverseDigitsd number is : " + reverseDigitsNumber;
}