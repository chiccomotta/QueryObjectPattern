using System;
using System.Collections.Generic;

namespace QueryObjectPattern.DAL
{
    public partial class ClientData
    {
        public long ClientId { get; set; }
        public string Data { get; set; }
        public DateTime UpdatedDateUtc { get; set; }
    }
}
