var task = document.getElementById('task');
task.innerHTML = "4. Write a script that finds the lexicographically smallest " +
    "and largest property in document, window and navigator objects.";

function onButtonClickFindProperty() {
    var answer = document.getElementById("answer");
    answer.innerHTML = "";

    findSmallestAndLargestProperty(document);

    findSmallestAndLargestProperty(window);

    findSmallestAndLargestProperty(navigator);
}

function findSmallestAndLargestProperty(object) {
    var maxProperty = "aaaa";
    var minProperty = "zzzz";    

    for (var property in object) {

        if (minProperty > property.toLowerCase()) {
            minProperty = property;
        }

        if (maxProperty < property.toLowerCase()) {
            maxProperty = property;
        }
    }

    answer.innerHTML += "The smallest lexicographically property in " + object + " is : " + minProperty;
    answer.innerHTML += "<br />";
    answer.innerHTML += "The biggest lexicographically property in " + object + " is : " + maxProperty;
    answer.innerHTML += "<br />";
}