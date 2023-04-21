using System;
using System.Linq;
using System.Collections.Generic;

namespace IronProlog.Model
{
    public class    Compound : Term
    {
        public string Functor { get; private set; }
        public List<Term> Arguments { get; private set; }

        public Compound(string functor, List<Term> arguments)
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
            return obj is Compound compound &&
                   Functor == compound.Functor &&
                   EqualityComparer<List<Term>>.Default.Equals(Arguments, compound.Arguments);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Functor, Arguments);
        }
    }
}

