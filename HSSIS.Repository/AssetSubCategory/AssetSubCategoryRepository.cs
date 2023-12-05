using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using HSSIS.Models.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Repository.AssetSubCategory
{
    public class AssetSubCategoryRepository : BaseRepository, IAssetSubCategoryRepository
    {
        public AssetSubCategoryRepository(HSSIS_DBContext dbContext):base(dbContext)
        {
                
        }
        public async Task<IList<AssetSubCategoryViewModel>> GetAllAssetSubCategories(int assetCategoryId)
        {
            var param_AssetCategoryId = new SqlParameter("@AssetCategoryId", assetCategoryId);
            object[] parameters = new object[1] { param_AssetCategoryId };
            //FormattableString query = $"exec USP_Master_AssetSubCategory_GetAll @AssetCategoryId";
            string query = $"exec USP_Master_AssetSubCategory_GetAll @AssetCategoryId";
            //return await _dbContext.MasterAssetSubCategories.FromSqlInterpolated<AssetSubCategoryViewModel>(query).ToListAsync();
            return await _dbContext.Database.SqlQueryRaw<AssetSubCategoryViewModel>(query,parameters).ToListAsync();
        }
    }
}
