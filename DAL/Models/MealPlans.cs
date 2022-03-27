using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MealPlans
    {
        public int ID { get; set; }
        public string MealPlanName { get; set; }

        public int IsAddedToSeasons { get; set; } = 0;



    }
}
