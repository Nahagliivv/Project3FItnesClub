using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClubCP.Model
{
    public class Trener
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Middlename { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public bool Monday { get; set; } = false;
        [Required]
        public bool Tuesday { get; set; } = false;
        [Required]
        public bool Wednesday { get; set; } = false;
        [Required]
        public bool Thursday { get; set; } = false;
        [Required]
        public bool Friday { get; set; } = false;
        [Required]
        public bool Saturday { get; set; } = false;
        [Required]
        public bool Sunday { get; set; } = false;
        [Required]
        public int MaxClients { get; set; } 
        public virtual List<Abonements> Abonements { get; set; }
        public virtual List<Comment> Comment { get; set; }
    }
}
