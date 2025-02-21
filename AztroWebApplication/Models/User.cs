// Create un model class named User.cs and add the following code to it:

using System.ComponentModel.DataAnnotations;

namespace AztroWebApplication.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

            
        public User()
        {
        }
    }

}