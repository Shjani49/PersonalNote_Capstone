using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotes.Models
{
    [Table("user")]
    public partial class User
    {

        public User()
        {
            Notes = new HashSet<Notes>();
        }

        [Key]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("fname", TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column("lname", TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(50)")]
        public string Password { get; set; }

        [InverseProperty(nameof(Models.Notes.Users))]
        public virtual ICollection<Notes> Notes { get; set; }

    }

}
