using System;
using System.Collections.Generic;
using System.Text;

namespace QueryObjectPattern
{
    public class PostDetailQuery
    {
        public int? Id { get; set; }
        public DateTime? Created { get; set; }

        public PostDetailQuery(int? id, DateTime? created)
        {
            this.Id = id;
            this.Created = created;
        }    
    }
}
