using System;
using System.Collections.Generic;
using System.Text;

namespace TPM.DataAccess.Models
{
    public class BiddingViewModel
    {
        public int BiddingId { get; set; }
        public string Name { get; set; }
        public int LotId { get; set; }
        public int personId { get; set; }
        public int DocumentId { get; set; }
        public int BiddingTypeId { get; set; }
        public int TenderTypeId { get; set; }
        public int ProtocolId { get; set; }

    }
}
