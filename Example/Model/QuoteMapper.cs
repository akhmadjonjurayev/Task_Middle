using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Model
{
    public class QuoteMapper
    {
        public string Text { get; set; }
        public DateTime Entered_Date { get; set; }
        public string Author { get; set; }
        public List<string> Type { get; set; }
    }
}
