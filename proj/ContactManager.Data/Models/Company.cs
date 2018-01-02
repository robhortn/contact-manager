
namespace ContactManager.Data.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int StateId { get; set; }
        public string StateProvinceName { get; set; }
        public string PostalCode { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
