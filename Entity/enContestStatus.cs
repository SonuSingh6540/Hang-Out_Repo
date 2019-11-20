using System;

namespace Entity
{
    public class enContestStatus
    {
        public int ID { get; set; }
        public int ContestID { get; set; }
        public int UserID { get; set; }
        public bool Status { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public enContest Contest_ { get; set; }
        public enUser User_ { get; set; }
    }
}
