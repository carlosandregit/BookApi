using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Model
{    
    public class Book
    {
        [Key]
        public int IdBook { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string PublishedDate { get; set; }
    }
}
