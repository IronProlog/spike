using System;

namespace IronProlog.Model.Term
{
    public class Variable : Term
    {
        public string Name { get; private set; }

        public Variable(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Variable atom &&
                   Name == atom.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}

