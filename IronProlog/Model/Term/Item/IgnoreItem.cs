using System;
namespace IronProlog.Model.Term.Item
{
    public class IgnoreItem : Item
    {
        public IgnoreItem() { }

        public override string ToString()
        {
            return "_";
        }
    }
}

