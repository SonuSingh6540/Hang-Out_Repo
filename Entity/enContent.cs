using System;

namespace Entity
{
    public class enContent
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsGetSuccess { get; set; }
    }
}
