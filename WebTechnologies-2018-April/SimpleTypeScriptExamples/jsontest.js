"use strict";
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
    result["default"] = mod;
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
const fs = __importStar(require("fs"));
class Class1 {
}
let x = new Class1();
x.S = "aa";
x.N = 12;
// write to file 
let s1 = JSON.stringify(x);
fs.writeFileSync('test.json', s1);
// read from disk
let s2 = fs.readFileSync('test.json', { 'encoding': 'UTF8' });
let o2 = JSON.parse(s2);
// output
console.log(o2.N);
