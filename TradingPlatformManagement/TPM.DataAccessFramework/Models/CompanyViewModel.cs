using System;

namespace TPM.DataAccessFramework.Models
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public DateTime? FoundationDate { get; set; }
        public int? INN { get; set; }
        public int? KPP { get; set; }
        public int? OGRN { get; set; }
        public DateTime? AkkreditationDate { get; set; }

    }
}
