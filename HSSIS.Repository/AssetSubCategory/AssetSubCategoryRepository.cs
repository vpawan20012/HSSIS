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
        public AssetSubCategoryRepository(HSSIS_DBContext dbContext) : base(dbContext)
        {

        }

        public async Task<int> ActivateAssetSubCategory(AssetSubCategoryModel assetSubCategory)
        {
            object[] parameters = new object[2]
            {
                new SqlParameter("@AssetSubCategoryId", assetSubCategory.AssetSubCategoryId),
                new SqlParameter("@UpdatedBy", assetSubCategory.UpdatedBy)
            };
            string query = $"exec USP_Master_AssetSubCategory_Activate @AssetSubCategoryId,@UpdatedBy";
            return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public async Task<int> AddAssetSubCategory(AssetSubCategoryModel assetSubCategory)
        {
            object[] parameters = new object[4] {
            new SqlParameter("@AssetCategoryId", assetSubCategory.AssetCategoryId),
            new SqlParameter("@AssetCategoryName", assetSubCategory.AssetSubCategoryName),
            new SqlParameter("@Description", assetSubCategory.Description),
            new SqlParameter("@CreatedBy", assetSubCategory.CreatedBy)
        };
            string query = $"exec USP_Master_AssetSubCategory_Add @AssetCategoryId,@AssetSubCategoryName, @Description, @CreatedBy";
            return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public async Task<int> DeactivateAssetSubCategory(AssetSubCategoryModel assetSubCategory)
        {
            object[] parameters = new object[2]
            {
                new SqlParameter("@AssetSubCategoryId", assetSubCategory.AssetSubCategoryId),
                new SqlParameter("@UpdatedBy", assetSubCategory.UpdatedBy)
            };
            string query = $"exec USP_Master_AssetSubCategory_Deactivate @AssetSubCategoryId,@UpdatedBy";
            return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public async Task<IList<AssetSubCategoryViewModel>> GetAllAssetSubCategories(int assetCategoryId, bool showDeactivated)
        {
            object[] parameters = new object[2] {
                new SqlParameter("@AssetCategoryId", assetCategoryId),
            new SqlParameter("@ShowDeactivated", showDeactivated)
            };
            //FormattableString query = $"exec USP_Master_AssetSubCategory_GetAll @AssetCategoryId";
            string query = $"exec USP_Master_AssetSubCategory_GetAll @AssetCategoryId, @ShowDeactivated";
            //return await _dbContext.MasterAssetSubCategories.FromSqlInterpolated<AssetSubCategoryViewModel>(query).ToListAsync();
            return await _dbContext.Database.SqlQueryRaw<AssetSubCategoryViewModel>(query, parameters).ToListAsync();
        }

        public async Task<AssetSubCategoryModel> GetAssetSubCategoryById(int assetSubCategoryId)
        {
            object[] parameters = new object[1] { new SqlParameter("@AssetSubCategoryId", assetSubCategoryId) };
            string query = $"exec USP_Master_AssetSubCategory_GetById @AssetSubCategoryId";
            List<AssetSubCategoryModel> result = await _dbContext.Database.SqlQueryRaw<AssetSubCategoryModel>(query, parameters).ToListAsync();
            return result != null ? result.First() : null;
        }

        public AssetSubCategoryModel GetAssetSubCategoryByName(string assetSubCategoryName)
        {
            object[] parameters = new object[1] { new SqlParameter("@AssetSubCategoryName", assetSubCategoryName) };
            string query = $"exec USP_Master_AssetSubCategory_GetByName @AssetSubCategoryName";
            List<AssetSubCategoryModel> result = _dbContext.Database.SqlQueryRaw<AssetSubCategoryModel>(query, parameters).ToList();
            return result != null ? result.First() : null;
        }

        public async Task<int> UpdateAssetSubCategory(AssetSubCategoryModel assetSubCategory)
        {
            object[] parameters = new object[5]
            {
                new SqlParameter("@AssetSubCategoryId", assetSubCategory.AssetSubCategoryId),
                new SqlParameter("@AssetCategoryId", assetSubCategory.AssetCategoryId),
                new SqlParameter("@AssetCategoryName", assetSubCategory.AssetSubCategoryName),
                new SqlParameter("@Description", assetSubCategory.Description),
                new SqlParameter("@UpdatedBy", assetSubCategory.UpdatedBy)
            };
            string query = $"exec USP_Master_AssetSubCategory_Update @AssetSubCategoryId,@AssetCategoryId,@AssetSubCategoryName, @Description, @UpdatedBy";
            return await _dbContext.Database.ExecuteSqlRawAsync(query, parameters);
        }
    }
}
