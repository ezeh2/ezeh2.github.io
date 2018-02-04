call antlr4 MathExpression.g4
javac *.java
rem call grun MathExpression math_expression MathExpression.txt -gui
call grun MathExpression math_expression MathExpression.txt -tree

pause



