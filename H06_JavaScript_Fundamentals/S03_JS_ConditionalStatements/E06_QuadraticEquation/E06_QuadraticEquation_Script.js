﻿var task = document.getElementById('task');
task.innerHTML = "6. Write a script that reads the coefficients a, b and c of a quadratic " +
    "equation ax2 + bx + c = 0 and solves it (prints its real roots). " +
    "Calculates and prints its real roots.";

function onButtonClickQuadraticEquation() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    var a = parseFloat(document.getElementById("a-number").value);
    var b = parseFloat(document.getElementById("b-number").value);
    var c = parseFloat(document.getElementById("c-number").value);

    answer.innerHTML = a + "(x * x) + " + b + "x + " + c + " = 0";
    answer.innerHTML += "<br />";

    var D = (b * b) - (4 * a * c);

    if (D >= 0) {
        var x1 = (-b + Math.sqrt(D)) / (2 * a);

        var x2 = (-b - Math.sqrt(D)) / (2 * a);

        answer.innerHTML += "The real roots are : ";
        answer.innerHTML += " x1 = " + x1;
        answer.innerHTML += "; x2 = " + x2;
    }
    else {
        answer.innerHTML += "There are  no real roots.";
    }
}