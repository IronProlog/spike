using System;
using System.Collections.Generic;
using Collections = System.Collections.Generic;

namespace IronProlog.Model.Term
{
    public enum Tail
    {
        Variable,
        Empty,
        Ignore
    }

    public class Deconstruct : Term
    {
        public Collections.List<Item.Item> Head { get; private set; }
        public Tail Tail { get; private set; }
        public Variable Variable { get; private set; }

        public Deconstruct(Collections.List<Item.Item> head, Tail tail, Variable variable = null)
        {
            Head = head;
            Tail = tail;
            Variable = variable;
        }

        public override string ToString()
        {
            var head = String.Join(", ", Head);
            var tail = Tail switch
            {
                Tail.Variable => Variable.ToString(),
                Tail.Empty => "[]",
                Tail.Ignore => "_",
                _ => "?"
            };

            return "[" + head + " | " + tail + "]";
        }

        public override bool Equals(object obj)
        {
            return obj is Deconstruct deconstruct &&
                   EqualityComparer<List<Item.Item>>.Default.Equals(Head, deconstruct.Head) &&
                   Tail == deconstruct.Tail &&
                   EqualityComparer<Variable>.Default.Equals(Variable, deconstruct.Variable);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Head, Tail, Variable);
        }
    }
}

