"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class I1Class {
    constructor(s, b) {
        this.S = "S";
        this.B = true;
        this.S = s;
        this.B = b;
    }
}
exports.I1Class = I1Class;
class C {
    constructor(count) {
        this.i1s = [];
        this.ss = [];
        for (let i = 0; i < count; i++) {
            this.ss[i] = "x";
        }
    }
}
function test() {
    let c = new C(12);
    // ========
    let i = new Array(10);
    i.concat(new I1Class("name", true));
    // ========
    let a = new Array();
    a = a.concat("a");
    a = a.concat("b");
    a = a.concat("x");
    let n = a.indexOf("b");
    console.log(a.length);
    console.log(n);
    // ========
    let i2 = new Array();
    i2 = i2.concat(new I1Class("s1", false));
    i2 = i2.concat(new I1Class("s2", true));
    i2 = i2.concat(new I1Class("s3", true));
    console.log(i2.length);
    let s2 = i2.map((m) => {
        return m.S;
    });
    console.log(s2.length);
    console.log(s2[1]);
    // ========
    let s3 = i2.filter((m) => { return m.B; });
    console.log(s3.length);
    console.log(s3[1].S);
    // ========
}
