using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
   public class dlDebateAdvertisement : DataAccessBridge
    {
        private enDebateAdvertisement _enDebateAdvertisement = null;
        public dlDebateAdvertisement(enDebateAdvertisement enDebateAdvertisement_)
            : base("DebateAdvertisement")
        {
            this._enDebateAdvertisement = enDebateAdvertisement_;
        }

        public int Create()
        {
            return base.Create(_enDebateAdvertisement.DateTo,_enDebateAdvertisement.DateFrom,_enDebateAdvertisement.TimeTo,_enDebateAdvertisement.TimeFrom,DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enDebateAdvertisement.ID,_enDebateAdvertisement.GetByDate))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enDebateAdvertisement);
                }
            }
        }

        public List<enDebateAdvertisement> ReadAll()
        {
            var listOfDebateAdvertisements = new List<enDebateAdvertisement>();
            using (IDataReader idr = base.Read(_enDebateAdvertisement.ID,_enDebateAdvertisement.GetByDate))
            {
                while (idr.Read())
                {
                    var objENDebateAdvertisement = new enDebateAdvertisement();
                    ConstructObject(idr, objENDebateAdvertisement);
                    listOfDebateAdvertisements.Add(objENDebateAdvertisement);
                }
            }
            return listOfDebateAdvertisements;
        }

        public int Update()
        {
            return base.Update(_enDebateAdvertisement.ID);
        }

        public int Delete()
        {
            return base.Delete(_enDebateAdvertisement.ID);
        }

        private void ConstructObject(IDataReader dr_, enDebateAdvertisement enDebateAdvertisement_)
        {
            enDebateAdvertisement_.ID = Convert.ToInt32(dr_["ID"]);
            enDebateAdvertisement_.DateTo = Convert.ToDateTime(dr_["DateTo"]);
            enDebateAdvertisement_.DateFrom = Convert.ToDateTime(dr_["DateFrom"]);
            enDebateAdvertisement_.TimeTo = TimeSpan.Parse(dr_["TimeTo"].ToString());
            enDebateAdvertisement_.TimeFrom = TimeSpan.Parse(dr_["TimeFrom"].ToString());
            enDebateAdvertisement_.CreatedOn = Convert.ToDateTime(dr_["CreatedOn"].ToString());
        }
    }
}
