using System;
using System.Collections.Generic;

namespace IronProlog.Model.Term.Item
{
    public class TermItem : Item
    {
        public Term Term { get; private set; }

        public TermItem(Term term)
        {
            Term = term;
        }

        public override string ToString()
        {
            return Term.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is TermItem item &&
                   EqualityComparer<Term>.Default.Equals(Term, item.Term);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Term);
        }
    }
}

