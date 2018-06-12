
namespace TPM.DataAccessFramework.Models
{
    public class BiddingViewModel
    {
        public int BiddingId { get; set; }
        public string Name { get; set; }
        public LotViewModel Lot { get; set; }
        public PersonViewModel Person { get; set; }
        public int DocumentId { get; set; }
        public BiddingTypeViewModel BiddingType { get; set; }
        public TenderTypeViewModel TenderType { get; set; }
        public int ProtocolId { get; set; }
        public CountryViewModel Country { get; set; }
        public CompanyViewModel Company { get; set; }

    }
}
