var task = document.getElementById('task');
task.innerHTML = '12. Write a function that creates a HTML &lt;ul&gt; using a ' +
    'template for every HTML &lt;li&gt;. The source of the list should be an ' + 
    'array of elements. Replace all placeholders marked with –{…}– with ' + 
    'the value of the corresponding property of the object.';

var answer = document.getElementById("answer");

function generateUnorderedList(people, template) {
    var props = [];
    var peopleList = [];

    peopleList.push("<ul>");

    for (var property in people[0]) {
        props.push(property);
    }

    for (var index = 0; index < people.length; index++) {
        peopleList.push("<li>");

        var liContent = template;

        for (var property in people[0]) {
            liContent = liContent.replace(new RegExp('-{' + property + '}-', "g"),
                people[index][property]);
        }

        peopleList.push(liContent);
        peopleList.push("</li>");
    }

    peopleList.push("</ul>");

    return peopleList.join('');
}

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    var people = [
        { name: "Peter", age: 14 },
        { name: "Ivan", age: 25 },
        { name: "Maria", age: 26 }
    ];

    var template = document.getElementById("list-item").innerHTML;
    var peopleList = generateUnorderedList(people, template);

    answer.innerHTML += peopleList;
}