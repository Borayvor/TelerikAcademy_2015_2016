var task = document.getElementById('task');
task.innerHTML = "9. Write an expression that checks for given point (x, y) if it is within" +
            " the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).";

function onButtonClick() {
    var answer = document.getElementById("answer");

    var x = parseInt(document.getElementById("input-x").value);
    var y = parseInt(document.getElementById("input-y").value);

    var checkCircle = ((((x - 1) * (x - 1)) + ((y - 1) * (y - 1))) <= 9);
    var checkRectangle = ((x >= -1 && x <= 5) && (y >= -1 && y <= 1));

    if (checkCircle) {

        if (checkRectangle) {
            answer.innerHTML = "The point is within the circle K((1,1),3) and in rectangle " +
            "R(top = 1, left = -1, width = 6, height = 2).";
            answer.style.backgroundColor = "green";
        }
        else {
            answer.innerHTML = "The point is within the circle K((1,1),3) and out of rectangle " +
            "R(top = 1, left = -1, width = 6, height = 2).";
            answer.style.backgroundColor = "orange";
        }
    }
    else if (checkRectangle) {
        answer.innerHTML = "The point is out of the circle K((1,1),3) and in rectangle " +
            "R(top = 1, left = -1, width = 6, height = 2).";
        answer.style.backgroundColor = "orange";
    }
    else {
        answer.innerHTML = "The point is out of the circle K((1,1),3) and out of rectangle " +
            "R(top = 1, left = -1, width = 6, height = 2).";
        answer.style.backgroundColor = "red";
    }
}