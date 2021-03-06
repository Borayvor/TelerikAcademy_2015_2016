/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return thisPerson, if they are not supposed to return other value
		*	enables method-chaining
*/

function solve() {
    var Person = (function () {
        var thisPerson;
                
        function Person(firstname, lastname, age) {
            thisPerson = this;

            thisPerson.firstname = firstname;
            thisPerson.lastname = lastname;
            thisPerson.age = age;
        }

        Object.defineProperty(Person.prototype, 'firstname', {
            get: function () {
                return thisPerson._firstname;
            },
            set: function (value) {
                checkName(value);
                thisPerson._firstname = value;
                return thisPerson;
            }
        });

        Object.defineProperty(Person.prototype, 'lastname', {
            get: function () {
                return thisPerson._lastname;
            },
            set: function (value) {
                checkName(value);
                thisPerson._lastname = value;
                return thisPerson;
            }
        });

        Object.defineProperty(Person.prototype, 'age', {
            get: function () {
                return thisPerson._age;
            },
            set: function (value) {
                checkAge(value)
                thisPerson._age = +value;
                return thisPerson;
            }
        });
        
        Object.defineProperty(Person.prototype, 'fullname', {
            get: function () {
                return thisPerson.firstname + ' ' + thisPerson.lastname;
            },
            set: function (value) {
                var names = value.split(' ');
                checkName(names[0]);
                checkName(names[1]);
                thisPerson.firstname = names[0];
                thisPerson.lastname = names[1];
                return thisPerson;
            }
        });

        Person.prototype.introduce = function () {
            return 'Hello! My name is ' + thisPerson.fullname +
                ' and I am ' + thisPerson.age + '-years-old';
        };

        function checkAge(age) {
            if (isNaN(age)) {
                throw new Error('Age must always be a number !');
            }

            var ageInt = +age;

            if (ageInt < 0 || ageInt > 150) {
                throw new Error('Age must by between 0 and 150 !');
            }
        }

        function checkName(name) {
            if (typeof name !== 'string') {
                throw new Error('The name must by of type string !');
            }

            if (name.length < 3 || name.length > 20) {
                throw new Error('The name length must by between 3 and 20 characters !');
            }

            if (!/^[A-Za-z]+$/g.test(name)) {
                throw new Error('The name must only contain latin letters !');
            }
        }

        return Person;
    }());

    return Person;
}

module.exports = solve;