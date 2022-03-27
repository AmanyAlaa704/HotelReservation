using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class MealPlanDto
    {
        public int ID { get; set; }
        public string MealPlanName { get; set; }
        public int IsAddedToSeasons { get; set; } = 0;


    }
}
