using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class MealPlansInSeasonDto
    {
        public int id { get; set; }
        public int MealPlanID { get; set; }
        public int SeasonID { get; set; }
        public int Price { get; set; }
    }
}
