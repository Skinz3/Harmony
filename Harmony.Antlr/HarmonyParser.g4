parser grammar HarmonyParser;

options { tokenVocab=HarmonyLexer; }

compilationUnit
    : attribute* unitDeclaration* EOF
    ;

attribute
    : name=IDENTIFIER ':' value=IDENTIFIER
    ;

unitDeclaration
    : UNIT IDENTIFIER block
    ;

block
    : '{' statement* '}'
    ;


statement
    : note
    ;

note
    : NOTE IDENTIFIER FLOAT_LITERAL
    ;