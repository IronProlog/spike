grammar Prolog;

knowledge_base
    :   clause+ EOF
    ;

clause
    :   fact
    ;

fact
    :   compound STOP
    ;

compound
    :   functor '(' term (COMMA term)* ')'
    ;

functor
    :   ATOM
    ;

term
    :   compound    # compound_term
    |   ATOM        # atom_term
    |   VARIABLE    # variable_term
    |   NUMBER      # number_term
    ;

ATOM
    :   [a-z] [a-zA-Z_]*
    |   '\'' .+? '\''
    ;

VARIABLE
    :   [A-Z] [a-zA-Z_]*
    ;

NUMBER
    :   [0-9]+ ('.' [0-9]+)?
    ;

COMMA
    :   ','
    ;

STOP
    :   '.'
    ;

WHITESPACE
    :   [ \t\r\n] -> channel(HIDDEN)
    ;