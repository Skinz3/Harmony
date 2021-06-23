parser grammar HarmonyParser;

options { tokenVocab=HarmonyLexer; }

//==========================================================
// Unit
//==========================================================

compilationUnit
    : attributes unitDeclaration*  EOF
    ;

attributes
    : ('name' ':' name=IDENTIFIER) 
      ('author' ':' author=IDENTIFIER)
      ('tempo' ':' tempo=DECIMAL_LITERAL)
    ;

unitDeclaration
    : UNIT name=IDENTIFIER block
    ;

block
    : '{' (blockStatement)* '}'
    ;

blockStatement
    : statement(DOT blockFunction)?
    ;


//==========================================================
// Statements
//==========================================================

statement
    : stepStatement
    | noteStatement
    | chordStatement
    | unitStatement
    ;


unitStatement
    : name=IDENTIFIER
    ;
noteStatement
    : (NOTE  noteLiteral '(' duration=number ',' velocity=number  ')' )
    ;

chordStatement
    : (CHORD  chordLiteral '(' duration=number ',' velocity=number  ',' octave=DECIMAL_LITERAL ')' )
    ;

stepStatement
    : (STEP target=blockStatement)
    | (STEP duration=number)
    ;

//==========================================================
// Statements
//==========================================================


//==========================================================
// Functions
//==========================================================

blockFunction
    :
    current=function (DOT next=function)?
    ;

function
    : transposeFunction
    | propagateFunction
    | strumFunction
    | timesFunction
    | bassFunction
    | addFunction
    ;


propagateFunction:
    PROPAGATE'('amount=DECIMAL_LITERAL')'
    ;

transposeFunction:
    TRANSPOSE'('value=DECIMAL_LITERAL')'
    ;

strumFunction:
    STRUM'(' IDENTIFIER ')'
    ;

timesFunction:
    TIMES'('amount=DECIMAL_LITERAL')'
    ;

bassFunction:
    BASS'(' ')'
    ;

addFunction:
    ADD '(' noteLiteral ')'
    ;


//==========================================================
// Literals
//==========================================================

noteLiteral
    : IDENTIFIER
    ;

chordLiteral
    : IDENTIFIER
    ;

number
    : DECIMAL_LITERAL | FLOAT_LITERAL
    ;


 