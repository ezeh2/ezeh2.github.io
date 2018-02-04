// Define a grammar called Hello
grammar FunctionDefinitionTest;


function: function_head function_body;

function_head: ID '(' arg_list ')' ;
arg_list :  arg (',' arg)*  ;
arg: type ID ;
type: 'string' | 'bool' | 'int' ;

function_body : '{' function_call* '}' ;

function_call : ID '(' ID (',' ID)* ')' ';';

ID : [a-z]+[0-9a-z]* ;
WS : [ \t\r\n]+ -> skip ; // skip spaces, tabs, newlines

