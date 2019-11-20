using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL = DataAccessLayer.dlDebateAdvertisement;

namespace BusinessLogicLayer
{
    public class blDebateAdvertisement
    {
        private enDebateAdvertisement _enDebateAdvertisement = null;
        private DAL _objDAL = null;

        public enDebateAdvertisement GetEntityReference { get { return _enDebateAdvertisement; } }

        public blDebateAdvertisement(enDebateAdvertisement enDebateAdvertisement_)
        {
            this._enDebateAdvertisement = enDebateAdvertisement_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public int Update()
        {
            return GetDALReference().Update();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enDebateAdvertisement> ReadAll()
        {
            return GetDALReference().ReadAll();
        }

        public void ReadAndAggregate(params Type[] entitiesToAggregate_)
        {
            Read();
            Aggregate(entitiesToAggregate_);
        }

        public List<enDebateAdvertisement> ReadAllAndAggregate(params Type[] entitiesToAggregate_)
        {
            List<enDebateAdvertisement> listOfDebateAdvertisements = ReadAll();

            foreach (var item in listOfDebateAdvertisements)
            {
                var objBLDebateAdvertisement = new blDebateAdvertisement(item);
                objBLDebateAdvertisement.Aggregate(entitiesToAggregate_);
            }
            return listOfDebateAdvertisements;
        }

        private void Aggregate(params Type[] entitiesToAggregate_)
        {
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enDebateAdvertisementImage)) != null)
            {
                var objENDebateAdvertisementImage = new enDebateAdvertisementImage() { FKDebateAdvertisementId = _enDebateAdvertisement.ID };
                var objBlDebateAdvertisementImage = new blDebateAdvertisementImage(objENDebateAdvertisementImage);
                _enDebateAdvertisement.ListOfDebateAdvertisementImage_ = objBlDebateAdvertisementImage.ReadAll();
            }
        }

        public int Delete()
        {
            return GetDALReference().Delete();
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enDebateAdvertisement);
            }
            return _objDAL;
        }
    }
}
