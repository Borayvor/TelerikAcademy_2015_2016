var task = document.getElementById('task');
task.innerHTML = "5. Write a boolean expression for finding if the bit 3 (counting from 0) " +
    "of a given integer is 1 or 0. For 8 bit_3 = 1";

function onButtonClick() {
    var number = parseInt(document.getElementById("input-data").value);
    var answer = document.getElementById("answer");

    var mask = 1 << 3;
    var numberAndMask = number & mask;
    var bit = numberAndMask >> 3;

    if (bit) {
        answer.innerHTML = "Third bit is " + bit;
    }
    else {
        answer.innerHTML = "Third bit is " + bit;
    }
}