using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class dlContest : DataAccessBridge
    {
        private enContest _enContest = null;
        public dlContest(enContest enContest_) : base("Contest")
        {
            this._enContest = enContest_;
        }

        public int Create()
        {
            return base.Create(_enContest.Description, _enContest.StartDate, _enContest.EndDate, DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enContest.ID,_enContest.GetByDate))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enContest);
                }
            }
        }

        public List<enContest> ReadAll()
        {
            var listOfContests = new List<enContest>();
            using (IDataReader idr = base.Read(_enContest.ID, _enContest.GetByDate))
            {
                while (idr.Read())
                {
                    var objENContest = new enContest();
                    ConstructObject(idr, objENContest);
                    listOfContests.Add(objENContest);
                }
            }
            return listOfContests;
        }

        public int Update()
        {
            return base.Update(_enContest.ID, _enContest.Description, _enContest.StartDate, _enContest.EndDate, _enContest.InsertedOn, DateTime.Now);
        }

        public int Delete()
        {
            return base.Delete(_enContest.ID);
        }

        private void ConstructObject(IDataReader dr_, enContest enContest_)
        {
            enContest_.ID = Convert.ToInt32(dr_["ID"]);
            enContest_.Description = dr_["Description"].ToString();
            enContest_.StartDate = Convert.ToDateTime(dr_["StartDate"]);
            enContest_.EndDate = Convert.ToDateTime(dr_["EndDate"]);
            enContest_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enContest_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}
