using System.ComponentModel.DataAnnotations;

namespace Manipulate_data_API_ex
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string Author { get; set; }

        [Required]
        [Range(0, 10000)]
        public int Page { get; set; }
    }
}
