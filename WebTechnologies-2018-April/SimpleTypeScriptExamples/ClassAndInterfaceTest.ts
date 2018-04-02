
interface Y
{
    s1: String;
    b1: boolean;
 }

 class Z
 {
    s2: String = "s1";
 }

export class X  extends Z implements Y
{
   private n1: Number;
   s1: String;
   b1: boolean;
   constructor(n: Number, s: String, b: boolean)   {
     super();
     this.n1=n;
     this.s1=s;
     this.b1=b;          
   }

   print() {
       console.log(this.n1 + " "+ this.s1 + " "+this.b1);
   }
}

function printY(y: Y) {
   console.log(y.s1 + " " + y.b1);
}

let y:Y = new X(12, "x", true);
// downcast
let x:X = <X>y;
x.b1=false;


x.print();

printY(y);