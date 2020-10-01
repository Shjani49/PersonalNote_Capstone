using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalNotes.Models
{

    [Table("notes")]
    public partial class Notes
    {
       
        [Key]
        [Column("ID", TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column("Note",TypeName = "varchar(200)")]
        public string Description { get; set; }
        [Required]
        [Column("date",TypeName = "DateTime")]
        public DateTime Date { get; set; }

        [Column("UserId", TypeName = "int(10)")]
        public int UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        [InverseProperty(nameof(Models.User.Notes))]
        public virtual User Users { get; set; }
    }
}
