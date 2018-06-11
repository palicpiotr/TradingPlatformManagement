
namespace TPM.DataAccessFramework.Models
{
   public class PersonViewModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patron { get; set; }
        public int PersonTypeId { get; set; }
        public CompanyViewModel Company { get; set; }
        public CountryViewModel Country { get; set; }
    }
}
