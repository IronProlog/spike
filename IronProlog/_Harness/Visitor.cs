using System;
using System.Linq;
using Antlr4.Runtime.Misc;
using IronProlog.Model;
using IronProlog.Parser;

namespace IronProlog._Harness
{
    public class Visitor : PrologBaseVisitor<object>
    {
        public override object VisitFact([NotNull] PrologParser.FactContext context)
        {
            var functor = context.compound().functor();
            var terms = context.compound().term();

            var fact = new Fact(new Compound(
                functor.GetText(),
                terms.Select(a => (Term)Visit(a)).ToList()
            ));

            Console.WriteLine(fact);

            return base.VisitFact(context);
        }

        public override object VisitCompound_term([NotNull] PrologParser.Compound_termContext context)
        {
            var functor = context.compound().functor();
            var terms = context.compound().term();

            var term = new Compound(
                functor.GetText(),
                terms.Select(a => (Term)Visit(a)).ToList()
            );

            return term;
        }

        public override object VisitAtom_term([NotNull] PrologParser.Atom_termContext context)
        {
            return new Atom(context.GetText());
        }

        public override object VisitVariable_term([NotNull] PrologParser.Variable_termContext context)
        {
            return new Variable(context.GetText());
        }

        public override object VisitNumber_term([NotNull] PrologParser.Number_termContext context)
        {
            return new Number(context.GetText());
        }
    }
}

