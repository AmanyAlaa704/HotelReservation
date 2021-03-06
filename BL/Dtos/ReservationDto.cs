using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos
{
    public class ReservationDto
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

    }
}
