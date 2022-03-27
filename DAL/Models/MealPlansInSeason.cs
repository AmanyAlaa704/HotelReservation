using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class MealPlansInSeason
    {
        public int id { get; set; }
        public int MealPlanID { get; set; }
        public int SeasonID { get; set; }
        public int Price { get; set; }

        [ForeignKey("MealPlanID")]
        public MealPlans Meal { get; set; }

        [ForeignKey("SeasonID")]
        public SeasonType Season { get; set; }

    }
}
