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
ATR_AUTHOR : 'author';

//==========================================================
// Statements
//==========================================================


NOTE : 'note';
CHORD : 'chord';
STEP : 'step';


//==========================================================
// Functions
//==========================================================

TRANSPOSE : 'transpose';
PROPAGATE : 'propagate';
STRUM : 'strum';
TIMES : 'times';
BASS : 'bass';

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
LBRACKET :          '[';
RBRACKET :          ']';

WS:  [ \t\r\n\u000C]+ -> channel(HIDDEN);

COMMENT:            '/*' .*? '*/'    -> channel(HIDDEN);
LINE_COMMENT:       '//' ~[\r\n]*    -> channel(HIDDEN);

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
