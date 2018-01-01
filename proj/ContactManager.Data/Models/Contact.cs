using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string PhoneDirectLine { get; set; }
        public string PhoneExtension { get; set; }
        public string PhoneHome { get; set; }
        public string EmailAddress { get; set; }
    }
}
