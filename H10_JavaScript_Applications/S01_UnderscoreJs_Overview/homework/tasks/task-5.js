/* 
Create a function that:
*   **Takes** an array of animals
    *   Each animal has propeties `name`, `species` and `legsCount`
*   **finds** and **prints** the total number of legs to the console in the format:
    *   "Total number of legs: TOTAL_NUMBER_OF_LEGS"
*   **Use underscore.js for all operations**
*/

/// <reference path="../node_modules/underscore/underscore.js" />

function solve(){
    return function ( animals ) {
        
        var sumOfAllLegs = _.reduce( animals, function ( sumOfLegs, animal ) {
            sumOfLegs += animal.legsCount;
            return sumOfLegs;
        }, 0 );
                        
        console.log( 'Total number of legs: ' + sumOfAllLegs );
  };
}

module.exports = solve;
