﻿using System;
using System.Linq;
using System.Collections.Generic;
using IronProlog.Model.Term;

namespace IronProlog.Model.Clause
{
    public class Fact : Clause
    {
        public Complex Term { get; private set; }

        public Fact(Complex term)
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
                   EqualityComparer<Complex>.Default.Equals(Term, fact.Term);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Term);
        }
    }
}

