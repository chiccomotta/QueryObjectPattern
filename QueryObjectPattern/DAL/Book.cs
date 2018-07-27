using System;
using System.Collections.Generic;
using System.Text;

namespace QueryObjectPattern.DAL
{
    public class Book<T>
    {
        public int Id { get; set; }
        public T Spice { get; set; }
    }
}
