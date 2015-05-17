console.log("1. Assign all the possible JavaScript literals to different variables.");
var intVariable = 123456789;
console.log("int = " + intVariable);

var floatVariable = 1234.56789;
console.log("float = " + floatVariable);

var boolVariable = true;
console.log("boolean = " + boolVariable);

var arrayCoffees = ['"French Roast"', '"Colombian"', '"Kona"'];
console.log("array = " + arrayCoffees);

var stringVariable = "Audio system";

function CarTypes(name) {
    if (name == "Honda") {
        return name;
    } else {
        return "Sorry, we don't sell " + name + ".";
    }
}

var objectCar = { myCar: "Saturn", getCar: CarTypes("Honda"), special: stringVariable };
console.log("object car :");
console.log("myCar : " + objectCar.myCar);
console.log("getCar : " + objectCar.getCar);
console.log("special (Sales) : " + objectCar.special);