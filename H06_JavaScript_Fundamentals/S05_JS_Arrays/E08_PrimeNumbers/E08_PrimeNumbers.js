function solve(args) {
    var N = parseInt(args);

    function isPrime(n) {
        if (n < 2) return false;
        var q = Math.floor(Math.sqrt(n));

        for (var i = 2; i <= q; i++) {
            if (n % i === 0) {
                return false;
            }
        }

        return true;
    }

    for (var i = N; i > 0; i -= 1) {
        var pr = isPrime(i);

        if (pr) {
            return i;
        }
    }
}

