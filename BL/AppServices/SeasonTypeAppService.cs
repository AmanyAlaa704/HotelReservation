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
    public class SeasonTypeAppService : AppServiceBase
    {
        public SeasonTypeAppService(Interfaces.IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<SeasonTypeDto> GetAllSeasonTypes()
        {
            return Mapper.Map<List<SeasonTypeDto>>(TheUnitOfWork.seasonType.GetAllSeasonTypes());
        }
        public SeasonTypeDto GetSeasonTypesById(int ID)
        {
            return Mapper.Map<SeasonTypeDto>(TheUnitOfWork.seasonType.GetSeasonTypeByID(ID));
        }
        public SeasonTypeDto GetSeasonTypesByName(string SeasonName)
        {
            return Mapper.Map<SeasonTypeDto>(TheUnitOfWork.seasonType.GetSeasonTypeByName(SeasonName));
        }

        public bool SaveNewSeasonTypes(SeasonTypeDto seasonType)
        {
            if (seasonType == null)
                throw new ArgumentNullException();

            bool result = false;
            var SeasonType = Mapper.Map<SeasonType>(seasonType);
            if (TheUnitOfWork.seasonType.InsertSeasonType(SeasonType))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdateSeasonTypes(SeasonTypeDto seasonType)
        {
            var SeasonType = Mapper.Map<SeasonType>(seasonType);
            TheUnitOfWork.seasonType.Update(SeasonType);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool CheckSeasonTypesExist(SeasonTypeDto seasonType)
        {
            return TheUnitOfWork.seasonType.CheckSeasonTypeExist(Mapper.Map<SeasonType>(seasonType));
        }
        public bool DeleteSeasonTypes(int id)
        {
            bool result = false;
            TheUnitOfWork.seasonType.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

    }
}