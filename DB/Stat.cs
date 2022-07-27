using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Stat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StatId { get; set; }

        public int Set { get; set; }
        public int Rep { get; set; }
        public int Weight { get; set; }

        [ForeignKey("ExerciseId")]
        public int ExerciseId { get; set; }


    }
}
