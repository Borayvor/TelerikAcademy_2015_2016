var task = document.getElementById('task');
task.innerHTML = "3. Write a function that makes a deep copy of an object. " + 
    "The function should work for both primitive and reference types.";

var answer = document.getElementById("answer");  

function copyObject(object) {
    if (typeof (object) != "object")
        return object;
    else {
        var newObject = this instanceof Array ? [] : {};
        for (var value in object) {
            newObject[value] = copyObject(object[value]);
        }
        return newObject;
    }
}

function student(name, marks) {
    this.name = name;
    this.marks = marks;
}

var marks = [
    { subject: "JavaScript", score: 5.50 },
    { subject: "OOP", score: 5.00 },
    { subject: "Algorithms and Data Structures", score: 6.00 },
    { subject: "Photoshop", score: 4.00 }
];

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    var peshoPeshev = new student("Pesho Peshev", copyObject(marks));

    answer.innerHTML += marks[1].subject + ": " + marks[1].score;
    answer.innerHTML += "<br />";

    answer.innerHTML += "peshoPeshev " + peshoPeshev.marks[1].subject + ": " +
        peshoPeshev.marks[1].score;
    answer.innerHTML += "<br />";

    answer.innerHTML += '"goshoGoshev" copy "peshoPeshev":';
    answer.innerHTML += "<br />";
    var goshoGoshev = copyObject(peshoPeshev);
        
    answer.innerHTML += "goshoGoshev " + goshoGoshev.marks[1].subject + ": " +
        goshoGoshev.marks[1].score;
    answer.innerHTML += "<br />";

    answer.innerHTML += "<br />";
    answer.innerHTML += "Change " + marks[1].subject + " marks.";
    marks[1].score = 3;
    goshoGoshev.marks[1].score = 4;
    answer.innerHTML += "<br />";

    answer.innerHTML += marks[1].subject + ": " + marks[1].score;
    answer.innerHTML += "<br />";

    answer.innerHTML += "peshoPeshev " + peshoPeshev.marks[1].subject + ": " +
        peshoPeshev.marks[1].score;
    answer.innerHTML += "<br />";
       
    answer.innerHTML += "goshoGoshev " + goshoGoshev.marks[1].subject + ": " +
        goshoGoshev.marks[1].score;
    answer.innerHTML += "<br />";
}