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
        public AssetCategoryRepository(HSSIS_DBContext dbContext) : base(dbContext)
        {

        }

        public async Task<int> ActivateAssetCategory(AssetCategoryModel assetCategory)
        {
            object[] parameters = new object[2] {
                new SqlParameter("@AssetCategoryId", assetCategory.AssetCategoryId),
            new SqlParameter("@UpdatedBy", assetCategory.UpdatedBy)
        };
            string query = $"exec USP_Master_AssetCategory_Activate @AssetCategoryId ,@UpdatedBy";
            return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public async Task<int> AddAssetCategory(AssetCategoryModel assetCategory)
        {
            object[] parameters = new object[3] {
            new SqlParameter("@AssetCategoryName", assetCategory.AssetCategoryName),
            new SqlParameter("@Description", assetCategory.Description),
            new SqlParameter("@CreatedBy", assetCategory.CreatedBy)
        };
            string query = $"exec USP_Master_AssetCategory_Add @AssetCategoryName, @Description, @CreatedBy";
            return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);

        }

        public async Task<int> DeactivateAssetCategory(AssetCategoryModel assetCategory)
        {
            object[] parameters = new object[2] {
                new SqlParameter("@AssetCategoryId", assetCategory.AssetCategoryId),
            new SqlParameter("@UpdatedBy", assetCategory.UpdatedBy)
        };
            string query = $"exec USP_Master_AssetCategory_Deactivate @AssetCategoryId ,@UpdatedBy";
            return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public async Task<IList<AssetCategoryModel>> GetAllAssetCategories(bool showDeactivated)
        {            
            object[] parameters = new object[1] { new SqlParameter("@ShowDeactivated", showDeactivated) };
            FormattableString query = $"exec USP_Master_AssetCategory_GetAll @ShowDeactivated";
            //return await _dbContext.MasterAssetCategories.FromSqlInterpolated<AssetCategoryModel>(query).ToListAsync();
            return await _dbContext.Database.SqlQueryRaw<AssetCategoryModel>(query.Format,parameters).ToListAsync();
        }

        public async Task<AssetCategoryModel> GetAssetCategoryById(int assetCategoryId)
        {
            var param_AssetCategoryId = new SqlParameter("@AssetCategoryId", assetCategoryId);
            object[] parameters = new object[1] { param_AssetCategoryId };
            string query = $"exec USP_Master_AssetCategory_GetById @AssetCategoryId";
            List<AssetCategoryModel> result= await _dbContext.Database.SqlQueryRaw<AssetCategoryModel>(query, parameters).ToListAsync();
            return result != null ? result.First() : null;
        }

        public AssetCategoryModel GetAssetCategoryByName(string assetCategoryName)
        {
            var param_AssetCategoryName = new SqlParameter("@AssetCategoryName", assetCategoryName);
            object[] parameters = new object[1] { param_AssetCategoryName };
            string query = $"exec USP_Master_AssetCategory_GetByName @AssetCategoryId";
            List<AssetCategoryModel> result = _dbContext.Database.SqlQueryRaw<AssetCategoryModel>(query, parameters).ToList();
            return result != null ? result.First() : null;
        }

        public async Task<int> UpdateAssetCategory(AssetCategoryModel assetCategory)
        {
            object[] parameters = new object[4] {
                new SqlParameter("@AssetCategoryId", assetCategory.AssetCategoryId),
            new SqlParameter("@AssetCategoryName", assetCategory.AssetCategoryName),
            new SqlParameter("@Description", assetCategory.Description),
            new SqlParameter("@UpdatedBy", assetCategory.UpdatedBy)
        };
            string query = $"exec USP_Master_AssetCategory_Update @AssetCategoryId, @AssetCategoryName ,@Description ,@UpdatedBy";
            return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        }
    }
}
