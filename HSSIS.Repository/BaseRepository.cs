using HSSIS.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Repository
{
    public class BaseRepository
    {
        protected HSSIS_DBContext _dbContext;
        public BaseRepository(HSSIS_DBContext dBContext)
        {
            this._dbContext=dBContext;
        }
    }
}
