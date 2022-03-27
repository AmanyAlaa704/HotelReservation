using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int RoomID { get; set; }
        public int MealPlanID { get; set; }
        public int TotalPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [DataType(DataType.Date)]
        public DateTime To { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }


        [ForeignKey("UserID")]
        public ApplicationUsersIdentity User { get; set; } 
        
        [ForeignKey("RoomID")]
        public RoomType Room { get; set; }

        [ForeignKey("MealPlanID")]
        public MealPlans Meal { get; set; }

    }
}
