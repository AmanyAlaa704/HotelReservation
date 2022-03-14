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
    public class RoomTypeAppService : AppServiceBase
    {
        public RoomTypeAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<RoomTypesDto> GetAllRoomTypes()
        {
            return Mapper.Map<List<RoomTypesDto>>(TheUnitOfWork.roomType.GetAllRoomTypes());
        }
        public RoomTypesDto GetRoomTypesById(int ID)
        {
            return Mapper.Map<RoomTypesDto>(TheUnitOfWork.roomType.GetRoomTypesById(ID));
        }

        public bool SaveNewRoomTypes(RoomTypesDto roomType)
        {
            if (roomType == null)
                throw new ArgumentNullException();

            bool result = false;
            var RoomType = Mapper.Map<RoomType>(roomType);
            if (TheUnitOfWork.roomType.InsertRoomType(RoomType))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateRoomTypes(RoomTypesDto roomType)
        {
            var RoomType = Mapper.Map<RoomType>(roomType);
            TheUnitOfWork.roomType.Update(RoomType);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool CheckRoomTypesExist(RoomTypesDto roomType)
        {
            return TheUnitOfWork.roomType.CheckRoomTypeExist(Mapper.Map<RoomType>(roomType));
        }

        public bool DeleteRoomTypes(int id)
        {
            bool result = false;
            TheUnitOfWork.roomType.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

    }
}