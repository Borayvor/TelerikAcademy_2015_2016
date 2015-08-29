/* 
Create a function that:
*   **Takes** a collection of books
    *   Each book has propeties `title` and `author`
        **  `author` is an object that has properties `firstName` and `lastName`
*   **finds** the most popular author (the author with biggest number of books)
*   **prints** the author to the console
	*	if there is more than one author print them all sorted in ascending order by fullname
		*   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

/// <reference path="../node_modules/underscore/underscore.js" />

function solve() {
    return function ( books ) {

        var sortedGroupsOfAuthors = _.chain( books )
            .map( function ( book ) {
                  book.author.fullName = book.author.firstName + ' ' + book.author.lastName;

                  return book;
              } )
            .groupBy( function ( book ) {

                  return book.author.fullName;
              } )
            .sortBy( function ( group ) {
                  return group.length;
              } )
            .reverse()
            .value();

        var maxNumberOfBooks = _.first( sortedGroupsOfAuthors ).length;

        _.chain( sortedGroupsOfAuthors )
            .filter( function ( group ) {
                return maxNumberOfBooks === group.length;
            } )
            .map( function ( group ) {
                return group[0].author.fullName;
            } )
            .sortBy()
            .each( function ( author ) {
                console.log( author );
            } );
    };
}

module.exports = solve;
