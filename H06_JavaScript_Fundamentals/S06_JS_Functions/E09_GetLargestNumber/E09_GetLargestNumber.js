function solve(args) {
    var numbers = args[0].split(' ').map(function (num) { 
        return parseInt(num);
    });

    function getMax(arr) {
        var max = arr[0];

        if (max < arr[1]){
            max = arr[1];
        }

        if (max < arr[2]){
            max = arr[2];
        }

        return max;
    }

    return getMax(numbers);
}