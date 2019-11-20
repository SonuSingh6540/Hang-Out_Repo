using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using BusinessLogicLayer;
using DAL = DataAccessLayer.dlPayment;

namespace BusinessLogicLayer
{
    public class blPayment
    {
        private enPayment _enPayment = null;
        private DAL _objDAL = null;

        public blPayment(enPayment enPayment_)
        {
            this._enPayment = enPayment_;
        }

        public int Create()
        {
            return GetDALReference().Create();
        }

        public void Read()
        {
            GetDALReference().Read();
        }

        public List<enPayment> ReadAll()
        {
            return GetDALReference().ReadAll();
        }

        public void ReadAndAggregate(params Type[] entitiesToAggregate_)
        {
            Read();
            //if (!_enComment.IsGetSuccess)
            //    return;
            Aggregate(entitiesToAggregate_);
        }

        public List<enPayment> ReadAllAndAggregate(int? startRowNumber_ = null, int? endRowNumber_ = null, params Type[] entitiesToAggregate_)
        {
            List<enPayment> listOfPayments = ReadAll();

            foreach (var item in listOfPayments)
            {
                var objBLComment = new blPayment(item);
                objBLComment.Aggregate(entitiesToAggregate_);
            }

            return listOfPayments;
        }

        private void Aggregate(params Type[] entitiesToAggregate_)
        {
            if (entitiesToAggregate_.FirstOrDefault(item => item == typeof(enUser)) != null)
            {
                _enPayment.User_ = new enUser() { Reference_Code = _enPayment.Reference_Code };
                var objBLUser = new blUser(_enPayment.User_);
                objBLUser.Read();
            }
        }

        private DAL GetDALReference()
        {
            if (_objDAL == null)
            {
                _objDAL = new DAL(this._enPayment);
            }
            return _objDAL;
        }
    }
}
