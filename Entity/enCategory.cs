using System;
using System.Web;   

namespace Entity
{
    public class enCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Image_Name { get; set; }

        public HttpPostedFileBase file { get; set; }
        
        public DateTime InsertedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
