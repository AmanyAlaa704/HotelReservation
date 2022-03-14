﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class RoomType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SeasonId { get; set; }

        [DefaultValue(10)]
        public int AllRooms { get; set; }

        [DefaultValue(0)]
        public int RemainRooms { get; set; }

        public int Price { get; set; }

        [ForeignKey("SeasonId")]
        public SeasonType seasonType { get; set; }
    }
}
