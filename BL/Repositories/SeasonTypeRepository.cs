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
    public class SeasonTypeRepository : BaseRepository<SeasonType>
    {
        private DbContext HR_DbContext;

        public SeasonTypeRepository(DbContext HR_DbContext) : base(HR_DbContext)
        {
            this.HR_DbContext = HR_DbContext;
        }

      
        public List<SeasonType> GetAllSeasonTypes()
        {
            return GetAll().ToList();
        }

        public SeasonType  GetSeasonTypeByID(int ID)
        {
            return GetFirstOrDefault(ST => ST.ID == ID);
        }

        public SeasonType GetSeasonTypeByName(string SeasonName)
        {
            return GetFirstOrDefault(ST => ST.Name == SeasonName);
        }

        public SeasonType GetSeasonTypeByDate(DateTime dateTime)
        {
            return GetFirstOrDefault(ST => ST.SeasionBegin >= dateTime && ST.SeasionEnd <= dateTime);
        }
        public bool InsertSeasonType(SeasonType seasonType)
        {
            if (!CheckSeasonTypeExist(seasonType))
            {
               return Insert(seasonType); 
            }
            else
            return false;
        }        

        public void DeleteSeasonTypes(int id)
        {
            Delete(id);
        }


        public void UpdateSeasonTypes(SeasonType seasonType)
        {
            Update(seasonType);
        }


        public bool CheckSeasonTypeExist(SeasonType seasonType)
        {
            return GetAny(ST => ST.SeasionBegin == seasonType.SeasionBegin && ST.SeasionEnd == seasonType.SeasionEnd);
        }               
    }
}
