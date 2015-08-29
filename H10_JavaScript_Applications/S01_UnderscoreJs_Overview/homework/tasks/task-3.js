/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName` and `age` properties
        *   Array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

/// <reference path="../node_modules/underscore/underscore.js" />

function solve(){
    return function ( students ) {

        var student = _.chain( students )
                      .map( function ( student ) {
                          var sum = 0,
                              i,
                              len = student.marks.length;

                          for ( var i = 0; i < len; i += 1 ) {
                              sum += student.marks[i];
                          }

                          student.averageMark = sum / len;
                          student.fullName = student.firstName + ' ' + student.lastName;

                          return student;
                      } )
                      .sortBy( function ( student ) {         

                          return student.averageMark;
                      } )
                      .last()
                      .value();

        console.log( student.fullName + ' has an average score of ' + student.averageMark );
  };
}

module.exports = solve;
