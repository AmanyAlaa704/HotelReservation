using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SeasonType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }


        [DataType(DataType.Date)]
        public DateTime SeasionBegin { get; set; }

        [DataType(DataType.Date)]
        public DateTime SeasionEnd { get; set; }
    }
}
