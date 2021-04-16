using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Model
{
    public class Category
    {
        [Key]
        public int CId { get; set; }
        [Required]
        public string Type { get; set; }
        public List<Category_Quote> category_s { get; set; }
    }
}
