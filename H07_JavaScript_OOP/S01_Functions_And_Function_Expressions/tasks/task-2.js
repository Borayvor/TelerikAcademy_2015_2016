/* Task description */
/*
	Write a function a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function solve() {       
    var start,
        end,
        i,
        arrayOfPrime = [];

    if (arguments.length < 2) {
        throw new Error('Missing range parameter !');
    }

    start = +arguments[0];
    end = +arguments[1];

    if (isNaN(start) || isNaN(end)) {
        throw new Error('the range params is not convertible to "Number" !');
    }     
            
    function isPrime(n) {
        if (n <= 3) { return n > 1; }
        if (n % 2 == 0 || n % 3 == 0) { return false; }
        for (var i = 5; i * i <= n; i += 6) {
            if (n % i == 0 || n % (i + 2) == 0) { return false; }
        }
        return true;
    }

    for (i = start; i <= end; i+=1) {
        if (isPrime(i)) {
            arrayOfPrime.push(i);
        }
    }
    
    return arrayOfPrime;
}

module.exports = solve;