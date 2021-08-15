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
    | notesStatement
    | pedalStatement
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

notesStatement
    :
     NOTES (note= noteLiteral',')* lastNote=noteLiteral '(' duration=number ',' velocity=number ')'
    ;

pedalStatement
    :
    PEDAL (ON | OFF)
    ;


//==========================================================
// Functions
//==========================================================

blockFunction
    :
    current=function (DOT next=blockFunction)?
    ;

function
    : transposeFunction
    | propagateFunction
    | arpeggioFunction
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

arpeggioFunction:
    ARPEGGIO'(' IDENTIFIER ')'
    ;

strumFunction:
    STRUM'(' offset=number ')'
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


 