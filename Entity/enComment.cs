using System;
using System.Collections.Generic;

namespace Entity
{
    public class enComment
    {
        public int ID { set; get;    }
        public string Message { set; get; }
        public int Type { set; get; }
        public int Debate_ID { set; get; }
        public int User_ID { set; get; }
        public DateTime InsertedOn { set; get; }
        public DateTime? ModifiedOn { set; get; }

        public bool IsGetSuccess { set; get; }
        public int RecordsCount { set; get; }

        #region Aggregate
        public enDebate Debate_ { set; get; }
        public enUser User_ { set; get; }
        public enLikeCounter LikeCounter_ { get; set; }
        public List<enLikeCounter> listOfLikeCounter { get; set; }
        #endregion

        #region AdditionProperty
        public int LikesCount { get; set; }
        #endregion
    }

    public class CommentModel
    {
        public List<enComment> listOfComments { get; set; }
        public enComment Comments_ { get; set; }
    }
}
