using System.Collections.Generic;
using System.Web;

namespace Entity
{
    public class enDebateAdvertisementImage
    {
        public int ID { get; set; }
        public int FKDebateAdvertisementId { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
        public List<HttpPostedFileBase> files { get; set; }
    }
}
