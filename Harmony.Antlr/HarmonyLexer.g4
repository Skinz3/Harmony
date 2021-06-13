lexer grammar HarmonyLexer;

UNIT : 'unit';
NOTE : 'note';

LPAREN:             '(';
RPAREN:             ')';
LBRACE:             '{';
RBRACE:             '}';
COMMA:              ',';
DOT:                '.';
SEMI:               ';';
COLON :             ':';

IDENTIFIER:         Letter LetterOrDigit*;

FLOAT_LITERAL:      (Digits '.' Digits? | '.' Digits) 
             ;

fragment Digits
    : [0-9] ([0-9_]* [0-9])?
    ;

fragment LetterOrDigit
    : Letter
    | [0-9]
    ;

fragment Letter
    : [a-zA-Z$_] 
    | ~[\u0000-\u007F\uD800-\uDBFF] 
    | [\uD800-\uDBFF] [\uDC00-\uDFFF] 
    ;




WS: [ \t\r\n\u000C]+ -> channel(HIDDEN);
