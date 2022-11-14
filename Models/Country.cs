using System.ComponentModel.DataAnnotations;

namespace SelectExample.Models
{
    public class Country
    {
        [Key]
        [MaxLength(3)]
        public string Code { get; set; }

        [Required]
        [MaxLength(75)]
        public string Name { get; set; }
    }
}
