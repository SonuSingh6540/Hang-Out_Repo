using System;
namespace Entity
{
    public class enPayment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string E_Mail { get; set; }
        public string Transection_ID { get; set; }
        public string Reference_Code { get; set; }
        public Double Amount { get; set; }
        public DateTime InsertedOn { get; set; }
        public string Message { get; set; }

        #region Aggregate
        public enUser User_ { get; set; }
        #endregion
    }
}
