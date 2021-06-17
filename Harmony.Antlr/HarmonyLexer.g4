lexer grammar HarmonyLexer;

//==========================================================
// Global
//==========================================================

UNIT : 'unit';

//==========================================================
// Attributes
//==========================================================

ATR_NAME : 'name';
ATR_TEMPO : 'tempo';
ATR_DURATION : 'duration';
ATR_AUTHOR : 'author';

//==========================================================
// Statements
//==========================================================


NOTE : 'note';
CHORD : 'chord';


//==========================================================
// Functions
//==========================================================

TRANSPOSE : 'transpose';
PROPAGATE : 'propagate';
ARPEGGIATE : 'arpeggiate';
PLAYWITH : 'playWith';
TIMES : 'times';

//==========================================================
// Tokens
//==========================================================

LPAREN:             '(';
RPAREN:             ')';
LBRACE:             '{';
RBRACE:             '}';
COMMA:              ',';
DOT:                '.';
SEMI:               ';';
COLON :             ':';
SHARP :             '#';
FUNC :              '->';
LBRACKET :          '[';
RBRACKET :          ']';

WS:  [ \t\r\n\u000C]+ -> channel(HIDDEN);

IDENTIFIER: Letter SHARP? LetterOrDigit*;

DECIMAL_LITERAL:   '-'? ('0' | [1-9] (Digits? | '_'+ Digits)) [lL]?;

FLOAT_LITERAL:  (Digits '.' Digits? | '.' Digits) 
             ;

//==========================================================
// Fragments
//==========================================================

fragment Digits
    : [0-9] ([0-9_]* [0-9])?
    ;
fragment LetterOrDigit
    : Letter
    | [0-9]
    ;
fragment Letter
    : [a-zA-Z$_] // these are the "java letters" below 0x7F
    | ~[\u0000-\u007F\uD800-\uDBFF] // covers all characters above 0x7F which are not a surrogate
    | [\uD800-\uDBFF] [\uDC00-\uDFFF] // covers UTF-16 surrogate pairs encodings for U+10000 to U+10FFFF
    ;
