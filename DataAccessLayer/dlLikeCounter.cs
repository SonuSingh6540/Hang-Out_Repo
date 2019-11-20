using Entity;
using System;
using System.Collections.Generic;
using System.Data;


namespace DataAccessLayer
{
  public  class dlLikeCounter :DataAccessBridge
    {
        private enLikeCounter _enLikeCounter = null;
        public dlLikeCounter(enLikeCounter enLikeCounter_)
            : base("LikeCounter")
        {
            this._enLikeCounter = enLikeCounter_;
        }

        public int Create()
        {
            return base.Create(_enLikeCounter.Debate_ID,_enLikeCounter.User_ID,_enLikeCounter.Comment_ID,_enLikeCounter.Type, DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enLikeCounter.ID,_enLikeCounter.Debate_ID,_enLikeCounter.User_ID,_enLikeCounter.Comment_ID, null, null))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enLikeCounter);
                    _enLikeCounter.IsGetSuccess = true;
                }
            }
        }

        public List<enLikeCounter> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            var listOfLikeCounters = new List<enLikeCounter>();
            using (IDataReader idr = base.Read(_enLikeCounter.ID,_enLikeCounter.Debate_ID,_enLikeCounter.User_ID,_enLikeCounter.Comment_ID, startRowIndex_, endRowIndex_))
            {
                while (idr.Read())
                {
                    var objENLikeCounter = new enLikeCounter();
                    ConstructObject(idr, objENLikeCounter);
                    listOfLikeCounters.Add(objENLikeCounter);
                    _enLikeCounter.IsGetSuccess = true;
                }

                if (idr.NextResult())
                {
                    idr.Read();
                    _enLikeCounter.RecordsCount = Convert.ToInt32(idr["RecordsCount"]);
                }
            }
            return listOfLikeCounters;
        }

        private void ConstructObject(IDataReader dr_, enLikeCounter enLikeCounter_)
        {
            enLikeCounter_.ID = Convert.ToInt32(dr_["ID"]);
            enLikeCounter_.Debate_ID = Convert.ToInt32(dr_["Debate_ID"]);
            enLikeCounter_.User_ID = Convert.ToInt32(dr_["User_ID"]);
            enLikeCounter_.Comment_ID = Convert.ToInt32(dr_["Comment_ID"]);
            enLikeCounter_.Type = Convert.ToInt32(dr_["Type"]);
            enLikeCounter_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
        }
    }
}
