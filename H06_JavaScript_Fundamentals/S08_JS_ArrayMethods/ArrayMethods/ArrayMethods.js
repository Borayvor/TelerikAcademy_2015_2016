var task = document.getElementById('task');
task.innerHTML = 'Look at console.';

console.log('===============E01 Make person=====================');
// Write a function for creating persons.
// Each person must have firstname, lastname, age and gender (true is female, false is male)
// Generate an array with ten person with different names, ages and genders

var fNames = ['Pesho', 'Gosho', 'Tosho', 'Misho', 'Ivan',
    'Iva', 'Elena', 'Irina', 'Maria', 'Plamena'],
    lNames = ['Peshov', 'Goshov', 'Toshov', 'Mishov', 'Sashov',
    'Peshova', 'Goshova', 'Toshova', 'Mishova', 'Sashova'];

people = Array.apply(null, new Array(10))
     .map(function (_, index) {
         return {
             firstName: fNames[index],
             lastName: lNames[index],
             age: Math.floor(Math.random() * (25 - 14)) + 14,
             gender: index > 4 == true ? 'female' : 'male'
         };
     }
     );

people.forEach(function (person) {
    console.log(person);
});

console.log('---------------------------------------------------');

console.log('===============E02 People of age=====================');
// Write a function that checks if an array of person contains only 
// people of age (with age 18 or greater)
// Use only array methods and no regular loops (for, while)

var ofAge_18_Only =
    people.every(function (item) {
        return item.age >= 18;
    });

console.log(ofAge_18_Only === true ? 'There are only people of age 18.'
    : 'Not all people are of age 18.');

console.log('---------------------------------------------------');

console.log('===============E03 Underage people=====================');
// Write a function that prints all underaged persons of an array of person
// Use Array#filter and Array#forEach
// Use only array methods and no regular loops (for, while)

people.filter(function (person) {
    return person.age < 18;
})
    .forEach(function (person) {
        console.log(person);
    });

console.log('---------------------------------------------------');

console.log('===============E04 Average age of females=====================');
// Write a function that calculates the average age of all females, 
// extracted from an array of persons
// Use Array#filter
// Use only array methods and no regular loops (for, while)

var femalesAvrAge = people.filter(function (person) {
    return person.gender === 'female';
})
    .reduce(function (sum, person, i, array) {
        var count = array.length;
        return sum + (person.age / count);
    }, 0);

console.log('The average age of all females: ' + femalesAvrAge);

console.log('---------------------------------------------------');

console.log('===============E05 Youngest person=====================');
// Write a function that finds the youngest male person in a given array of people and prints his full name
// Use only array methods and no regular loops (for, while)
// Use Array#find

if (!Array.prototype.find) {
    Array.prototype.find = function (callback) {
        var i, len = this.length;
        for (i = 0; i < len; i += 1) {
            if (callback(this[i], i, this)) {
                return this[i];
            }
        }
    }
}

var youngestMale = people.filter(function (person) {
    return person.gender === 'male';
})
    .sort(function (first, second) {
        return first.age - second.age;
    })
    .find(function (person) {
        return person.firstName;
    });

console.log(youngestMale);

console.log('---------------------------------------------------');

console.log('===============E06 Group people=====================');
// Write a function that groups an array of persons by first letter of 
// first name and returns the groups as a JavaScript Object
// Use Array#reduce
// Use only array methods and no regular loops (for, while)

var groups = people.reduce(function (group, person) {
    var firstLetter = person.firstName[0];

    if(group[firstLetter]){
        group[firstLetter].push(person);
    }
    else {
        group[firstLetter] = [person]
    }

    return group;
}, {});

console.log(groups);

console.log('---------------------------------------------------');