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
    public class RoomTypeRepository : BaseRepository<RoomType>
    {
        private DbContext HR_DbContext;

        public RoomTypeRepository(DbContext HR_DbContext) : base(HR_DbContext)
        {
            this.HR_DbContext = HR_DbContext;
        }


        public List<RoomType> GetAllRoomTypes()
        {
            return GetAll().ToList();
        } 

        public RoomType GetRoomTypesById(int ID)
        {
            return GetWhere(RT => RT.ID == ID).FirstOrDefault();
        }

        public bool InsertRoomType(RoomType roomType)
        {
            if (!CheckRoomTypeExist(roomType))
            {
                return Insert(roomType);
            }
            else
                return false;
        }

        public void DeleteRoomType(int id)
        {
            Delete(id);
        }


        public void UpdateRoomType(RoomType roomType)
        {
            Update(roomType);
        }


        public bool CheckRoomTypeExist(RoomType roomType)
        {
            return GetAny(R => R.Name == roomType.Name);
        }
    }
}