using System;
using System.Collections.Generic;
using System.Text;

namespace QueryObjectPattern
{
    // Questa classe rappresenta l'oggetto query con i vari parametri passati nel costruttore
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
