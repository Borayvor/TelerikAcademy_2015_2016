/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
    var Course = {
        init: function ( title, presentations ) {
            this.title = title;
            this.presentations = presentations;
            this.students = [];

            return this;
        },
        addStudent: function ( name ) {
            var studentID,
                fullNameArr,
                student;

            validateName( name );

            studentID = this.students.length + 1;
            fullNameArr = name.split( ' ' );

            this.students.push( {
                firstname: fullNameArr[0],
                lastname: fullNameArr[1],
                id: studentID
            } );

            return studentID;
        },
        getAllStudents: function () {
            return this.students.map( function ( item ) {
                if ( typeof item === 'object' ) {
                    return Object.create( item );
                } else {
                    return item;
                }
            } ).slice();
        },
        submitHomework: function ( studentID, homeworkID ) {
            validateId( studentID, 1, this.students.length );
            validateId( homeworkID, 1, this.presentations.length );
        },
        pushExamResults: function ( results ) {

        },
        getTopStudents: function () {

        },
    };

    Object.defineProperty( Course, 'title', {
        get: function () {
            return Course._title;
        },
        set: function ( value ) {
            if ( !isTitleValid( value ) ) {
                throw new Error( 'Invalid title !' );
            }

            Course._title = value;
        }
    } );

    Object.defineProperty( Course, 'presentations', {
        get: function () {
            return Course._presentations.map( function ( item ) {
                if ( typeof item === 'object' ) {
                    return Object.create( item );
                } else {
                    return item;
                }
            } ).slice();
        },
        set: function ( value ) {
            if ( value === null ||
                !Array.isArray( value ) ||
                value.length === 0 ) {
                throw new Error( 'Invalid presentations !' );
            }

            if ( value.some( function ( title ) {
                return !isTitleValid( title );
            } ) ) {
                throw new Error( 'Invalid Presentation title !' );
            }

            Course._presentations = value;
        }
    } );

    function isTitleValid( title ) {
        return ( !( title === null ||
            typeof title !== 'string' ||
            title.trim() === '' ||
            title !== title.trim() ||
            /[\s]{2,}/.test( title ) ) );
    }

    function validateName( name ) {
        if ( name === null || typeof name !== 'string' ) {
            throw new Error( 'The student name is not valid !' );
        }

        if ( name !== name.trim() || name.trim() === '' ) {
            throw new Error( 'The student name is not valid !' );
        }

        var names = name.split( ' ' );

        if ( names.length !== 2 ) {
            throw new Error( 'The student name is not valid !' );
        }

        names.forEach( function ( n ) {
            if ( !/^[A-Z][a-z]*$/.test( n ) ) {
                throw new Error( 'The student name is not valid !' );
            }
        } );
    }

    function validateId( id, min, max ) {
        var thisId = +id;

        if ( isNaN( thisId ) ) {
            throw new Error( 'Type of id must be Number !' );
        }

        if ( thisId < min || thisId > max ) {
            throw new Error( 'Id is out of range !' );
        }
    }

    return Course;
}

module.exports = solve;