using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class dlAdvertisementImage : DataAccessBridge
    {
        private enAdvertisementImage _enAdvertisementImage = null;

        public dlAdvertisementImage(enAdvertisementImage enAdvertisementImage_)
            :base("AdvertisementImage")
        {
            this._enAdvertisementImage = enAdvertisementImage_;
        }

        public int Create()
        {
            return base.Create(_enAdvertisementImage.Name,_enAdvertisementImage.Advertisement_ID,DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enAdvertisementImage.ID,_enAdvertisementImage.Advertisement_ID))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enAdvertisementImage);
                }
            }
        }

        public List<enAdvertisementImage> ReadAll()
        {
            var listofAdvertisementImages = new List<enAdvertisementImage>();
            using (IDataReader idr = base.Read(_enAdvertisementImage.ID,_enAdvertisementImage.Advertisement_ID))
            {
                while (idr.Read())
                {
                    var objENAdvertisementImage = new enAdvertisementImage();
                    ConstructObject(idr, objENAdvertisementImage);
                    listofAdvertisementImages.Add(objENAdvertisementImage);
                }
            }
            return listofAdvertisementImages;
        }

        public int Delete()
        {
            return base.Delete(_enAdvertisementImage.ID);
        }

        private void ConstructObject(IDataReader dr_, enAdvertisementImage enAdvertisementImage_)
        {
            enAdvertisementImage_.ID = Convert.ToInt32(dr_["ID"]);
            enAdvertisementImage_.Name = dr_["Name"].ToString();
            enAdvertisementImage_.Advertisement_ID = Convert.ToInt32(dr_["Advertisement_ID"]);
            enAdvertisementImage_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
        }
    }
}
