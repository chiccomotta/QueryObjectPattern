using System;
using System.Collections.Generic;

namespace QueryObjectPattern.DAL
{
    public partial class RegulatoryEmailHistory
    {
        public int Id { get; set; }
        public Guid? ProductId { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string EmailRecipients { get; set; }
        public DateTime? SentDateTime { get; set; }
    }
}
