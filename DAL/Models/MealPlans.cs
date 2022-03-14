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
        public double Price { get; set; }
        public int SeasonId { get; set; }

        [ForeignKey("SeasonId")]
        public SeasonType seasonType { get; set; }

    }
}
