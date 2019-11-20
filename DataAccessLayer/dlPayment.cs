using Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class dlPayment : DataAccessBridge
    {
        private enPayment _enPayment = null;

        public dlPayment(enPayment enPayment_)
            :base("Payment")
        {
            this._enPayment = enPayment_;
        }

        public int Create()
        {
            return base.Create(_enPayment.Name,_enPayment.E_Mail,_enPayment.Transection_ID,_enPayment.Reference_Code,_enPayment.Amount,DateTime.Now);
        }

        public void Read()
        {
            using (IDataReader idr = base.Read(_enPayment.ID, _enPayment.Reference_Code))
            {
                if(idr.Read())
                {
                    ConstructObject(idr, _enPayment);
                }
            }
        }

        public List<enPayment> ReadAll()
        {
            var listOfPayments = new List<enPayment>();
            using (IDataReader idr = base.Read(_enPayment.ID, _enPayment.Reference_Code))
            {
                while(idr.Read())
                {
                    var objENPayment = new enPayment();
                    ConstructObject(idr, objENPayment);
                    listOfPayments.Add(objENPayment);
                }
            }
            return listOfPayments;
        }

        private void ConstructObject(IDataReader dr_, enPayment enPayment_)
        {
            enPayment_.ID = Convert.ToInt32(dr_["ID"]);
            enPayment_.Name = dr_["Name"].ToString();
            enPayment_.E_Mail = dr_["E_Mail"].ToString();
            enPayment_.Transection_ID = dr_["Transection_ID"].ToString();
            enPayment_.Reference_Code = dr_["Reference_Code"].ToString();
            enPayment_.Amount = Convert.ToDouble(dr_["Amount"]);
            enPayment_.InsertedOn = Convert.ToDateTime(dr_["InsertedOn"]);
        }
    }
}
