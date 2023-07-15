using System.ComponentModel.DataAnnotations;

namespace ImageContentProssessor.Model
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Url { get; set; }
    }
}
