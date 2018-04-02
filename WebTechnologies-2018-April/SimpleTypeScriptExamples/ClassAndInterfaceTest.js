"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Z {
    constructor() {
        this.s2 = "s1";
    }
}
class X extends Z {
    constructor(n, s, b) {
        super();
        this.n1 = n;
        this.s1 = s;
        this.b1 = b;
    }
    print() {
        console.log(this.n1 + " " + this.s1 + " " + this.b1);
    }
}
exports.X = X;
function printY(y) {
    console.log(y.s1 + " " + y.b1);
}
let y = new X(12, "x", true);
// downcast
let x = y;
x.b1 = false;
x.print();
printY(y);
