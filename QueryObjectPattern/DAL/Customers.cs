using System;
using System.Collections.Generic;

namespace QueryObjectPattern.DAL
{
    public partial class Customers
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int? Matricola { get; set; }
        public int Status { get; set; }
        public DateTime SignUpDate{ get; set; }
    }
}
