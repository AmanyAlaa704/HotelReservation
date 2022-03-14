using BL.Bases;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repositories
{
    public class ReservationRepository : BaseRepository<Reservation>
    {
        private DbContext HR_DbContext;

        public ReservationRepository(DbContext HR_DbContext) : base(HR_DbContext)
        {
            this.HR_DbContext = HR_DbContext;
        }


        public List<Reservation> GetAllReservations()
        {
            return GetAll().ToList();
        }
        public List<Reservation> GetReservationByUserId(string  UserID)
        {
            return GetWhere(R => R.UserID == UserID).ToList();
        }

        public List<Reservation> GetReservationBetweenTowDates(DateTime date)
        {
            return GetWhere(R => R.From >= date && R.To <= date).ToList();
        }

        public bool InsertReservation(Reservation reservation)
        {
            if (!CheckReservationExist(reservation))
            {
                return Insert(reservation);
            }
            else
                return false;
        }

        public void DeleteReservation(int id)
        {
            Delete(id);
        }


        public void UpdateReservation(Reservation reservation)
        {
            Update(reservation);
        }


        public bool CheckReservationExist(Reservation reservation)
        {
            return GetAny(R => R.UserID == reservation.UserID && R.RoomID == reservation.RoomID && R.From == reservation.From && R.To == reservation.To);
        }


    }
}