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
    : statement(DOT function)*
    ;


//==========================================================
// Statements
//==========================================================

statement
    : noteStatement
    | chordStatement
    | unitStatement
    | stepStatement
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
    : (STEP target=statement)
    | (STEP duration=number)
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
    | strumFunction
    | timesFunction
    | bassFunction
    ;

propagateFunction:
    PROPAGATE'('amount=DECIMAL_LITERAL')'
    ;

transposeFunction:
    TRANSPOSE'('value=DECIMAL_LITERAL')'
    ;

strumFunction:
    STRUM'('offset=number')'
    ;

timesFunction:
    TIMES'('amount=DECIMAL_LITERAL')'
    ;

bassFunction:
    BASS'(' ')'
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


 