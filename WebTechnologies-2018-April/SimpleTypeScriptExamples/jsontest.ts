import * as fs from 'fs';

class Class1 {
    S: string;
    N: number;
 }
 
 let x:Class1 = new Class1();
 x.S="aa";
 x.N=12;
 
 // write to file 
 let s1:string = JSON.stringify(x);
 fs.writeFileSync('test.json',s1);
 
 // read from disk
 let s2:string = fs.readFileSync('test.json',{'encoding':'UTF8'});
 let o2:Class1 = JSON.parse(s2);
 
 // output
 console.log(o2.N);

