using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Model
{
    public class Author
    {
        [Key]
        public int AId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Emailaddress { get; set; }
        public bool DialyNews { get; set; } = false;
        public List<Quote> Quotes { get; set; }
    }
}
