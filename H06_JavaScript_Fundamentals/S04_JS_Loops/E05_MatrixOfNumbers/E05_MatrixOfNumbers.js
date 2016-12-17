function solve(args) {
    var size = parseInt(args);

    for (var i = 1; i <= size; i += 1) {
        var result = '';

        for (var j = 0; j < size; j += 1) {
            if (j === size){
                result += (i + j);
                break;
            }
            
            result += (i + j) + ' ';
        }

        console.log(result);
    }
}