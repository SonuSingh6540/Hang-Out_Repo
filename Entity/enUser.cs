using System;

namespace Entity
{
    public class enUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string E_Mail { get; set; }
        public string Password { get; set; }
        public int Country { get; set; }
        public string Contact { get; set; }
        public string OTP { get; set; }
        public string Reference_Code { get; set; }
        public string Sponsor_ID { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsGetSuccess { get; set; }
        public int RecordsCount { get; set; }

        public string VerificationCode { get; set; }
        public bool Verified { get; set; }
        public bool Status { get; set; }
        public int ContestID { get; set; }

        #region ExtraField
        public Decimal Amount { get; set; }
        #endregion
    }
}
