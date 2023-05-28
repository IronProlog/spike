using System;
using System.Linq;
using Collections = System.Collections.Generic;

namespace IronProlog.Model.Term
{
    public class Complex : Term
    {
        public string Functor { get; private set; }
        public Collections.List<Term> Arguments { get; private set; }

        public Complex(string functor, Collections.List<Term> arguments)
        {
            Functor = functor;
            Arguments = arguments;
        }

        public override string ToString()
        {
            var arguments = String.Join(", ", Arguments.Select(x => x.ToString()));

            return $"{Functor}({arguments})";
        }

        public override bool Equals(object obj)
        {
            return obj is Complex compound &&
                   Functor == compound.Functor &&
                   Collections.EqualityComparer<Collections.List<Term>>.Default.Equals(Arguments, compound.Arguments);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Functor, Arguments);
        }
    }
}

