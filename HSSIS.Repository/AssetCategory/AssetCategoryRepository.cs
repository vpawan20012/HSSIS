using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Repository.AssetCategory
{
    public class AssetCategoryRepository : BaseRepository, IAssetCategoryRepository
    {
        public AssetCategoryRepository(HSSIS_DBContext dbContext):base(dbContext)
        {
                
        }
        public async Task<IList<AssetCategoryModel>> GetAllAssetCategories()
        {
            FormattableString query = $"exec USP_Master_AssetCategory_GetAll";
            return await _dbContext.TblMasterAssetCategories.FromSqlInterpolated<AssetCategoryModel>(query).ToListAsync();
        }
    }
}
