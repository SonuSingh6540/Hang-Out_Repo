using Entity;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlDebateAdvertisementImage;

namespace BusinessLogicLayer
{
    public class blDebateAdvertisementImage
    {
        private enDebateAdvertisementImage _enDebateAdvertisementImage = null;
        private DAL _objDAL = null;

        public enDebateAdvertisementImage GetEntityReference { get { return _enDebateAdvertisementImage; } }

        public blDebateAdvertisementImage(enDebateAdvertisementImage enDebateAdvertisementImage_)
        {
            this._enDebateAdvertisementImage = enDebateAdvertisementImage_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enDebateAdvertisementImage> ReadAll()
        {
            return GetDALReference().ReadAll();
        }

        public int Update()
        {
            return GetDALReference().Update();
        }

        public int Delete()
        {
            return GetDALReference().Delete();
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enDebateAdvertisementImage);
            }
            return _objDAL;
        }
    }
}
