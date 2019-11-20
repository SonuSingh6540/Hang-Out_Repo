using System;
using System.Collections.Generic;

namespace Entity
{
    public class enDebateAdvertisement
    {
        public int ID { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public DateTime CreatedOn { get; set; }
        public int GetByDate { get; set; }

        public List<enDebateAdvertisementImage> ListOfDebateAdvertisementImage_ { get; set; }
    }
}
