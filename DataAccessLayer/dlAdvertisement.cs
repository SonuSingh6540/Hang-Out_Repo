using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class dlAdvertisement : DataAccessBridge
    {
        private enAdvertisement _enAdvertisement = null;
        public dlAdvertisement(enAdvertisement enAdvertisement_)
            : base("Advertisement")
        {
            this._enAdvertisement = enAdvertisement_;
        }

        public int Create()
        {
            return base.Create(_enAdvertisement.Vendor_Name,_enAdvertisement.Image_Name,_enAdvertisement.Url,_enAdvertisement.Date_To,_enAdvertisement.Date_From,_enAdvertisement.Time_To,_enAdvertisement.Time_From,_enAdvertisement.Amount,_enAdvertisement.Reference_Code,_enAdvertisement.Content_ID,_enAdvertisement.Position, DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enAdvertisement.ID,_enAdvertisement.Content_ID,_enAdvertisement.Reference_Code,null,null))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enAdvertisement);
                    _enAdvertisement.IsGetSuccess = true;
                }
            }
        }

        public List<enAdvertisement> ReadAll()
        {
            var listOfAdvertisements = new List<enAdvertisement>();
            using (IDataReader idr = base.Read(_enAdvertisement.ID,_enAdvertisement.Content_ID,_enAdvertisement.Reference_Code, null, null))
            {
                while (idr.Read())
                {
                    var objENAdvertisement = new enAdvertisement();
                    ConstructObject(idr, objENAdvertisement);
                    listOfAdvertisements.Add(objENAdvertisement);
                    _enAdvertisement.IsGetSuccess = true;
                }
            }
            return listOfAdvertisements;
        }

        public int Update()
        {
            return base.Update(_enAdvertisement.ID,_enAdvertisement.Vendor_Name, _enAdvertisement.Image_Name, _enAdvertisement.Url, _enAdvertisement.Date_To, _enAdvertisement.Date_From, _enAdvertisement.Time_To, _enAdvertisement.Time_From, _enAdvertisement.Amount,_enAdvertisement.Reference_Code, _enAdvertisement.Content_ID, _enAdvertisement.Position, _enAdvertisement.InsertedOn,DateTime.Now);
        }

        public int Delete()
        {
            return base.Delete(_enAdvertisement.ID);
        }

        private void ConstructObject(IDataReader dr_, enAdvertisement enAdvertisement_)
        {
            enAdvertisement_.ID = Convert.ToInt32(dr_["ID"]);
            enAdvertisement_.Vendor_Name = dr_["Vendor_Name"].ToString();
            enAdvertisement_.Image_Name = dr_["ImageName"].ToString();
            enAdvertisement_.Url = dr_["Url"].ToString();
            enAdvertisement_.Date_To = Convert.ToDateTime(dr_["Date_To"]);
            enAdvertisement_.Date_From = Convert.ToDateTime(dr_["Date_From"]);
            enAdvertisement_.Time_To = TimeSpan.Parse(dr_["Time_To"].ToString());
            enAdvertisement_.Time_From = TimeSpan.Parse(dr_["Time_From"].ToString());
            enAdvertisement_.Amount = Convert.ToDouble(dr_["Amount"]);
            enAdvertisement_.Reference_Code = dr_["Reference_Code"].ToString();
            enAdvertisement_.Content_ID = Convert.ToInt32(dr_["Content_ID"]);
            enAdvertisement_.Position = Convert.ToInt32(dr_["Position"]);
            enAdvertisement_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
            enAdvertisement_.ModifiedOn = DBNull.Value == dr_["ModifiedOn"] ? (DateTime?)null : Convert.ToDateTime(dr_["ModifiedOn"]);
        }
    }
}
