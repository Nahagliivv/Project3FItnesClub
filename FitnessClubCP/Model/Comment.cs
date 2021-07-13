using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClubCP.Model
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int User_Id { get; set; }
        [Required]
        [ForeignKey("Trener")]
        public int Trener_Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime PublicDate { get; set; }
        [Required]
        public string UserFullName { get; set; }
        public virtual User User { get; set; }
        public virtual Trener Trener { get; set; }

    }
}
