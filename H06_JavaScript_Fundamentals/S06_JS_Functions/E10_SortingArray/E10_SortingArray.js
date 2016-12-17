function solve(args) {
    var arr = args[0].split('\n');
    var arrLength = parseInt(arr.shift());    

    arr = arr[0].split(" ").map(function (num) {
        return parseInt(num);
    });

    function sort(arr, len) { 
        for (var i = 0; i < len - 1; i += 1) {
            var min = i;

            for (var j = i + 1; j < len; j += 1) {
                if (parseInt(arr[j]) < parseInt(arr[min])) {
                    min = j;
                }
            }

            if (min !== i) {
                var temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }

        return arr.join(' ');
    }

    return sort(arr, arrLength);
}

function solve(args) {
    return args;
}