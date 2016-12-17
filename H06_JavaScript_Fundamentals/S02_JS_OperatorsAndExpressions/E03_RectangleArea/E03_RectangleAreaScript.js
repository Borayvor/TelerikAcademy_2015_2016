var task = document.getElementById('task');
task.innerHTML = "3. Write an expression that calculates rectangle’s area by given width and height.";

function onButtonClick() {
    var answer = document.getElementById("answer");

    var width = parseInt(document.getElementById("input-width").value);
    var height = parseInt(document.getElementById("input-height").value);

    if ((width > 0) && (height > 0)) {
        answer.innerHTML = "The rectangle’s area is: " + (width * height);
    }
    else {
        answer.innerHTML = "The height and width can't be less or equal than 0 !";
    }
}

function solve(args) {
    var width = parseFloat(args[0]);
    var height = parseFloat(args[1]);

    console.log((width * height).toFixed(2) + ' ' + (2 * (width + height)).toFixed(2));
}