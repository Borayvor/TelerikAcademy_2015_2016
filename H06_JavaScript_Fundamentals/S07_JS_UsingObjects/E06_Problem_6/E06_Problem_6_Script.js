var task = document.getElementById('task');
task.innerHTML = "6.  Write a function that groups an array of people by age, " + 
    "first or last name. The function must return an associative array, " + 
    "with keys - the groups, and values - arrays with people in this groups. " +
    "Use function overloading (i.e. just one function)";

var answer = document.getElementById("answer");

function person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.toString = function () {
        return (this.firstName + ' ' + this.lastName + ', age : ' + this.age);
    }
}

function group(object, property) {

    switch (property) {
        case "firstName":
        case "lastName":
        case "age":
            {
                var group = {};

                object.map(function (obj) {
                    if (!group[obj[property]]) {
                        group[obj[property]] = new Array();
                    }
                    group[obj[property]].push(obj);
                });

                return group;
            }
        default:
            throw new Error("No such property in object.");                    
    }
}
                
var persons = [
new person ( "Gosho", "Petrov", 32 ),
new person ( "Bay", "Ivan", 81 ),
new person ( "Gosho", "Bunny", 72 ),
new person ( "Speedy", "Bunny", 72 ),
new person ( "Bugs", "Bunny", 7 ),
new person ( "Gosho", "Gonzales", 7 ),
new person ( "Speedy", "Gonzales", 72 ),
new person ( "Speedy", "Gonzales", 7 ),
new person ( "Zoro", "Chernev", 87 ),
new person ( "Pesho", "Peshev", 23 ),
];

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    var groupedByFname = group(persons, "firstName");
    var groupedByAge = group(persons, "age");
            
    for (var person in groupedByFname) {
        answer.innerHTML += 'Group \"firstName\" : ' + person;
        answer.innerHTML += "<br />";
        answer.innerHTML += groupedByFname[person];
        answer.innerHTML += "<br />";
    }
    answer.innerHTML += "<br />";

    for (var person in groupedByAge) {
        answer.innerHTML += 'Group \"age\" : ' + person;
        answer.innerHTML += "<br />";
        answer.innerHTML += groupedByAge[person];
        answer.innerHTML += "<br />";
    }
}