using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Model
{
    public class FullQuote
    {
        [Required]
        public int Author_Id { get; set; }
        [Required]
        [MinLength(15)]
        public string Text { get; set; }
        [Required]
        public List<string> Categories { get; set; }
    }
}
