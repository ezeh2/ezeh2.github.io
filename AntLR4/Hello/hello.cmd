rem Getting Started with ANTLR v4
rem https://github.com/antlr/antlr4/blob/master/doc/getting-started.md

rem generate lexer and parser
java org.antlr.v4.Tool Hello.g4

rem compile
javac *.java

rem tree as text
rem java org.antlr.v4.gui.TestRig Hello r Hello.txt -tree

rem tree in GUI
java org.antlr.v4.gui.TestRig Hello r Hello.txt -gui

pause

