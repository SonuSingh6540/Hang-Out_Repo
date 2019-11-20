using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class dlDebateAdvertisementImage : DataAccessBridge
    {
        private enDebateAdvertisementImage _enDebateAdvertisementImage = null;
        public dlDebateAdvertisementImage(enDebateAdvertisementImage enDebateAdvertisementImage_)
            : base("DebateAdvertisementImage")
        {
            this._enDebateAdvertisementImage = enDebateAdvertisementImage_;
        }

        public int Create()
        {
            return base.Create(_enDebateAdvertisementImage.FKDebateAdvertisementId, _enDebateAdvertisementImage.ImagePath,_enDebateAdvertisementImage.Url);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enDebateAdvertisementImage.ID, _enDebateAdvertisementImage.FKDebateAdvertisementId))
            {
                if (idr.Read())
                {
                    ConstructObject(idr, _enDebateAdvertisementImage);
                }
            }
        }

        public List<enDebateAdvertisementImage> ReadAll()
        {
            var listOfDebateAdvertisementImages = new List<enDebateAdvertisementImage>();
            using (IDataReader idr = base.Read(_enDebateAdvertisementImage.ID, _enDebateAdvertisementImage.FKDebateAdvertisementId))
            {
                while (idr.Read())
                {
                    var objENDebateAdvertisementImage = new enDebateAdvertisementImage();
                    ConstructObject(idr, objENDebateAdvertisementImage);
                    listOfDebateAdvertisementImages.Add(objENDebateAdvertisementImage);
                }
            }
            return listOfDebateAdvertisementImages;
        }

        public int Update()
        {
            return base.Update(_enDebateAdvertisementImage.ID,_enDebateAdvertisementImage.FKDebateAdvertisementId,_enDebateAdvertisementImage.ImagePath,_enDebateAdvertisementImage.Url);
        }

        public int Delete()
        {
            return base.Delete(_enDebateAdvertisementImage.ID);
        }

        private void ConstructObject(IDataReader dr_, enDebateAdvertisementImage enDebateAdvertisementImage_)
        {
            enDebateAdvertisementImage_.ID = Convert.ToInt32(dr_["ID"]);
            enDebateAdvertisementImage_.FKDebateAdvertisementId = Convert.ToInt32(dr_["FKDebateAdvertisementId"]);
            enDebateAdvertisementImage_.ImagePath = dr_["ImagePath"].ToString();
            enDebateAdvertisementImage_.Url = dr_["Url"].ToString();
        }
    }
}
