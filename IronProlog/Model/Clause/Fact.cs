using System;
using System.Linq;
using System.Collections.Generic;

namespace IronProlog.Model
{
    public class Fact : Clause
    {
        public Compound Term { get; private set; }

        public Fact(Compound term)
        {
            Term = term;
        }

        public override string ToString()
        {
            return Term.ToString() + ".";
        }

        public override bool Equals(object obj)
        {
            return obj is Fact fact &&
                   EqualityComparer<Compound>.Default.Equals(Term, fact.Term);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Term);
        }
    }
}

