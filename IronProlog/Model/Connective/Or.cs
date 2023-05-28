using System;
using System.Collections.Generic;

namespace IronProlog.Model.Conjunction
{
    public class Or : Conjunction
    {
        public Conjunction Left { get; private set; }
        public Conjunction Right { get; private set; }

        public Or(Conjunction left, Conjunction right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return Left.ToString() + "; " + Right.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is And and &&
                   EqualityComparer<Conjunction>.Default.Equals(Left, and.Left) &&
                   EqualityComparer<Conjunction>.Default.Equals(Right, and.Right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Left, Right);
        }
    }
}

