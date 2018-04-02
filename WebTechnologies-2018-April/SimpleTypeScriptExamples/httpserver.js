"use strict";
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (Object.hasOwnProperty.call(mod, k)) result[k] = mod[k];
    result["default"] = mod;
    return result;
};
Object.defineProperty(exports, "__esModule", { value: true });
const http = __importStar(require("http"));
let s = new http.Server((req, res) => {
    console.log(req.method + " " + req.headers['host'] + " " + req.url);
    console.log(req.headers);
    res.write('hello');
    res.end();
    console.log('===');
});
s.listen(8080, () => {
    console.log('l');
});
