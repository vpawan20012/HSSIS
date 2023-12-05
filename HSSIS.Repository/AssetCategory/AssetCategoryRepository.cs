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
using HSSIS.Models.ViewModels;
using Microsoft.Data.SqlClient;

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
            //return await _dbContext.MasterAssetCategories.FromSqlInterpolated<AssetCategoryModel>(query).ToListAsync();
            return await _dbContext.Database.SqlQueryRaw<AssetCategoryModel>(query.Format).ToListAsync();
            
        }

        public async Task<AssetCategoryModel> GetAssetCategoryById(int assetCategoryId)
        {
            var param_AssetCategoryId = new SqlParameter("@AssetCategoryId", assetCategoryId);
            object[] parameters = new object[1] { param_AssetCategoryId };
            string query = $"exec USP_Master_AssetCategory_GetById @AssetCategoryId";
            return await _dbContext.Database.SqlQueryRaw<AssetCategoryModel>(query, parameters).FirstOrDefaultAsync();
        }

        public async Task<AssetCategoryModel> GetAssetCategoryByName(string assetCategoryName)
        {
            var param_AssetCategoryName = new SqlParameter("@AssetCategoryName", assetCategoryName);
            object[] parameters = new object[1] { param_AssetCategoryName };
            string query = $"exec USP_Master_AssetCategory_GetByName @AssetCategoryId";
            return await _dbContext.Database.SqlQueryRaw<AssetCategoryModel>(query, parameters).FirstOrDefaultAsync();
        }
    }
}
