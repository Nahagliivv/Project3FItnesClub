using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClubCP.Model
{
    public class Abonements
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int User_Id { get; set; }
        [ForeignKey("Trener")]
        [Required]
        public int Trener_Id { get; set; }
        public User User { get; set; }
        public Trener Trener { get; set; }
    }
}
