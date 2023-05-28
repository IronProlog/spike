grammar Prolog;

knowledge_base
    :   clause+ EOF
    ;

clause
    :   fact
    |   rule
    ;

fact
    :   complex STOP
    ;

rule
    :   complex IF body STOP
    ;

complex
    :   functor '(' term (COMMA term)* ')'
    ;

body
    :   complex                   # unaryBody
    |   complex connective body   # connectiveBody
    ;

functor
    :   ATOM
    ;

list
    :   '[' (term (COMMA term)*)? ']'
    ;

deconstruct
    :   '[' head '|' tail ']'
    ;

head
    :   item (COMMA item)*
    ;

item
    :   term        # termItem
    |   UNDERSCORE  # ignoreItem
    ;

tail
    :   VARIABLE    # variableTail
    |   '[' ']'     # emptyTail
    |   UNDERSCORE  # ignoreTail
    ;

term
    :   complex     # complexTerm
    |   list        # listTerm
    |   deconstruct # deconstructTerm
    |   ATOM        # atomTerm
    |   VARIABLE    # variableTerm
    |   NUMBER      # numberTerm
    ;

connective
    :   COMMA       # and
    |   SEMICOLON   # or
    ;

ATOM
    :   [a-z] [a-zA-Z_]*
    |   '\'' .+? '\''
    ;

IF
    :   ':-'
    ;

VARIABLE
    :   [A-Z] [a-zA-Z_]*
    ;

NUMBER
    :   [0-9]+ ('.' [0-9]+)?
    ;

UNDERSCORE
    :   '_'
    ;

COMMA
    :   ','
    ;

SEMICOLON
    :   ';'
    ;


STOP
    :   '.'
    ;

WHITESPACE
    :   [ \t\r\n] -> channel(HIDDEN)
    ;