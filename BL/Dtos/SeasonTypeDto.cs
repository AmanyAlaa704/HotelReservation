using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class SeasonTypeDto
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Price { get; set; }


        [DataType(DataType.Date)]
        public DateTime SeasionBegin { get; set; }

        [DataType(DataType.Date)]
        public DateTime SeasionEnd { get; set; }
      

    }
}
