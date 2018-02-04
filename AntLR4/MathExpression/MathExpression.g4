// Define a grammar called MathExpression
// supported: (, ), +/- for float and vars.
grammar MathExpression;

math_expression : expression;

// https://cs.stackexchange.com/questions/23738/grammar-for-parsing-simple-mathematical-expression
expression : product ( DASH_OP product )* ;
product : factor ( POINT_OP  factor )* ;
factor : DASH_OP? FLOAT | DASH_OP? VAR | '(' expression ')' ;

fragment DIGIT: [0-9] ;
fragment LETTER: [A-Za-z] ;
FLOAT: ( DIGIT+ ('.' DIGIT+)? ) | ( '.' DIGIT+ );
VAR: LETTER (LETTER | DIGIT)* ;
POINT_OP: [*/] ;
DASH_OP:  [+-] ;
WS : [ \t\r\n]+ -> skip ; // skip spaces, tabs, newlines

