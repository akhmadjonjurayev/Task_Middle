using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Example.Model
{
    public class Category_Quote
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey(nameof(Quote))]
        public int Quote_Id { get; set; }
        [JsonIgnore]
        public Quote Quote { get; set; }
        [ForeignKey(nameof(Category))]
        public int Category_Id { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}