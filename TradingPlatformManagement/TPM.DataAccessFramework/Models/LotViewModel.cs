using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPM.DataAccessFramework.Models
{
    public class LotViewModel
    {
        public int LotId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string StatusText => Status == 0 ? "Open" : "Closed";
        public DateTime? DateOfEndRegistration { get; set; }
        public DateTime? DateOfStartRegistration { get; set; }
        public DateTime? DateOfPub { get; set; }
        public DateTime? DateOfSummarizing { get; set; }
        public DateTime? DateOfBidding { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
