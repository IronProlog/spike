using System;
using System.Collections.Generic;
using IronProlog.Model.Term;

namespace IronProlog.Model.Conjunction
{
    public class Leaf : Conjunction
    {
        public Complex Term { get; private set; }

        public Leaf(Complex term)
        {
            Term = term;
        }

        public override string ToString()
        {
            return Term.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Leaf leaf &&
                   EqualityComparer<Complex>.Default.Equals(Term, leaf.Term);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Term);
        }
    }
}

