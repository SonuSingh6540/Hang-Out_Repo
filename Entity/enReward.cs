using System;

namespace Entity
{
    public class enReward
    {
        public int ID { get; set; }
        public int Point { get; set; }
        public int User_ID { get; set; }
        public int Type { get; set; }
        public DateTime InsertedOn { get; set; }

        public bool IsGetSuccess { get; set; }
        public int RecordsCount { get; set; }
    }
}
