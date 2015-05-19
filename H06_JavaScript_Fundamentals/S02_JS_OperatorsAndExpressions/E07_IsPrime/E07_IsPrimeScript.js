var task = document.getElementById('task');
task.innerHTML = "7. Write an expression that checks if given positive integer " +
    "number n (n ≤ 100) is prime. E.g. 37 is prime.";

function isPrime(num) {
    if (num % 2 == 0) return false;

    for (var i = 3; i * i <= num; i += 2) {
        if (num % i == 0) {
            return false;
        }
    }
    return true;
}

function onButtonClick() {
    var number = parseInt(document.getElementById("input-data").value);
    var answer = document.getElementById("answer");

    if (isPrime(number)) {
        answer.innerHTML = number + " is prime number.";
    }
    else {
        answer.innerHTML = number + " is composite number.";
    }
}