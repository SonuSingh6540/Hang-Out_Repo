using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class dlDebate : DataAccessBridge
    {
        private enDebate _enDebate = null;

        public dlDebate(enDebate enDebate_) : base("Debate")
        {
            this._enDebate = enDebate_;
        }

        public int Create()
        {
            return base.Create(_enDebate.Topic,_enDebate.Description,_enDebate.Date,_enDebate.Start,_enDebate.End,_enDebate.IsActive,_enDebate.User_ID,_enDebate.LikesCount,_enDebate.Category_ID, DateTime.Now);
        }

        public int Update()
        {
            return base.Update(_enDebate.ID,_enDebate.Topic,_enDebate.Description, _enDebate.Date, _enDebate.Start, _enDebate.End, _enDebate.IsActive,_enDebate.User_ID,_enDebate.LikesCount,_enDebate.Category_ID,_enDebate.InsertedOn, DateTime.Now);
        }

        public int Delete()
        {
            return base.Delete(_enDebate.ID);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enDebate.ID,_enDebate.Category_ID, null, null))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enDebate);
                    _enDebate.IsGetSuccess = true;
                }
            }
        }

        public List<enDebate> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            var listOfDebates = new List<enDebate>();
            using (IDataReader idr = base.Read(_enDebate.ID, _enDebate.Category_ID, startRowIndex_, endRowIndex_))
            {
                while (idr.Read())
                {
                    var objENDebate = new enDebate();
                    ConstructObject(idr, objENDebate);
                    listOfDebates.Add(objENDebate);
                    _enDebate.IsGetSuccess = true;
                }

                if (idr.NextResult())
                {
                    idr.Read();
                    _enDebate.RecordsCount = Convert.ToInt32(idr["RecordsCount"]);
                }
            }
            return listOfDebates;
        }

        private void ConstructObject(IDataReader dr_, enDebate enDebate_)
        {
            enDebate_.ID = Convert.ToInt32(dr_["ID"]);
            enDebate_.Topic = dr_["Topic"].ToString();
            enDebate_.Description = dr_["Description"].ToString();
            enDebate_.Date = Convert.ToDateTime(dr_["Date"]);
            enDebate_.Start = TimeSpan.Parse(dr_["Start"].ToString());
            enDebate_.End = TimeSpan.Parse(dr_["End"].ToString());
            enDebate_.User_ID = DBNull.Value == dr_["User_ID"] ? (int?)null : Convert.ToInt32(dr_["User_ID"]);
            enDebate_.LikesCount = DBNull.Value == dr_["LikesCount"] ? (int?)null : Convert.ToInt32(dr_["LikesCount"]);
            enDebate_.Category_ID = Convert.ToInt32(dr_["Category_ID"]);
            enDebate_.IsActive = Convert.ToBoolean(dr_["IsActive"]);
            enDebate_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enDebate_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}
