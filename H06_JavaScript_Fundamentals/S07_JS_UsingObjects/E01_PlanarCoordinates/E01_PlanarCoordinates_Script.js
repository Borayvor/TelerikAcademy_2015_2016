var task = document.getElementById('task');
task.innerHTML = "1. Write functions for working with shapes in standard Planar " +
    "coordinate system. point2Ds are represented by coordinates P(X, Y) line2Ds are " +
    "represented by two point2Ds, marking their beginning and ending L(P1(X1,Y1), " +
    "P2(X2,Y2)) Calculate the distance between two point2Ds. Check if three " +
    "segment line2Ds can form a triangle.";

var answer = document.getElementById("answer");

function point2D(xCoord, yCoord) {
    this.x = xCoord;
    this.y = yCoord;
    this.toString = function () { return "P(" + this.x + ", " + this.y + ")"; };
}

function line2D(startpoint2D, endpoint2D) {

    if ((startpoint2D instanceof point2D) && (endpoint2D instanceof point2D)) {
        return {
            start: startpoint2D,
            end: endpoint2D,
            length: function () { return calculateTwopoint2DDistance(startpoint2D, endpoint2D); },
            toString: function () { return "L(" + this.start + ", " + this.end + ")"; }
        }
    }
    else {
        return {
            toString: function () { return "The variables must be of type point2D !"; }
        }
    }
}

function calculateTwopoint2DDistance(firstpoint2D, secondpoint2D) {

    var distance = Math.sqrt(Math.pow((firstpoint2D.x - secondpoint2D.x), 2) +
        Math.pow((firstpoint2D.y - secondpoint2D.y), 2));

    return distance;
}

function checkIsTriangle(firstline2D, secondline2D, thirdline2D) {

    var line2DA = firstline2D.length();
    var line2DB = secondline2D.length();
    var line2DC = thirdline2D.length();

    return line2DA + line2DB > line2DC && line2DA + line2DC > line2DB && line2DB +
        line2DC > line2DA;
}

function onButtonClickPrintResult() {
    answer.innerHTML = "";

    var point2DOne = new point2D(10, 10);
    var point2DTwo = new point2D(10, 15);
    var point2DThree = new point2D(15, 10);
    var point2DFour = new point2D(-10, -15);

    var line2DOne = new line2D(point2DOne, point2DTwo);
    var line2DTwo = new line2D(point2DTwo, point2DThree);
    var line2DThree = new line2D(point2DOne, point2DThree);
    var line2DFour = new line2D(point2DThree, point2DFour);

    answer.innerHTML += "First point2D : " + point2DOne;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Second point2D : " + point2DTwo;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Third point2D : " + point2DThree;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Fourth point2D : " + point2DFour;
    answer.innerHTML += "<br />";

    answer.innerHTML += "First line2D : " + line2DOne;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Second line2D : " + line2DTwo;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Third line2D : " + line2DThree;
    answer.innerHTML += "<br />";
    answer.innerHTML += "Fourth line2D : " + line2DFour;
    answer.innerHTML += "<br />";

    answer.innerHTML += "The distance between " + point2DThree + " and " + point2DFour +
        " is : " + calculateTwopoint2DDistance(point2DThree, point2DFour);
    answer.innerHTML += "<br />";

    answer.innerHTML += "Check for triangle (line2DOne, line2DTwo, line2DThree) : " +
        checkIsTriangle(line2DOne, line2DTwo, line2DThree);
    answer.innerHTML += "<br />";

    answer.innerHTML += "Check for triangle (line2DOne, line2DTwo, line2DFour) : " +
        checkIsTriangle(line2DOne, line2DTwo, line2DFour);
    answer.innerHTML += "<br />";
}

//// ============================================================================ ////

function solve(args) {
    var input = args.map(function (num) {
        return parseFloat(num);
    });

    var arrFirstLine = [input[0], input[1], input[2], input[3]];
    var arrSecontLine = [input[4], input[5], input[6], input[7]];
    var arrThirdLine = [input[8], input[9], input[10], input[11]];
    
    function calculateTwopoint2DDistance(firstpoint, secondpoint) {

        var distance = Math.sqrt(Math.pow((firstpoint.x - secondpoint.x), 2) +
            Math.pow((firstpoint.y - secondpoint.y), 2));

        return distance;
    }

    function checkIsTriangle(firstline, secondline, thirdline) {

        var lineA = firstline.length();
        var lineB = secondline.length();
        var lineC = thirdline.length();

        var trianglebuilt = 'Triangle can be built';
        var triangleNotbuilt = 'Triangle can not be built';

        if (lineA + lineB > lineC && lineA + lineC > lineB && lineB + lineC > lineA) {
            return trianglebuilt;
        }
        else {
            return triangleNotbuilt;
        }
    }

    function point2D(xCoord, yCoord) {
        return {
            x: xCoord,
            y: yCoord
        };
    }

    function line2D(startpoint2D, endpoint2D) {
        return {
            start: startpoint2D,
            end: endpoint2D,
            length: function () {
                return calculateTwopoint2DDistance(this.start, this.end);
            }

        };
    }

    var lineOne = new line2D(
        new point2D(arrFirstLine[0], arrFirstLine[1]),
        new point2D(arrFirstLine[2], arrFirstLine[3]));

    var lineTwo = new line2D(
        new point2D(arrSecontLine[0], arrSecontLine[1]),
        new point2D(arrSecontLine[2], arrSecontLine[3]));

    var lineThree = new line2D(
        new point2D(arrThirdLine[0], arrThirdLine[1]),
        new point2D(arrThirdLine[2], arrThirdLine[3]));

    var result = lineOne.length().toFixed(2) + '\n' +
        lineTwo.length().toFixed(2) + '\n' +
        lineThree.length().toFixed(2) + '\n' +
        checkIsTriangle(lineOne, lineTwo, lineThree);

    return result;    
}
