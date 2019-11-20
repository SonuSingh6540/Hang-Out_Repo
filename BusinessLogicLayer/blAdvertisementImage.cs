using Entity;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlAdvertisementImage;

namespace BusinessLogicLayer
{
    public class blAdvertisementImage
    {
        private enAdvertisementImage _enAdvertisementImage = null;
        private DAL _objDAL = null;

        public enAdvertisementImage GetEntityReference { get { return _enAdvertisementImage; } }

        public blAdvertisementImage(enAdvertisementImage enAdvertisementImage_)
        {
            this._enAdvertisementImage = enAdvertisementImage_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enAdvertisementImage> ReadAll()
        {
            return GetDALReference().ReadAll();
        }

        public int Delete()
        {
            return GetDALReference().Delete();
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enAdvertisementImage);
            }
            return _objDAL;
        }
    }
}
