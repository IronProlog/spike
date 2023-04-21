using System;

namespace IronProlog.Model
{
    public class Number : Term
    {
        public string Name { get; private set; }

        public Number(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Number atom &&
                   Name == atom.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
