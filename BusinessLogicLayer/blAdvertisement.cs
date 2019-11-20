using Entity;
using System.Collections.Generic;
using DAL = DataAccessLayer.dlAdvertisement;

namespace BusinessLogicLayer
{
    public class blAdvertisement
    {
        private enAdvertisement _enAdvertisement = null;
        private DAL _objDAL = null;

        public enAdvertisement GetEntityReference { get { return _enAdvertisement; } }

        public blAdvertisement(enAdvertisement enAdvertisement_)
        {
            this._enAdvertisement = enAdvertisement_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enAdvertisement> ReadAll()
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
                _objDAL = new DAL(this._enAdvertisement);
            }
            return _objDAL;
        }
    }
}
