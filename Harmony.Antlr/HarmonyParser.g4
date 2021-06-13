parser grammar HarmonyParser;

options { tokenVocab=HarmonyLexer; }

compilationUnit
    : attributes unitDeclaration* EOF
    ;

attributes
    : ('Name' ':' name=IDENTIFIER) 
      ('Author' ':' author=IDENTIFIER)
      ('Duration' ':' duration=number)
      ('Tempo' ':' tempo=DECIMAL_LITERAL)
    ;

unitDeclaration
    : UNIT IDENTIFIER block
    ;

block
    : '{' statement* '}'
    ;

statement
    : noteStatement
    ;

noteStatement
    : (NOTE note startTime=number ',' duration=number ',' velocity=number)
    ;

note
    : IDENTIFIER
    ;

number
    : DECIMAL_LITERAL | FLOAT_LITERAL
    ;


 