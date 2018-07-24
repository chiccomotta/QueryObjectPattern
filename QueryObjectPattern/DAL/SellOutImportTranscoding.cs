using System;
using System.Collections.Generic;

namespace QueryObjectPattern.DAL
{
    public partial class SellOutImportTranscoding
    {
        public Guid Id { get; set; }
        public string TranscodingType { get; set; }
        public string SourceValue { get; set; }
        public string DestinationValue { get; set; }
    }
}
