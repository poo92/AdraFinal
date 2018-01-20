using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class AccountBalance
    {
        [Key]
        [Column(Order = 0)]
        public int year { get; set; }
        [Key]
        [Column(Order = 1)]
        public int month { get; set; }
        public double rnd { get; set; }
        public double canteen { get; set; }
        public double ceocar { get; set; }
        public double marketing { get; set; }
        public double parking { get; set; }
        public int uid { get; set; }
    }
}
