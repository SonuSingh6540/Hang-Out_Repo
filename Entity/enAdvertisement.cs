using System;
using System.Collections.Generic;
using System.Web;

namespace Entity
{
    public class enAdvertisement
    {
        public int ID { set; get; }
        public string Vendor_Name { get; set; }
        public string Image_Name { get; set; }
        public string Url { get; set; }
        public DateTime Date_To { get; set; }
        public DateTime Date_From { get; set; }
        public TimeSpan Time_To { get; set; }
        public TimeSpan Time_From { get; set; }
        public double Amount { get; set; }
        public string Reference_Code { get; set; }
        public int Content_ID { get; set; }
        public int Position { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public HttpPostedFileBase AdvertisementImage { get; set; }
        public bool IsGetSuccess { get; set; }
        public int RecordsCount { get; set; }
    }
    public class enAdvertisementModel
    {
        public enAdvertisement Advertisement_ { get; set; }
        public List<enAdvertisement> listOfAdvertisements { get; set; }
    }
}
