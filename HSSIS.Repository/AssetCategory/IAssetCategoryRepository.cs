using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Repository.AssetCategory
{
    public interface IAssetCategoryRepository
    {
        Task<IList<AssetCategoryModel>> GetAllAssetCategories(bool showDeactivated);  
        Task<AssetCategoryModel> GetAssetCategoryById(int assetCategoryId);
        AssetCategoryModel GetAssetCategoryByName(string assetCategoryName);
        Task<int> AddAssetCategory(AssetCategoryModel assetCategory);
        Task<int> UpdateAssetCategory(AssetCategoryModel assetCategory);
        Task<int> DeactivateAssetCategory(AssetCategoryModel assetCategory);
        Task<int> ActivateAssetCategory(AssetCategoryModel assetCategory);
    }
}
