using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class dlContestStatus : DataAccessBridge
    {
        private enContestStatus _enContestStatus = null;
        public dlContestStatus(enContestStatus enContestStatus_)
            : base("ContestStatus")
        {
            this._enContestStatus = enContestStatus_;
        }

        public int Create()
        {
            return base.Create(_enContestStatus.ContestID,_enContestStatus.UserID,_enContestStatus.Status,DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enContestStatus.ID,_enContestStatus.ContestID,_enContestStatus.UserID))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enContestStatus);
                }
            }
        }

        public List<enContestStatus> ReadAll()
        {
            var listOfContestStatus = new List<enContestStatus>();
            using (IDataReader idr = base.Read(_enContestStatus.ID, _enContestStatus.ContestID, _enContestStatus.UserID))
            {
                while (idr.Read())
                {
                    var objENContestStatus = new enContestStatus();
                    ConstructObject(idr, objENContestStatus);
                    listOfContestStatus.Add(objENContestStatus);
                }
            }
            return listOfContestStatus;
        }

        public int Update()
        {
            return base.Update(_enContestStatus.ID, _enContestStatus.ContestID, _enContestStatus.UserID, _enContestStatus.Status,_enContestStatus.InsertedOn, DateTime.Now);
        }

        public int Delete()
        {
            return base.Delete(_enContestStatus.ID);
        }

        private void ConstructObject(IDataReader dr_, enContestStatus enContestStatus_)
        {
            enContestStatus_.ID = Convert.ToInt32(dr_["ID"]);
            enContestStatus_.ContestID = Convert.ToInt32(dr_["ContestID"]);
            enContestStatus_.UserID = Convert.ToInt32(dr_["UserID"]);
            enContestStatus_.Status = Convert.ToBoolean(dr_["Status"]);
            enContestStatus_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enContestStatus_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}

