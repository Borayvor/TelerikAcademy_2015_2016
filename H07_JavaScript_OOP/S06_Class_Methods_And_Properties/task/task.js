'use strict';

class listNode {
    constructor(value) {
        this._value = value;
        this._next = null;
    }

    get data() {
        return this._value;
    }

    get next() {
        return this._next;
    }

    set next(value) {
        this._next = value;
    }
}

class LinkedList {
    constructor() {
        this._length = 0;
        this._head = null;
    }

    get first() {
        return this.getNode(0);
    }

    get last() {
        return this.getNode(this._length - 1);
    }

    get length() {
        return this._length;
    }

    getNode(index) {
        if (index > -1 && index < this._length) {
            let current = this._head,
                i = 0;

            while (i++ < index) {
                current = current.next;
            }

            return current.data;
        } else {
            return null;
        }
    }

    append(...data) {
        let listHead = this._head;
        let listLength = this._length;
        let current;

        function addNode(currentData) {
            if (listHead === null) {
                listHead = new listNode(currentData);
            } else {
                current = listHead;

                while (current.next) {
                    current = current.next;
                }

                current.next = new listNode(currentData);
            }

            listLength++;
        }

        data.forEach(addNode);

        this._head = listHead;
        this._length = listLength;

        return this;
    }

    prepend(...data) {
        let listHead = null;
        let listLength = 0;
        let current;

        function addNode(currentData) {
            if (listHead === null) {
                listHead = new listNode(currentData);
            } else {
                current = listHead;

                while (current.next) {
                    current = current.next;
                }

                current.next = new listNode(currentData);
            }

            listLength++;
        }

        data.forEach(addNode);

        current = listHead;

        while (current.next) {
            current = current.next;
        }

        current.next = this._head;
        this._head = listHead;
        this._length += listLength;

        return this;
    }

    insert(...data) {
        let listHead = null;
        let listLength = 0;
        let current;
        let currentEnd;
        let insertIndex = data.shift();

        function addNode(currentData) {
            if (listHead === null) {
                listHead = new listNode(currentData);
            } else {
                current = listHead;

                while (current.next) {
                    current = current.next;
                }

                current.next = new listNode(currentData);
            }

            listLength++;
        }

        data.forEach(addNode);

        if (insertIndex >= 1) {
            current = this._head;

            for (var i = 0; i < insertIndex; i += 1) {
                current = current.next;
            }

            currentEnd = current.next;
            current.next = listHead;

            while (current.next) {
                current = current.next;
            }

            current.next = currentEnd;
        } else {
            current = listHead;

            while (current.next) {
                current = current.next;
            }

            current.next = this._head;
            this._head = listHead;
        }

        this._length += listLength;

        return this;
    }

    at(index) {
        let current = this._head;

        if (index < 0 || index > this._length) {
            throw 'Index is out of range !';
        }

        for (var i = 0; i < index; i += 1) {
            current = current.next;
        }

        return current._value;
    }

    removeAt(index) {
        let current = this._head;
        let currentStart;
        let nodeToRemove;
        let i;

        if (index < 0 || index > this._length) {
            throw 'Index is out of range !';
        }

        for (i = 0; i < index; i += 1) {
            if (i === index - 1) {
                currentStart = current;
            }

            current = current.next;
        }

        nodeToRemove = current;

        if (index === 0) {
            this._head = nodeToRemove.next;
        } else {
            currentStart.next = nodeToRemove.next;
        }

        this._length -= 1;

        return this;
    }

    toArray() {
        let current = this._head;
        let result = [];

        for (var i = 0; i < this._length; i += 1) {
            result.push(current._value);

            current = current.next;
        }

        return result;
    }

    toString() {
        let result = "";
        let current = this._head;
        let penultimate = this._length - 1;

        for (var i = 0; i < this._length; i += 1) {
            result += current._value;

            if (i < penultimate) {
                result += ' -> ';
            }

            current = current.next;
        }

        return result;
    }

    [Symbol.iterator]() {
        var index = -1;
        var data = this.toArray();

        return {
            next: () => ({
                value: data[++index],
                done: !(index in data)
            })
        };
    }
}

//module.exports = LinkedList;

const list = new LinkedList();

// list.append(1);
// list.append('a');
// list.append("abc");
// list.append(1, 2, 3).append('4ao');
// console.log(list.first);
// console.log(list.last);
// console.log(list.length);

// list.prepend('end').prepend(100, 200, 300);
// console.log(list.first);
// console.log(list.last);
// console.log(list.length);

// list.append(1, 4, 5).insert(1, 2, 3);
// console.log(list.first);
// console.log(list.last);
// console.log(list.length);

// list.append(1, 2, 3, 4, 5, 6);
// console.log(list.at(1));

// const removed = list.append(1, 2, 3, 4, 5).removeAt(0);
// console.log(list.first);
// console.log(list.last);
// console.log(list.length);

// list.append(1, 2, 3, 4, 5, 6);
// const arr  = list.toArray();
// console.log(arr); // [1, 2, 3, 4, 5, 6]
// console.log(arr instanceof Array);

// list.append(1, 2, 3, 4, 5, 6);
// console.log(list.toString()); // 1 -> 2 -> 3 -> 4 -> 5 -> 6

// list.append(6, 7, 8).prepend(1, 2, 3, 4, 5);

// for (const value of list) {
//     console.log(value);
// }