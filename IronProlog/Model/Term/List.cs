using System;
using System.Collections.Generic;
using Collections = System.Collections.Generic;

namespace IronProlog.Model.Term
{
    public class List : Term
    {
        public Collections.List<Term> Items { get; private set; }

        public List(Collections.List<Term> items)
        {
            Items = items;
        }

        public override string ToString()
        {
            return "[" + String.Join(", ", Items) + "]";
        }

        public override bool Equals(object obj)
        {
            return obj is List list &&
                   EqualityComparer<List<Term>>.Default.Equals(Items, list.Items);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Items);
        }
    }
}

