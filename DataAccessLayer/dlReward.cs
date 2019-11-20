using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
   public class dlReward : DataAccessBridge
    {
        private enReward _enReward = null;
        public dlReward(enReward enReward_)
            : base("Reward")
        {
            this._enReward = enReward_;
        }

        public int Create()
        {
            return base.Create(_enReward.Point,_enReward.Type,_enReward.User_ID, DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enReward.ID,_enReward.User_ID, null, null))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enReward);
                    _enReward.IsGetSuccess = true;
                }
            }
        }

        public List<enReward> ReadAll(int? startRowIndex_ = null, int? endRowIndex_ = null)
        {
            var listOfRewards = new List<enReward>();
            using (IDataReader idr = base.Read(_enReward.ID,_enReward.User_ID, null, null))
            {
                while (idr.Read())
                {
                    var objENReward = new enReward();
                    ConstructObject(idr, objENReward);
                    listOfRewards.Add(objENReward);
                    _enReward.IsGetSuccess = true;
                }
            }
            return listOfRewards;
        }

        private void ConstructObject(IDataReader dr_, enReward enReward_)
        {
            enReward_.ID = Convert.ToInt32(dr_["ID"]);
            enReward_.Point = Convert.ToInt32(dr_["Point"]);
            enReward_.Type = Convert.ToInt32(dr_["Type"]);
            enReward_.User_ID = Convert.ToInt32(dr_["User_ID"]);
            enReward_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
        }

    }
}
