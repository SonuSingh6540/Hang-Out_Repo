using System;

namespace Entity
{
    public class enLikeCounter
    {
        public int ID { get; set; }
        public int Debate_ID { get; set; }
        public int User_ID { get; set; }
        public int Comment_ID { get; set; }
        public int Type { get; set; }
        public DateTime InsertedOn { get; set; }

        public bool IsGetSuccess { get; set; }
        public int RecordsCount { get; set; }
    }
}
