using System.ComponentModel.DataAnnotations;

namespace EFCoreDemo.Model
{
    public class StudentEntity
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Standard { get; set; }

    }
}
