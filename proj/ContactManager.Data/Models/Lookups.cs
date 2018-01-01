
namespace ContactManager.Data.Models
{
    public class Lookups
    {
        public class StateProvinces
        {
            public int Id { get; set; }
            public string StateCode { get; set; }
            public string Statename { get; set; }
        }

        public class Categories
        {
            public int Id { get; set; }
            public string Category { get; set; }
        }
    }
}
