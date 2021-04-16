using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Model
{
    public class Quote
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        [ForeignKey(nameof(Author))]
        public int Author_id { get; set; }
        public Author Author { get; set; }
        public DateTime Entered_Date { get; set; }
        public List<Category_Quote> category_s { get; set; }
    }
}