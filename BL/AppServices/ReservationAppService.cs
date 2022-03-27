using AutoMapper;
using BL.Bases;
using BL.Dtos;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppServices
{
    public class ReservationAppService : AppServiceBase
    {

        public ReservationAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<ReservationDto> GetAllReservation()
        {
            return Mapper.Map<List<ReservationDto>>(TheUnitOfWork.reservation.GetAllReservations());
        }
        public List<ReservationDto> GetReservationOftoday(DateTime dateOfToday)
        {
            return Mapper.Map<List<ReservationDto>>(TheUnitOfWork.reservation.GetReservationOftoday(dateOfToday));
        }
        public ReservationDto GetReservationByUserId(string UserID)
        {
            return Mapper.Map<ReservationDto>(TheUnitOfWork.reservation.GetReservationByUserId(UserID));
        }

        public bool SaveNewReservation(ReservationDto reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException();

            bool result = false;
            var Reservation = Mapper.Map<Reservation>(reservation);
            if (TheUnitOfWork.reservation.InsertReservation(Reservation))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateReservation(ReservationDto reservation)
        {
            var Reservation = Mapper.Map<Reservation>(reservation);
            TheUnitOfWork.reservation.Update(Reservation);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteReservation(int id)
        {
            bool result = false;
            TheUnitOfWork.reservation.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }


        public bool CheckReservationExist(ReservationDto reservation)
        {
            return TheUnitOfWork.reservation.CheckReservationExist(Mapper.Map<Reservation>(reservation));
        }

    }
}