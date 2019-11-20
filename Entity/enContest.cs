using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class enContest
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool GetByDate { get; set; }
    }
}
