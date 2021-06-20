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
    : statement('->'function)*
    ;


//==========================================================
// Statements
//==========================================================

statement
    : noteStatement
    | chordStatement
    | unitStatement
    ;


unitStatement
    : name=IDENTIFIER
    ;
noteStatement
    : (NOTE  noteLiteral '('  startTime=number ',' duration=number ',' velocity=number  ')' )
    ;

chordStatement
    : (CHORD  chordLiteral '('  startTime=number ',' duration=number ',' velocity=number  ',' octave=DECIMAL_LITERAL ')' )
    ;

//==========================================================
// Statements
//==========================================================


//==========================================================
// Functions
//==========================================================

function
    : transposeFunction
    | propagateFunction
    | arpeggiateFunction
    | playWithFunction
    | timesFunction
    ;

playWithFunction:
    PLAYWITH'('blockStatement')'
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

timesFunction:
    TIMES'('amount=DECIMAL_LITERAL')'
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


 