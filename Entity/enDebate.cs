using System;

namespace Entity
{
    public class enDebate
    {
        public int ID { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public bool IsActive { get; set; }
        public int? User_ID { get; set; }
        public int? LikesCount { get; set; }
        public int Category_ID { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        //public int LikeCount { get; set; }

        public bool IsGetSuccess { get; set; }
        public int RecordsCount { get; set; }

        #region Aggregate
        public enCategory Category_ { get; set; }
        public enUser User_ { get; set; }
        #endregion

    }
}
