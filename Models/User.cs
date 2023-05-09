using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADHD_anaylzer_Admin.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

    }
}
