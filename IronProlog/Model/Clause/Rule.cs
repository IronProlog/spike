using System;
using System.Collections.Generic;
using IronProlog.Model.Term;

namespace IronProlog.Model.Clause
{
    public class Rule : Clause
    {
        public Complex Head { get; private set; }
        public Conjunction.Conjunction Body { get; private set; }

        public Rule(Complex head, Conjunction.Conjunction body)
        {
            Head = head;
            Body = body;
        }

        public override string ToString()
        {
            return Head.ToString() + " :- " + Body.ToString() + ".";
        }

        public override bool Equals(object obj)
        {
            return obj is Rule rule &&
                   EqualityComparer<Complex>.Default.Equals(Head, rule.Head) &&
                   EqualityComparer<Conjunction.Conjunction>.Default.Equals(Body, rule.Body);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Head, Body);
        }
    }
}

