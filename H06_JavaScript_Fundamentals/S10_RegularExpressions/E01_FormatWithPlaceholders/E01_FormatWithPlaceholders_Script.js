﻿var task = document.getElementById('task');
task.innerHTML = 'Look at console.';

// Write a function that formats a string. The function should have 
// placeholders, as shown in the example
// Add the function to the String.prototype

String.prototype.format = function (options) {
    var str = this;

    return str.replace(/#{(\w+)}/g, function ($0, $1) {
        return options[$1];
    })
};

var options = { name: 'John' };
var oldText1 = 'Hello, there! Are you #{name}?';
console.log(oldText1);
var newText1 = oldText1.format(options);
console.log(newText1);

console.log('=====================================================');

var options = { name: 'John', age: 13 };
var oldText2 = 'My name is #{name} and I am #{age}-years-old';
console.log(oldText2);
var newText2 = oldText2.format(options);
console.log(newText2);