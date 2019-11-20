using System;
using System.Web;
using System.Collections.Generic;

namespace Entity
{
   public class enQuery
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string E_Mail { get; set; }
        public string Contact { get; set; }
        public string Subject { get; set; }
        public int? Topic_Type { get; set; }
        public string Message { get; set; }
        public string File_Name { get; set; }
        public int Type { get; set; }
        public int User_ID { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public IEnumerable<HttpPostedFileBase> files { get; set; }
        public bool IsGetSuccess { get; set; }

        public List<enAdvertisementImage> ListOfAdvertisementImages { get; set; } 
    }
}
