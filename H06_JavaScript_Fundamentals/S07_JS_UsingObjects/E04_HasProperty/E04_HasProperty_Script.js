var task = document.getElementById('task');
task.innerHTML = "4. Write a function that checks if a given object contains a given property.";

var answer = document.getElementById("answer");
answer.innerHTML = "student(firstName, lastName, age, marks)";

function hasProperty(object, propertyDesired) {

    for (var property in object) {

        if (property == propertyDesired) {
            return true;
        }
    }
    return false;
}

var student = {
    firstName : 'Gogo',
    lastName : 'Peshov',
    age : 21,
    marks : 6.0
};

function onButtonClickPrintResult() {
    answer.innerHTML = "student(firstName, lastName, age, marks)";
    answer.innerHTML += "<br />";

    var hasPropertyStudent = hasProperty(student, "lastName");
    answer.innerHTML += "Check for \"lastName\" in \"student\" : " + hasPropertyStudent;
    answer.innerHTML += "<br />";

    var hasPropertyStudent = hasProperty(student, "family");
    answer.innerHTML += "Check for \"family\" in \"student\" : " + hasPropertyStudent;
}