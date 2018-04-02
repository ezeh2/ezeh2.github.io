
interface I1
{
    S: string;
    B: boolean;
}

export class I1Class implements I1{
    S: string = "S";
    B: boolean = true;
   constructor(s:string,b:boolean) {
      this.S = s;
      this.B = b;
   }
}

class C{
    i1s: I1[] = [];
    ss: String[]=[];

    constructor(count: Number) {

       for(let i=0;i<count;i++) {
            this.ss[i] = "x";
       }
    }
}

function test(): void {

let c: C = new C(12);
// ========
let i:Array<I1> = new Array<I1>(10);
i.concat(new I1Class("name", true))
// ========
let a:Array<string> = new Array<string>();
a=a.concat("a");
a=a.concat("b");
a=a.concat("x");
let n:Number = a.indexOf("b")
console.log(a.length);
console.log(n);
// ========
let i2:Array<I1Class> = new Array<I1Class>();
i2=i2.concat(new I1Class("s1", false));
i2=i2.concat(new I1Class("s2", true));
i2=i2.concat(new I1Class("s3", true));
console.log(i2.length)
let s2:String[] = i2.map<string>((m)=> {
    return m.S;
});
console.log(s2.length);
console.log(s2[1]);
// ========
let s3:I1Class[] = i2.filter((m) => {return m.B});
console.log(s3.length);
console.log(s3[1].S);
// ========
}