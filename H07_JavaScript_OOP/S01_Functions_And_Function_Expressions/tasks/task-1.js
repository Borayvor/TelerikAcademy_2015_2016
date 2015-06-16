/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/
function sum(array) {
    var i,
        len,
        sumOfNumbers = 0;

    if (array === undefined) {
        throw new Error('Parameter must be of type array !');
    }

    if (array.length < 1) {
        return null;
    }

    len = array.length;

    for (i = 0; i < len; i += 1) {
        if(isNaN(array[i])){
            throw new Error('The element must be convertible to Number !');
        }
        sumOfNumbers += +array[i];
    }

    return sumOfNumbers;
}


module.exports = sum;