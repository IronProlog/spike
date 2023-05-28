using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using IronProlog.Model;
using IronProlog.Model.Clause;
using IronProlog.Model.Conjunction;
using IronProlog.Model.Term;
using IronProlog.Model.Term.Item;
using IronProlog.Parser;

namespace IronProlog._Harness
{
    public class Visitor : PrologBaseVisitor<object>
    {
        public override object VisitFact([NotNull] PrologParser.FactContext context)
        {
            var complex = (Complex)Visit(context.complex());
            var fact = new Fact(complex);

            return fact;
        }

        public override object VisitRule([NotNull] PrologParser.RuleContext context)
        {
            var head = (Complex)Visit(context.complex());
            var body = (Conjunction)Visit(context.body());

            var rule = new Rule(head, body);

            Console.WriteLine(rule);

            return rule;
        }

        public override object VisitConnectiveBody([NotNull] PrologParser.ConnectiveBodyContext context)
        {
            var left = (Complex)Visit(context.complex());
            var conjunction = context.connective();
            var right = (Conjunction)Visit(context.body());

            if (conjunction is PrologParser.AndContext)
            {
                return new And(new Leaf(left), right);
            }
            else if (conjunction is PrologParser.OrContext)
            {
                return new Or(new Leaf(left), right);
            }

            throw new Exception("Unrecognized conjunction type.");
        }

        public override object VisitUnaryBody([NotNull] PrologParser.UnaryBodyContext context)
        {
            return new Leaf((Complex)Visit(context.complex()));
        }

        public override object VisitComplex([NotNull] PrologParser.ComplexContext context)
        {
            var functor = context.functor();
            var terms = context.term();

            var complex = new Complex(
                functor.GetText(),
                terms.Select(a => (Term)Visit(a)).ToList()
            );

            return complex;
        }

        public override object VisitTermItem([NotNull] PrologParser.TermItemContext context)
        {
            return new TermItem((Term)Visit(context.term()));
        }

        public override object VisitIgnoreItem([NotNull] PrologParser.IgnoreItemContext context)
        {
            return new IgnoreItem();
        }

        public override object VisitVariableTail([NotNull] PrologParser.VariableTailContext context)
        {
            return Tuple.Create(Tail.Variable, new Variable(context.GetText()));
        }

        public override object VisitEmptyTail([NotNull] PrologParser.EmptyTailContext context)
        {
            return Tuple.Create(Tail.Empty, (Variable)null);
        }

        public override object VisitIgnoreTail([NotNull] PrologParser.IgnoreTailContext context)
        {
            return Tuple.Create(Tail.Ignore, (Variable)null);
        }

        public override object VisitComplexTerm([NotNull] PrologParser.ComplexTermContext context)
        {
            var functor = context.complex().functor();
            var terms = context.complex().term();

            var term = new Complex(
                functor.GetText(),
                terms.Select(a => (Term)Visit(a)).ToList()
            );

            return term;
        }

        public override object VisitListTerm([NotNull] PrologParser.ListTermContext context)
        {
            var items = context.list().term().Select(a => (Term)Visit(a)).ToList();
            return new List(items);
        }

        public override object VisitDeconstructTerm([NotNull] PrologParser.DeconstructTermContext context)
        {
            var head = context.deconstruct().head().item().Select(a => (Item)Visit(a)).ToList();
            var tail = (Tuple<Tail, Variable>)Visit(context.deconstruct().tail());
            return new Deconstruct(head, tail.Item1, tail.Item2);
        }

        public override object VisitAtomTerm([NotNull] PrologParser.AtomTermContext context)
        {
            return new Atom(context.GetText());
        }

        public override object VisitVariableTerm([NotNull] PrologParser.VariableTermContext context)
        {
            return new Variable(context.GetText());
        }

        public override object VisitNumberTerm([NotNull] PrologParser.NumberTermContext context)
        {
            return new Number(context.GetText());
        }
    }
}

