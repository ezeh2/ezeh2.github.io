// Define a grammar called MathExpression
// not supported: numbers with +/-
grammar MathExpression;

math_expression : expression;

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

