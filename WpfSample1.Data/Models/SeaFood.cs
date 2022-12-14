using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample1.Data.Models
{
    public class SeaFood
    {
        [Column("ma")]
        public int Ma { get; set; }

        [Column("ten")]
        public string Ten { get; set; }

        [Column("gia")]
        public int Gia { get; set; }

        [Column("xuatxu")]
        public string? XuatXu { get; set; }
    }
}
