parser grammar HarmonyParser;

options { tokenVocab=HarmonyLexer; }

//==========================================================
// Unit
//==========================================================

compilationUnit
    : attributes unitDeclaration* EOF
    ;

attributes
    : ('name' ':' name=IDENTIFIER) 
      ('author' ':' author=IDENTIFIER)
      ('duration' ':' duration=number)
      ('tempo' ':' tempo=DECIMAL_LITERAL)
    ;

unitDeclaration
    : UNIT IDENTIFIER block
    ;

block
    : '{' (blockStatement)* '}'
    ;

blockStatement
    : statement('->'function)*
    ;



//==========================================================
// Statements
//==========================================================

statement
    : noteStatement
    | chordStatement
    ;

noteStatement
    : (NOTE  noteLiteral '('  startTime=number ',' duration=number ',' velocity=number  ')' )
    ;

chordStatement
    : (CHORD  chordLiteral '('  startTime=number ',' duration=number ',' velocity=number  ',' octave=DECIMAL_LITERAL ')' )
    ;

//==========================================================
// Functions
//==========================================================

function
    : transposeFunction
    | propagateFunction
    | arpeggiateFunction
    ;

propagateFunction:
    PROPAGATE'('amount=DECIMAL_LITERAL')'
    ;

transposeFunction:
    TRANSPOSE'('value=DECIMAL_LITERAL')'
    ;

arpeggiateFunction:
    ARPEGGIATE'('offset=number')'
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


 