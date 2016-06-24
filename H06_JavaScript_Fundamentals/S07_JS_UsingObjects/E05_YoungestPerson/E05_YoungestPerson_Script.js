var task = document.getElementById('task');
task.innerHTML = "5.  Write a function that finds the youngest person in a given " +
    "array of people and prints his/hers full name. Each person has properties " +
    "firstname, lastname and age.";

var answer = document.getElementById("answer");

function findYoungest(persons) {

    var age = persons[0]['age'];
    var fullName = '';

    for (var index = 1; index < persons.length; index++) {

        if (age > persons[index]['age']) {
            age = persons[index]['age'];
            fullName = persons[index]['firstname'] + ' ' + persons[index]['lastname'];
        }
    }
    return (fullName + ' : ' + age + 'age');
}

var persons = [
    { firstname: "Gosho", lastname: "Petrov", age: 32 },
    { firstname: "Bay", lastname: "Ivan", age: 81 },
    { firstname: "Bugs", lastname: "Bunny", age: 72 },
    { firstname: "Speedy", lastname: "Gonzales", age: 7 },
    { firstname: "Zoro", lastname: "Chernev", age: 87 },
    { firstname: "Pesho", lastname: "Peshev", age: 23 },
];

for (var index = 0; index < persons.length; index++) {
    answer.innerHTML += persons[index]['firstname'] + ' ' +
        persons[index]['lastname'] + ' ' + persons[index]['age'];
    answer.innerHTML += "<br />";
}

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    for (var index = 0; index < persons.length; index++) {
        answer.innerHTML += persons[index]['firstname'] + ' ' +
            persons[index]['lastname'] + ' ' + persons[index]['age'];
        answer.innerHTML += "<br />";
    }

    answer.innerHTML += 'The youngest person is: ';
    answer.innerHTML += findYoungest(persons);
}

//// ============================================================================ ////

function solve(args) {
    var len = args.length;

    var persons = [];

    function person(firstname, lastname, age) {
        return {
            firstname: firstname,
            lastname: lastname,
            age: parseInt(age),
            getFullName: function () {
                return this.firstname + ' ' + this.lastname;
            }

        };
    }

    function findYoungest(persons) {
        var age = persons[0].age;
        var fullName = persons[0].getFullName();

        for (var i = 1; i < persons.length; i += 1) {

            if (age > persons[i].age) {
                age = persons[i].age;
                fullName = persons[i].getFullName();
            }
        }

        return (fullName);
    }

    for (var i = 0; i < len; i += 1) {
        persons.push(new person(args[i++], args[i++], args[i]));
    }

    console.log(findYoungest(persons));
}