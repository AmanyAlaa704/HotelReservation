﻿using BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        AccountRepository account { get; }       
        MealPlansRepository mealPlans { get; }       
        RoomTypeRepository roomType { get; }       
        SeasonTypeRepository seasonType { get; }       
        ReservationRepository reservation { get; }       
    }
}
