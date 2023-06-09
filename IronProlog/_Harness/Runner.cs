﻿using System;
using Antlr4.Runtime;
using IronProlog.Parser;
using static System.Net.Mime.MediaTypeNames;

namespace IronProlog._Harness
{
    public class Runner
    {
        public void Run()
        {
            //var text = "foo(bar(baz), X) :- body(X); a(X), b(X).";
            //var text = "foo(X) :- bar([[], dead(zed), [2, [b, chopper]], [], Z, [2, [b, chopper]]]).";
            var text = "foo([_,X,_,Y|_]) :- bar([[], dead(zed), [2, [b, chopper]], [], Z]).";

            AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
            PrologLexer lexer = new PrologLexer(inputStream);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            PrologParser parser = new PrologParser(tokens);

            PrologParser.Knowledge_baseContext context = parser.knowledge_base();
            Visitor visitor = new Visitor();
            visitor.Visit(context);
        }
    }
}

